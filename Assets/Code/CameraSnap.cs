using UnityEngine;
using System.Collections;

public class CameraSnap : MonoBehaviour {

	//what direction is the camera currently facing (true = dow the Z-axis, false = down the X-axis)
	//all scenes should start with the camera facing down the Z-axis
	private bool cameraOrientation = true;
	private CharacterController player;
	private float timer = 1.01f;

	// Use this for initialization
	void Start () {
		player = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	//Snap the player to the center of the hallway (depth wise)
	void OnTriggerEnter(Collider trigger){
		
		if (trigger.gameObject.tag == "HallWay") {
			Vector3 hallwayPosition = trigger.gameObject.transform.position;
			if (cameraOrientation) {
				
				Debug.Log ("Direction is looking down the Z axis " + hallwayPosition.z + " " + gameObject.transform.position.z);
				
				if (hallwayPosition.z > gameObject.transform.position.z) {
					Debug.Log ("player behind middle of hallway");
					gameObject.transform.Translate (new Vector3 (0, 0, hallwayPosition.z - player.transform.position.z));
				} else if (hallwayPosition.z < gameObject.transform.position.z) {
					Debug.Log ("player in front of middle of hallway");
					gameObject.transform.Translate (new Vector3 (0, 0, hallwayPosition.z - player.transform.position.z));
				}
			} else {
				
				Debug.Log ("Direction is looking down the X axis " + hallwayPosition.x + " " + gameObject.transform.position.x);
				
				if (hallwayPosition.x > gameObject.transform.position.x) {
					Debug.Log ("player behind middle of hallway");
					gameObject.transform.Translate (new Vector3 (0, 0, gameObject.transform.position.x - hallwayPosition.x));
				} else if (hallwayPosition.x < gameObject.transform.position.x) {
					Debug.Log ("player in front of middle of hallway");
					gameObject.transform.Translate (new Vector3 (0, 0, gameObject.transform.position.x - hallwayPosition.x));
				}
			}
		}
	}
	void OnTriggerStay(Collider trigger){
		if (trigger.gameObject.tag == "CameraSnapPoint") {
			if (Input.GetKeyDown (KeyCode.W)) {
				if (cameraOrientation) {
					cameraOrientation = !cameraOrientation;
					timer = 0;
					gameObject.transform.Rotate (new Vector3 (0, -90, 0));
				} else {
					cameraOrientation = !cameraOrientation;
					timer = 0;
					gameObject.transform.Rotate (new Vector3 (0, 90, 0));
				}
			}
		}
	}
}
