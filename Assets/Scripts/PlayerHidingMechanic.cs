using UnityEngine;
using System.Collections;

public class PlayerHidingMechanic : MonoBehaviour {

	private bool playerHiding;
	private RaycastHit ray;
	private float distaceFromWall;
	private PlayerGravity playerGravity;


	// Use this for initialization
	void Start () {
		playerHiding = false;
		distaceFromWall = 0.0f;
		playerGravity = GetComponent<PlayerGravity> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.W)) {
			playerGravity.setHidng(true);
			playerHiding = true;
		} else {
			playerGravity.setHidng(false);
			playerHiding = false;
		}

	}

	void OnTriggerStay(Collider trigger){

		if (trigger.gameObject.tag == "HidingSpot") {

			if(playerHiding){
				if(Physics.Raycast(transform.position, -transform.forward, out ray)){
					distaceFromWall = ray.distance;
					transform.Translate(transform.forward*(distaceFromWall*(0.90f)));
				}
			}else{
				//transform.Translate(-transform.forward*distaceFromWall*1.5f);
				distaceFromWall = 0;
			}
		}
	}

	void OnTriggerExit(){
		playerHiding = false;
	}

	public bool getPlayerHiding(){return playerHiding;}
}
