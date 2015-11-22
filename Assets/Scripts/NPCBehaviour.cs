using UnityEngine;
using System.Collections;

public class NPCBehaviour : MonoBehaviour {

	private PlayerDetection playerDetection;
	private Vector3 playerPosition, fromPosition;
	private int currentDestination;
	private bool forwards;
	private bool shouldTurn;
	private bool atVector;
	private bool playerInSpace = false;
	private float waitTimer = 0.0f;
	private float enemyPositionTimer = 0.0f; 
	private Vector3[] destinationList;
	private int travelDirection;

	public GameObject[] destinationNodes;
	public float enemySpeed = 0.0f;
	public float waitAtDestinationTime = 1.0f;


	//NPC will go backwards if the player jumps while the NPC is looking at the player
	//


	//this is the distance that will be 'close enough' for the NPC to get to the last seen player position
	//MAY NEED TO BE TWEEKED FOR BETTER EFFECTS
	private float closeEnough = 1.0f;
	
	// Use this for initialization
	void Start () {
		playerDetection = GetComponentInChildren<PlayerDetection>();

		destinationList = new Vector3[destinationNodes.Length];
		for (int i = 0; i < destinationList.Length; i++) {
			destinationList[i] = destinationNodes[i].transform.position;
		}

		transform.position = destinationList[getClosestPoint()];

		//Debug.log (gameObject.transform.position + " " + destinationList [getClosestPoint ()]);
		//Debug.log(Vector3.Distance (gameObject.transform.position, destinationList [currentDestination]));

		fromPosition = transform.position;

		atVector = true;
		playerPosition = Vector3.zero;
		forwards = true;
		currentDestination = 0;
		waitTimer = 0.0f;

		gameObject.transform.LookAt (destinationList[currentDestination]);
	}
	
	// Update is called once per frame
	void Update () {

		//if the player has been seen and is currently in view

		//Debug.log (playerDetection.getSeen() + " " + playerDetection.getInView());
		enemyPositionTimer += enemySpeed * Time.deltaTime;
		if (playerDetection.getSeen () && playerDetection.getInView ()) {

			//Debug.log("Seeing player");

			//Debug.log("Currently seen " + Vector3.Distance (gameObject.transform.position, playerPosition));
			//Debug.log(gameObject.transform.position + " " + playerPosition);
			waitTimer = 0;
			//get the players position because it is being seen
			playerPosition = playerDetection.getPlayerPosition ();
			//gameObject.transform.LookAt (playerPosition);
			//gameObject.transform.Rotate(-145, 0, 180);

			if(transform.position.x - playerPosition.x < closeEnough && playerPosition.x - transform.position.x < closeEnough){
				//Debug.log("attacking player");
			}else{
				//move the NPC towards the player at it's speed
				Vector3 movement = (transform.position - playerPosition);
				movement.z = 0;
				movement.x = 0;
				transform.Translate(movement*enemySpeed);
				/*the NPC is moving towards the player. '-1' indicates that the NPC is not moving to any of the playerDestinations 
				and needs to fin the closet one to move to when it is no longer tracking the player.*/
				currentDestination = -1;
			}

		} else if (playerDetection.getSeen () && !playerDetection.getInView ()) {

			//Debug.log("Looking for player");

			//Debug.log("Currently looking " + Vector3.Distance (gameObject.transform.position, playerPosition));
			//Debug.log(gameObject.transform.position + " " + playerPosition);
			
			if (playerDetection.getBehind ()) {
				gameObject.transform.Rotate(0, 0, -180);
				playerDetection.enemyTurned();
			}



			//if the NPC is close enough to the player's last seen position then just wait around till the NPC 'forgets' about the player
			if (transform.position.x - playerPosition.x < closeEnough && playerPosition.x - transform.position.x < closeEnough) {
				//Debug.log("waiting to forget " + waitTimer);
				//wait for the NPC to forget
				waitTimer += Time.deltaTime;
				if (waitTimer > waitAtDestinationTime*3) {
					//Debug.log("player forgotten");
					//set the 'setSeen' variable to false because the NPC forgot about the player
					waitTimer = 0;
					playerDetection.setSeen (false);
					enemyPositionTimer = 0;
				}
			} else {
				//move the NPC towards the player at it's speed
				/*the NPC is moving towards the player. '-1' indicates that the NPC is not moving to any of the playerDestinations 
				and needs to fin the closet one to move to when it is no longer tracking the player.*/
				//move the NPC towards the player at it's speed
				Vector3 movement = (transform.position - playerPosition);
				movement.z = 0;
				movement.x = 0;
				transform.Translate(movement*enemySpeed);
				/*the NPC is moving towards the player. '-1' indicates that the NPC is not moving to any of the playerDestinations 
				and needs to fin the closet one to move to when it is no longer tracking the player.*/
				currentDestination = -1;
			}
		} else {

			//Debug.log("Wondering b/t spaces");

			//was at the players last position, now needs to go back to the closest node taht it can travel to
			if (currentDestination == -1) {
				currentDestination = getClosestPoint ();
				fromPosition = transform.position;
				gameObject.transform.LookAt (destinationList[currentDestination]);
				gameObject.transform.Rotate(-90, 0, 180);
			}

			//move to the node that it should
			transform.position = Vector3.Lerp (fromPosition, destinationList [currentDestination], enemyPositionTimer);
			//gameObject.transform.LookAt (destinationList[currentDestination]);
			//gameObject.transform.Rotate(-90, 0, 180);

			//if the NPC has reached the node that it has been moving to change the node it is moving towards
			if (Vector3.Distance (transform.position, destinationList [currentDestination]) < closeEnough) {

				fromPosition = transform.position;
				waitTimer += Time.deltaTime;

				//Debug.log("close enough");

				if (waitTimer > waitAtDestinationTime) {
					//set the 'setSeen' variable to false because the NPC forgot about the player
					playerDetection.setSeen (false);
					waitTimer = 0;
					fromPosition = transform.position;

					if (forwards) {
					
						//Debug.log ("Go forwards...");
					
						currentDestination++;
						if (currentDestination >= destinationList.Length) {
							//Debug.log ("..I mean backwards");
							forwards = !forwards;
							currentDestination -= 2;
						}

						enemyPositionTimer = 0;
					} else {
					
						//Debug.log ("Go backwards...");
					
						currentDestination--;
						if (currentDestination < 0) {
							//Debug.log ("..I mean forwards");
						
							forwards = !forwards;
							currentDestination += 2;
						}
						enemyPositionTimer = 0;
					}



				}
			}
		}

	}

	//Get the point to the NCP
	int getClosestPoint(){

		float distance = Vector3.Distance(gameObject.transform.position, destinationList[0]);
		int index = 0;

		for (int i = 1; i < destinationList.Length; i++) {
			if(distance > Vector3.Distance(gameObject.transform.position, destinationList[i])){
				index = i;
				distance = Vector3.Distance(gameObject.transform.position, destinationList[i]);
			}
		}

		return index;
	}
	/*
	void OnTriggerEnter(Collider trigger){

		if (trigger.gameObject.tag == "PlayerSpace") {
			playerInSpace = true;
			//get if the player is behind the enemy and turn the enemy around
			gameObject.transform.LookAt(trigger.gameObject.transform.position);
			gameObject.transform.Rotate(-90, 0, 180);
		}
	}

	void OnTriggerExit(Collider trigger){
		
		if (trigger.gameObject.tag == "PlayerSpace") {
			playerInSpace = false;
		}
	}
	*/

}
