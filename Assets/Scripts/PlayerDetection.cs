using UnityEngine;
using System.Collections;

public class PlayerDetection : MonoBehaviour {

	private RaycastHit ray;
	private bool playerSeen = false, playerInView = false;
	private Vector3 playerPosition;

	public float distance = 1.0f;
	public float fov = 30f;
	public float attackRange = 20f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Debug.DrawRay(transform.position, -transform.right*distance, Color.red);
		//Debug.Log("Draw Ray");

		//create raycast in the forward direction at theta
		if (Physics.Raycast (transform.position, -transform.right*distance , out ray)) {

			//Debug.Log("Hitting something " + ray.collider.gameObject.tag);
			//playerInView = false;
			//if the ray hits the player then set the player to be seen and currently in view
			if(ray.collider.gameObject.tag == "Player" && ray.distance <= distance){
				playerSeen = true;
				playerInView = true;
				playerPosition = ray.collider.gameObject.transform.position;
				//attack the player
				if(ray.distance < attackRange){

				}
				//Debug.Log("Player seen");
			}else{
				playerInView = false;
				//Debug.Log("Player not seen");
			}

		}

		
	}




	//ensure that whatever is looking for the player is in the middle of the hallway space
	//for this I will use a OnTriggerStay to find the middle of the hallway object 

	public void setSeen(bool playerSeen){this.playerSeen = playerSeen;}
	public bool getSeen(){return playerSeen;}
	public void setInView(bool playerInView){this.playerInView = playerInView;}
	public bool getInView(){return playerInView;}
	public Vector3 getPlayerPosition(){return playerPosition;}
}
