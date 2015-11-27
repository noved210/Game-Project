using UnityEngine;
using System.Collections;

public class CameraPlayerLock : MonoBehaviour {

	public GameObject player;
	private Vector3 thisPosition;
	private PlayerHidingMechanic playerHidingMech;

	// Use this for initialization
	void Start () {
		thisPosition = transform.position;
		playerHidingMech = player.GetComponent<PlayerHidingMechanic> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (!playerHidingMech.onStairs)
			gameObject.transform.position = new Vector3 (player.transform.position.x, thisPosition.y, thisPosition.z);
		else if(playerHidingMech.onStairs) {
			if(!(player.transform.position.y < thisPosition.y))
				gameObject.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, thisPosition.z);
			else
				gameObject.transform.position = new Vector3 (player.transform.position.x, thisPosition.y, thisPosition.z);

		}

	}
}
