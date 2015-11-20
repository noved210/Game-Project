﻿using UnityEngine;
using System.Collections;

public class PlayerGravity : MonoBehaviour {

	private CharacterController player;
	private bool grounded = false, hiding;
	private float playerVerticalSpeed = 0;
	public float gravity = 9.81f;
	public float jumpPower = 10.0f;

	// Use this for initialization
	void Start () {
		player = GetComponent<CharacterController> ();
		hiding = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (grounded) {
			if(Input.GetKey("space")){
				grounded = false;
				if(!hiding){
					playerVerticalSpeed = jumpPower;
				}
			}
		}

		player.Move(new Vector3 (0, playerVerticalSpeed * Time.deltaTime, 0));

		if (player.collisionFlags == CollisionFlags.Below) {
			grounded = true;
		} else {
			if(!grounded)
				playerVerticalSpeed -= gravity*Time.deltaTime;
		}

	}

	public void setHidng(bool hiding){
		this.hiding = hiding;
	}
	public bool getHiding(){
		return this.hiding;
	}
}