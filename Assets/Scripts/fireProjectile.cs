using UnityEngine;
using System.Collections;

public class fireProjectile : MonoBehaviour {

	float speed;
	GameObject projectileBase;

	void Start () {
		projectileBase = Resources.Load ("projectileBasic") as GameObject;
		float speed = projectileBase.GetComponent<projectileAttributes> ().speed;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("FIRED");
			GameObject projClone = Instantiate(projectileBase, transform.position + new Vector3(2, 0, 0), transform.rotation) as GameObject;
			Rigidbody rb = projClone.GetComponent<Rigidbody>();
			rb.velocity +=  new Vector3(20, 0, 0);
			Destroy(projClone, 5f);
		}
	}
}
