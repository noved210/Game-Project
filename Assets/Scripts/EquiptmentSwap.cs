﻿using UnityEngine;
using System.Collections;

public class EquiptmentSwap : MonoBehaviour {

	public GameObject[] equipment;
	private int currentSelection, selectionMax;
	private GameObject currentGameObject;

	// Use this for initialization
	void Start () {
		currentSelection = 0;
		selectionMax = equipment.Length;
		currentGameObject = Instantiate (equipment [currentSelection], gameObject.transform.position, gameObject.transform.rotation) as GameObject;
		currentGameObject.transform.parent = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			currentSelection++;
			if(currentSelection >= selectionMax){
				currentSelection = 0;
			}
			Destroy(currentGameObject);
			currentGameObject = Instantiate (equipment [currentSelection], gameObject.transform.position, gameObject.transform.rotation) as GameObject;
			currentGameObject.transform.parent = gameObject.transform;
		}

		else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			currentSelection--;
			if(currentSelection < 0){
				currentSelection = selectionMax;
			}
			Destroy(currentGameObject);
			currentGameObject = Instantiate (equipment [currentSelection], gameObject.transform.position, gameObject.transform.rotation) as GameObject;
			currentGameObject.transform.parent = gameObject.transform;
		}

	}
}