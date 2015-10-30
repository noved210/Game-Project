using UnityEngine;
using System.Collections;

public class ProjectileMover : MonoBehaviour {

	public float speed = 1;
	// Use this for initialization
	void Start () {
		Rigidbody rb = gameObject.GetComponent<Rigidbody>();
		rb.velocity = transform.forward * speed;
	}

}
