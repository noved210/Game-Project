using UnityEngine;
using System.Collections;

public class PlayerGravity : MonoBehaviour {

	private CharacterController player;
	public bool grounded = false, hiding, onStairs;
	private float playerVerticalSpeed = 0;
	public float gravity = 9.81f;
	public float jumpPower = 10.0f;

	// Use this for initialization
	void Start () {
		player = GetComponent<CharacterController> ();
		hiding = false;
		onStairs = false;
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log ("move gravity :" + playerVerticalSpeed + " grounded? " + player.collisionFlags);
		//Debug.Log(playerVerticalSpeed);


		if (grounded) {

			//Debug.Log("Can jump");

			if(Input.GetKey("space")){
				grounded = false;
				if(!hiding || onStairs){
					playerVerticalSpeed = jumpPower;
				}
			}
		}

		player.Move(new Vector3 (0, playerVerticalSpeed * Time.deltaTime, 0));

		if (player.collisionFlags == CollisionFlags.Below) {
			grounded = true;
			if(grounded)
				playerVerticalSpeed = -0.1f;
		} else {
			grounded = false;
			if(!grounded)
				playerVerticalSpeed -= gravity*Time.deltaTime;
		}

	}

	void OnCollisionStay(Collision collider){
		if (collider.gameObject.tag == "Stairs") {

			//Debug.Log("On stairs");

			grounded = true;
		}
	}


	public void setHidng(bool hiding){
		this.hiding = hiding;
	}
	public bool getHiding(){
		return this.hiding;
	}

	public void setOnStairs(bool onStairs){
		this.onStairs = onStairs;
	}
	public bool setOnStairs(){
		return this.onStairs;
	}
}
