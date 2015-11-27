using UnityEngine;
using System.Collections;

public class NPCStats : MonoBehaviour {
	public float health;
	public float detectionRange;
	public float damage;
	public float origSpeed;
	public float speed;
	public float timer;
	public float timerMax;
	public bool timerOn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void applyDamage(float amount)
	{
		health -= amount;
		if (health <= 0) {
			//insert animation here
			Destroy (gameObject);
		}

	}

	/*
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") {
			Debug.Log ("The mummy hit you");
			Ray ray = new Ray(transform.position, col.gameObject.transform.position);
			RaycastHit rayHit;

			Physics.Raycast(ray, out rayHit);

			Vector3 normal = rayHit.normal;
			normal = rayHit.transform.TransformDirection (normal);

			if(normal == gameObject.transform.right)
			{
				Debug.Log ("MUMMY - Hit from front");
				//col.gameObject.GetComponent<characterStats>().applyDamage (damage, new Vector3(-4, 0, 0));
			}
			else if(normal == -gameObject.transform.right)
			{
				Debug.Log ("MUMMY - Hit from Rear");
				//col.gameObject.GetComponent<characterStats>().applyDamage (damage, new Vector3(1, 0, 0));
			}
			else if(normal == -gameObject.transform.up)
			{
				Debug.Log ("MUMMY - Hit from bottom");
				//col.gameObject.GetComponent<characterStats>().applyDamage (damage, new Vector3(0, 3, 0));
			}
			else if(normal == gameObject.transform.up)
			{
				Debug.Log ("MUMMY - Hit from top");
				//col.gameObject.GetComponent<characterStats>().applyDamage (damage, new Vector3(0, 3, 0));
			}
			else{
				Debug.Log ("MUMMY - unknown hit direction");

			}
	

		}
	}*/
	public void stun(float time)
	{
		timer = 0f;
		timerMax = time;
		timerOn = true;
		origSpeed = speed;
		speed = 0f;
	}
	void Update () {
		if (timerOn) {
			timer += Time.deltaTime;
			if(timer>timerMax)
			{
				speed = origSpeed;
				Debug.Log ("target unstunned");
			}
		}
	}
}
