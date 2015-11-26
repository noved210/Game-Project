using UnityEngine;
using System.Collections;

public class SpawnEnemyOne : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider trigger){
		//spawn an enemy to avoid
		if (trigger.gameObject.tag == "GameController") {
			(GameObject.Find("MummyEnemyOne") as GameObject).GetComponent<NPCBehaviour>().notActiveAtSTart = false;
		}
	}	                                   
}
