using UnityEngine;
using System.Collections;

public class SlideFailed : MonoBehaviour {

	CharacterController player;

	// Use this for initialization
	void Start () {
		player = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	//want only if the player gets hit from above
	void OnControllerColliderHit(ControllerColliderHit obj){
		if (obj.gameObject.tag == "SlideSpot") {
			GameObject[] objs = GameObject.FindGameObjectsWithTag("Respawn");
			transform.position = getClosestPoint(objs).transform.position;
		}
	}

	//Get the point to the NCP
	GameObject getClosestPoint(GameObject[] objs){
		
		float distance = Vector3.Distance (gameObject.transform.position, objs [0].transform.position);
		int index = 0;
		
		for (int i = 1; i < objs.Length; i++) {
			if (distance > Vector3.Distance (gameObject.transform.position, objs [i].transform.position)) {
				index = i;
				distance = Vector3.Distance (gameObject.transform.position, objs [i].transform.position);
			}
		}

		return objs [index];
	}
		

}
