using UnityEngine;
using System.Collections;

public class PlayerHidingMechanic : MonoBehaviour {

	private bool playerHiding, playerHid;
	private RaycastHit ray;
	private float distaceFromWall;
	private CharacterController player;
	private PlayerGravity playerGravity;
	public bool onStairs;


	// Use this for initialization
	void Start () {
		playerHiding = false;
		distaceFromWall = 0.0f;
		playerGravity = GetComponent<PlayerGravity> ();
		player = GetComponent<CharacterController> ();
		onStairs = false;
		playerHid = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (playerGravity.grounded || onStairs) {

			//Debug.Log("Player could hide");

			if (Input.GetKey (KeyCode.W)) {
				//Debug.Log("player hiding");
				playerGravity.setHidng (true);
				playerGravity.setOnStairs(true);
				playerHiding = true;
			} else {
				playerGravity.setHidng (false);
				playerGravity.setOnStairs(false);
				playerHiding = false;
				playerHid = false;
			}
		}

	}

	void OnTriggerStay(Collider trigger){

		if (trigger.gameObject.tag == "HidingSpot" || trigger.gameObject.tag == "Stairs") {

			if(trigger.gameObject.tag == "Stairs"){
				onStairs = true;
			}

			//Debug.Log("PlayerCanHide");

			if(playerHiding && !playerHid){
				playerHid = true;
				if(Physics.Raycast(transform.position, -transform.forward, out ray)){
					if(ray.collider.gameObject.tag == "HallWay"){
						distaceFromWall = ray.distance;
						transform.Translate(transform.forward*(distaceFromWall*(0.90f)));
					}
				}else if(Physics.Raycast(transform.position, transform.forward, out ray)){
					if(ray.collider.gameObject.tag == "HallWay"){
						distaceFromWall = ray.distance;
						transform.Translate(transform.forward*(distaceFromWall*(0.90f)));
					}
				}
			}else{
				//transform.Translate(-transform.forward*distaceFromWall*1.5f);
				distaceFromWall = 0;
			}
		}
	}

	void OnTriggerExit(Collider trigger){
		if (trigger.gameObject.tag == "HidingSpot" || trigger.gameObject.tag == "Stairs") {
			playerHiding = false;
			onStairs = false;
			playerHid = false;
		}
	}

	public bool getPlayerHiding(){return playerHiding;}
}
