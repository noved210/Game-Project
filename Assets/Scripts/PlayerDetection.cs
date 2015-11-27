using UnityEngine;
using System.Collections;

public class PlayerDetection : MonoBehaviour {

	private RaycastHit ray, behind;
	private bool playerSeen = false, playerInView = false, playerBehind = false;
	private Vector3 playerPosition;

	public float distance = 1.0f;
	public float fov = 30f;
	public float attackRange = 20f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Debug.DrawRay(transform.position, transform.up*distance, Color.red);
		Debug.DrawRay(transform.position, -transform.up*(distance/2), Color.red);
		//Debug.log("Draw Ray");

		playerInView = false;


		//create raycast in the forward direction at theta
		if (Physics.Raycast (transform.position, transform.up, out ray)) {

			//Debug.Log("Hitting something " + ray.collider.gameObject.tag);
			//if the ray hits the player then set the player to be seen and currently in view
			if(ray.collider.gameObject.tag == "Player" && ray.distance < distance){

				//Debug.Log("Player being seen");
				playerSeen = true;
				playerInView = true;
				playerPosition = ray.collider.gameObject.transform.position;
				Debug.Log("Ray distance :" + ray.distance);

			}else{
				//playerInView = false;
				//Debug.Log("Player not seen");
			}

		}

		//create raycast in the forward direction at theta
		if (Physics.Raycast (transform.position, -transform.up , out behind)) {


			//Debug.Log("Hitting something " + behind.collider.gameObject.tag);

			//Debug.log("Hitting something " + ray.collider.gameObject.tag);
			//playerInView = false;

			//if the ray hits the player then set the player to be seen and currently in view
			if(behind.collider.gameObject.tag == "Player" && behind.distance < distance/2){


				//Debug.Log("player seen from behind");

				//Debug.log("player seen from behind and its the player!! turn around");
				//player behind is true
				playerBehind = true;
				playerSeen = true;
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
	public bool getBehind(){return playerBehind;}
	public void enemyTurned(){playerBehind = false;}
}
