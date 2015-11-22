using UnityEngine;
using System.Collections;

public class projectileAttributes : MonoBehaviour {
	public float speed;
	//Rigidbody rb = GameObject.GetComponent<Rigidbody>();
	public float damage;
	// Use this for initialization
	public string type = "base";
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col)
	{
		Debug.Log ("Projectile Collision Detected");
		string typeTrue = System.Text.RegularExpressions.Regex.Replace (type, "(A-Z)", "(a-z)");
		Debug.Log ("projectileTyle: " + typeTrue);
		if(col.gameObject.GetComponent<NPCStats>())
		{
			if(typeTrue=="base"){
				col.gameObject.GetComponent<NPCStats>().applyDamage(damage);
			}
			else if (typeTrue=="stun")
			{
				col.gameObject.GetComponent<NPCStats>().speed = col.gameObject.GetComponent<NPCStats>().speed/3;
			}
			else if(typeTrue=="distract")
			{

			}
			
			//Debug.log("Target Health:" + col.gameObject.GetComponent<characterStats>().health);
			Destroy (gameObject);
		}
		Destroy (gameObject);
	}
}
