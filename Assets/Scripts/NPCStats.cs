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
	void applyDamage(float amount)
	{
		health -= amount;
		if (health <= 0) {
			//insert animation here
			Destroy (gameObject);
		}

	}
	void Update () {
		
	}
}
