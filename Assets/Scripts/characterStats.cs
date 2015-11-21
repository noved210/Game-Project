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
			Die ();
		}
	}
	void OnControllerColliderHit (ControllerColliderHit col)
	{
		//Debug.log("PlayerCollision detected");

		if(col.gameObject.tag == "Mummy")
		{
			Debug.Log("PlayerCollision detected");
			//applyDamage(col.gameObject.GetComponent<NPCStats>().damage);
			transform.position = transform.position - (new Vector3(1, 0, 0));
		}
	}

	void Die() {
		Application.LoadLevel(Application.loadedLevel);
		
	}
	// Update is called once per frame
	void Update () {
	
	}
}
