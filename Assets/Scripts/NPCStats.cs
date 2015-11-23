using UnityEngine;
using System.Collections;

public class NPCStats : MonoBehaviour {
	public float health;
	public float detectionRange;
	public float damage;
	public float speed;

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
	public void applyStun(){

	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") {
			Debug.Log ("The mummy hit you");
			Ray ray = new Ray(transform.position, col.gameObject.transform.position);
			RaycastHit rayHit;

			Physics.Raycast(ray, out rayHit);

			Vector3 normal = rayHit.normal;
			normal = rayHit.transform.TransformDirection (normal);

			if(normal == gameObject.transform.forward)
			{
				Debug.Log ("MUMMY - Hit from front");
				col.gameObject.GetComponent<characterStats>().applyDamage (damage, new Vector3(-4, 0, 0));
			}
			else if(normal == -gameObject.transform.forward)
			{
				Debug.Log ("MUMMY - Hit from Rear");
				col.gameObject.GetComponent<characterStats>().applyDamage (damage, new Vector3(1, 0, 0));
			}
			else if(normal == -gameObject.transform.up)
			{
				Debug.Log ("MUMMY - Hit from bottom");
				col.gameObject.GetComponent<characterStats>().applyDamage (damage, new Vector3(0, 3, 0));
			}
			else if(normal == gameObject.transform.up)
			{
				Debug.Log ("MUMMY - Hit from top");
				col.gameObject.GetComponent<characterStats>().applyDamage (damage, new Vector3(0, 3, 0));
			}
			else{
				Debug.Log ("MUMMY - unknown hit direction");

			}
	

		}
	}

	void Update () {
		
	}
}
