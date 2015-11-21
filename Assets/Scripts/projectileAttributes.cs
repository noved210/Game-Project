using UnityEngine;
using System.Collections;

public class projectileAttributes : MonoBehaviour {
	public float speed;
	//Rigidbody rb = GameObject.GetComponent<Rigidbody>();
	public float damage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col)
	{

		if(col.gameObject.GetComponent<characterStats>())
		{
			col.gameObject.GetComponent<characterStats>().applyDamage(damage);
			//Debug.log("Target Health:" + col.gameObject.GetComponent<characterStats>().health);
			Destroy (gameObject);
		}
		Destroy (gameObject);
	}
}
