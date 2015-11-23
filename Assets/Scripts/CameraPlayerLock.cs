using UnityEngine;
using System.Collections;

public class CameraPlayerLock : MonoBehaviour {

	public GameObject player;
	private Vector3 thisPosition;

	// Use this for initialization
	void Start () {
		thisPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
		gameObject.transform.position = new Vector3 (player.transform.position.x, thisPosition.y, thisPosition.z);

	}
}
