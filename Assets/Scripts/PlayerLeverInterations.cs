using UnityEngine;
using System.Collections;

public class PlayerLeverInterations : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider trigger){
		if (trigger.gameObject.tag == "Button") {

			//Debug.Log("In button space");

			if(Input.GetKeyDown(KeyCode.E)){
				trigger.gameObject.GetComponent<LeverActions>().changeObjectsStates();
				Debug.Log("Clicked button");
			}
		}
	}
}
