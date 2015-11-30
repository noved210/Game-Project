using UnityEngine;
using System.Collections;

public class rotateCollectable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 4, 0, Space.World);
	}
}
