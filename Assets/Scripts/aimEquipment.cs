using UnityEngine;
using System.Collections;

public class aimEquipment : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftBracket)) {
			Debug.Log ("Aiming up...");
			transform.Rotate(-Vector3.forward);
		}
		else if (Input.GetKey (KeyCode.RightBracket)) {
			Debug.Log ("Aiming down...");
			transform.Rotate(Vector3.forward);
		}
	}
}
