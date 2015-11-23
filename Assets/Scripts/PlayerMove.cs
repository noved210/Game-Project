using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	private CharacterController player;
	private float e = 2.718f;
	private float currentTime = 0.0f;
	//the current speed of the player
	private float speed;
	//for direction (false = -, true = +)
	//for leftOrRight (false = left, true = right)
	private bool direction = true, leftOrRight, slide = false, turnPlayer = false;

	//Time in seconds
	public float easeTime = 1.0f;
	//adjustable value of the max speed the player will travel (left or right)
	public float maxSpeed = 3.0f;
	public float sprintSpeed = 5.0f;


	/*
	 * Functionality implemented;
	 * 
	 * 	Moving left and right relative to the players orientation (the player will always move left or right)
	 * 	
	 * 	The player can walk or sprint
	 * 
	 * 	The player can do a slide (this boosts the player to a fast speed, slowly reduces the speed of the player, they cannot accelerate anymore, 
	 * 		they must let go of the crouch (currently: 's') button to resume moving)
	 * 
	 * 	The players movment is all eased in and out (takes time to reach full speed and takes timer to slow down from full speed)
	 * 
	 */

	// Use this for initialization
	void Start () {
		player = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		//If the player is holding down slow the player down over time
		if (Input.GetKey (KeyCode.S)) {
			slide = true;
			if (Input.GetKey ("a")) {
				//rotate the player if the were facing the otehr direction
				if(!turnPlayer){
					//gameObject.transform.Rotate(0, 180, 0);
				}

				turnPlayer = true;
				leftOrRight = true;
			} else if (Input.GetKey ("d")) {
				//rotate the player if they were facing the otehr direction last
				if(turnPlayer){
					gameObject.transform.Rotate(0, -180, 0);
				}

				turnPlayer = false;
				leftOrRight = false;
			}
			if(Input.GetKey (KeyCode.LeftShift))
				speed = (sprintSpeed * interpolate (Time.deltaTime/3, true))*2;
			else
				speed = (sprintSpeed * interpolate (Time.deltaTime/3, true));

		} else {
			if (Input.GetKey (KeyCode.LeftShift)) {
				if (Input.GetKey ("a")) {

					//rotate the player if they were facing the otehr direction last
					if(!turnPlayer){
						//gameObject.transform.Rotate(0, 180, 0);
					}
					
					turnPlayer = true;

					leftOrRight = true;
					speed = sprintSpeed * interpolate (Time.deltaTime, false);
				} else if (Input.GetKey ("d")) {

					//rotate the player if they were facing the otehr direction last
					if(turnPlayer){
						gameObject.transform.Rotate(0, -180, 0);
					}
					
					turnPlayer = false;

					leftOrRight = false;
					speed = sprintSpeed * interpolate (Time.deltaTime, false);
				} else {
					speed = maxSpeed * interpolate (Time.deltaTime, true);
				}
			} else {
				if (Input.GetKey ("a")) {

					//rotate the player if they were facing the otehr direction last
					if(!turnPlayer){
						gameObject.transform.Rotate(0, 180, 0);
						turnPlayer = true;
						speed = 0;
					}
					


					leftOrRight = true;
					speed = maxSpeed * interpolate (Time.deltaTime, false);
				} else if (Input.GetKey ("d")) {

					//rotate the player if they were facing the otehr direction last
					if(turnPlayer){
						gameObject.transform.Rotate(0, -180, 0);
						turnPlayer = false;
						speed = 0;
					}
					


					leftOrRight = false;
					speed = maxSpeed * interpolate (Time.deltaTime, false);
				} else {
					speed = maxSpeed * interpolate (Time.deltaTime, true);
				}
			}
		}


		if(turnPlayer)
			player.Move (this.transform.right * speed *Time.deltaTime);
		else
			player.Move (-this.transform.right * speed *Time.deltaTime);

		Debug.Log (speed);
	}

	//Interpolation, f(x) = log(x^e)
	//The positive X-intercept; X = 1 (Y = 0); X = e^(1/e) (Y = 1)
	//Timer should  just be Time.deltaTime()
	//Will return a range from (-1) - 1

	//This function will ease into movement and ease out of movement
	float interpolate(float timer, bool stopping){

		if (!leftOrRight && !stopping && !direction) {
			currentTime -= timer;
		} else if(!leftOrRight && !stopping && direction){
			currentTime += timer;
		}else if (leftOrRight && !stopping && !direction) {
			currentTime += timer;
		}else if(leftOrRight && !stopping && direction){
			currentTime -= timer;
		}else if(stopping && currentTime > 1) {
			currentTime -= timer;
		}

		//the direction changes
		if (currentTime < 1) {
			currentTime = 1;
			direction = !direction;
			slide = false;
		} else if (currentTime > Mathf.Pow (e, 1 / e)) {
			currentTime = Mathf.Pow(e, 1/e);
		}

		if (direction) {
			return Mathf.Log(Mathf.Pow (currentTime, e));
		} else {
			return - Mathf.Log(Mathf.Pow(currentTime, e));
		}

	}

	public bool getTurnPlayer(){return turnPlayer;}

}
