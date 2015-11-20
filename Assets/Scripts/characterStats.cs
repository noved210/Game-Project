using UnityEngine;
using System.Collections;

public class characterStats : MonoBehaviour {

	public float health = 10;
	public float speed = 0.25f;
	public float damage = 1;
	public float detection = 0;

	// Use this for initialization
	void Start () {
		
	}
	public void applyDamage(float damage)
	{
		health -= damage;
		if (health <= 0) {
			if(this.name == "Player")
			{
				//playerDeath
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
	void OnControllerColliderHit (ControllerColliderHit col)
	{
		//Debug.Log("PlayerCollision detected");

		if(col.gameObject.tag == "Mummy")
		{
			col.gameObject.GetComponent<characterStats>().applyDamage(damage);
			Rigidbody rb = col.gameObject.GetComponent<BoxCollider>().attachedRigidbody;
			this.gameObject.GetComponent<CharacterController>().attachedRigidbody.velocity -=  new Vector3(5, 0, 0);
			Debug.Log("Player Health:" + col.gameObject.GetComponent<characterStats>().health);

		}


	}
	// Update is called once per frame
	void Update () {
	
	}
}
