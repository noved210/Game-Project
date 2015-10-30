using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
	public float strength = 1; 

	
	void OnCollisionEnter( Collision collision )
	{
		var DamageScript = collision.gameObject.GetComponent<CharacterStats> ();
		DamageScript.DealDamage (strength);
	}

}
