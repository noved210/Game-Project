using UnityEngine;
using System.Collections;

public class DrillAnimation : MonoBehaviour {

	public float drillSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (drillSpeed*Time.deltaTime, 0, 0);
	}
}
