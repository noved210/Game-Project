﻿using UnityEngine;
using System.Collections;

public class characterStats : MonoBehaviour {


	//variables for swarm damage control
	private float timer, knowbackTimer;
	private bool timerRunning, addingKnockback;
	private CharacterController player;
	private PlayerGravity gravity;
	private PlayerMove playerMove;
	private Vector3 knockback;
	public float swarmDamage;

    public Vector3 spawnPoint;
	public float health = 10;
	public float speed = 0.25f;
	public float damage = 1;
	public float detection = 0;
	public int baseAmmo = 10;
	public int stunAmmo = 5;
	public int distractAmmo = 5;
	public int weaponSelected = 0;
	//Check maxAmmo whever adding ammo from pickup
	public int maxAmmo = 10;

	// Use this for initialization
	void Start () {

		player = GetComponent<CharacterController> ();
		gravity = GetComponent<PlayerGravity> ();
		playerMove = GetComponent<PlayerMove> ();

		timer = 0;
		timerRunning = false;
		knockback = Vector3.zero;
		addingKnockback = false;
		knowbackTimer = 0;

	}

	public void applyDamage(float damage, Vector3 force)
	{
		addingKnockback = true;
		knockback = force*25;
		if (playerMove.getSpeed () != 0) {
			knockback.x *= Mathf.Abs(((playerMove.getSpeed ()/25)))+1;
		}
		knockback.y = 15;

		//Debug.Log ("knockback: " + knockback + " player move speed: " + playerMove.getSpeed());

		health -= damage;
		if (health <= 0) {
			Die ();
		}
	}


	void Die() {
        //Application.LoadLevel(Application.loadedLevel);
        transform.position = spawnPoint;
        health = 10;	
	}

	void Update () {

		//Debug.Log (health);

		if (addingKnockback) {

			//Debug.Log("Knock back: " + knockback);

			player.Move(knockback*Time.deltaTime);
			knockback = Vector3.Lerp(knockback, Vector3.zero, 5*Time.deltaTime);
			gravity.grounded = false;

			knowbackTimer += Time.deltaTime;

			if(knowbackTimer > 1){
				addingKnockback = false;
				knowbackTimer = 0;
			}

		}

		if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey (KeyCode.Alpha1)) {
			weaponSelected = 0;
			Debug.Log ("Weapon 1 selected");
		} else if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey (KeyCode.Alpha2)) {
			weaponSelected = 1;
			Debug.Log ("Weapon 2 selected");
		} else if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey (KeyCode.Alpha3)) {
			weaponSelected = 2;
			Debug.Log ("Weapon 3 selected");
		}



	}

	//if the player enters the bug swarm damage the player once per second
	void OnTriggerEnter(Collider trigger){
		//damage the player once and start the timer for damaging the player more
		if (trigger.gameObject.tag == "BugSwarm") {
			timerRunning = true;
			timer = 0;
		}

		if (trigger.gameObject.tag == "Mummy" && !addingKnockback) {

			Debug.Log("player x: " + transform.position.x + " npc x: " + trigger.gameObject.transform.position.x);
			Debug.Log("npc direction: " + trigger.transform.forward + " global direction: " + Vector3.forward);


			if(transform.position.x > trigger.gameObject.transform.position.x){
				applyDamage(damage, Vector3.right);
			}
			else{
				applyDamage(damage, -Vector3.right);
			}
		}
        if (trigger.gameObject.tag == "Spawn")
        {
            Debug.Log("spawn");
            spawnPoint = trigger.transform.position;
        }
        if (trigger.gameObject.tag == "Spike")
        {
            Die();
        }

    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("why");
        if (col.gameObject.tag == "Break")
        {
            Debug.Log("hello");
            Destroy(col.gameObject);
        }
    }

    //change the material transparency over time to indicate that the player is not being damaged
    void OnTriggerStay(Collider trigger){
		//damage the player once per second
		if (trigger.gameObject.tag == "BugSwarm") {
			if (timerRunning) {
				timer += Time.deltaTime;
				if (timer >= 1.0f) {
					applyDamage (swarmDamage, Vector3.zero);
					applyDamage (swarmDamage, -transform.up * 2);
					timer = 0;
				}
			}
		}

		if (trigger.gameObject.tag == "Mummy") {
			
			Debug.Log("player x: " + transform.position.x + " npc x: " + trigger.gameObject.transform.position.x);
			Debug.Log("npc direction: " + trigger.transform.forward + " global direction: " + Vector3.forward);
			
			
			if(transform.position.x > trigger.gameObject.transform.position.x){
				applyDamage(0, Vector3.right*1.5f);
			}
			else{
				applyDamage(0, -Vector3.right*1.5f);
			}
		}
	}

	void OnTriggerExit(Collider trigger){
		//if the player leaves the swarm trigger cancel the timer and reset it
		if (trigger.gameObject.tag == "BugSwarm") {
			timer = 0;
			timerRunning = false;
		}
	}

	void resetPlayerOrientation(){}

}
