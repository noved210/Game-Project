using UnityEngine;
using System.Collections;

public class LeverActions : MonoBehaviour {

	public GameObject[] controlledObjects;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeObjectsStates(){
		for(int i = 0; i < controlledObjects.Length; i++){
			controlledObjects[i].GetComponent<TwoStatObj>().changeState();
		}
	}
}
