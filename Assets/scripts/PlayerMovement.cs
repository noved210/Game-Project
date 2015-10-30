using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	private CharacterController player;
	private bool leftDirection, rightDirection;
	//run up is the length in time in seconds that it will take for the player to reach full speed and come to a stop
	public float speed, maxSpeed, runUp, runDown;
	// Use this for initialization
	void Start () {
		player = gameObject.GetComponent<CharacterController> ();
		leftDirection = false;
		rightDirection = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey ("left")) {
			Debug.Log("left");
			leftDirection = true;
			rightDirection = false;
			player.Move (Vector2.left * -speedUp());
		} else if (Input.GetKey ("right")) {
			Debug.Log("right");
			rightDirection = true;
			leftDirection = false;
			player.Move(Vector2.right*speedUp());
		}
		else{
			if(leftDirection){
				player.Move(Vector2.left*-speedDown());
			}else if(rightDirection){
				player.Move(Vector2.right*speedDown());
			}
		}

	}

	float speedUp(){
		float currentSpeed = speed;
		if (currentSpeed < maxSpeed) {
			currentSpeed += (maxSpeed * Time.deltaTime)*runUp;
		}
		return currentSpeed;
	}

	float speedDown(){
		float currentSpeed = speed;
		if (currentSpeed > 0) {
			currentSpeed -= (maxSpeed * Time.deltaTime) * runDown;
		} else {
			currentSpeed = 0;
			leftDirection = false;
			rightDirection = false;
		}
		return currentSpeed;
	}
}
