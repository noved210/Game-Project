using UnityEngine;
using System.Collections;

public class projectileAttributes : MonoBehaviour {
	public float speed;
	//Rigidbody rb = GameObject.GetComponent<Rigidbody>();
	public float damage;
	private GameObject target;
	// Use this for initialization
	public string type = "base";
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter (Collision col)
	{
		target = col.gameObject;
		Debug.Log ("Projectile Collision Detected");
		string typeTrue = System.Text.RegularExpressions.Regex.Replace (type, "(A-Z)", "(a-z)");
		Debug.Log ("projectileTyle: " + typeTrue);
		if(target.GetComponent<NPCStats>())
		{
			if(typeTrue=="base"){
				target.GetComponent<NPCStats>().applyDamage(damage);
			}
			else if (typeTrue=="stun")
			{
				Debug.Log (target.tag + " speed = " + target.GetComponent<NPCStats>().speed);
				stunTarget(target, 5.1f);

			}
			else if(typeTrue=="distract")
			{
				//distraction script
			}
			
			//Debug.log("Target Health:" + col.gameObject.GetComponent<characterStats>().health);
			Destroy (gameObject);
		}
		Destroy (gameObject);
	}
	void stunTarget(GameObject target1, float time)
	{
		Debug.Log ("Target stunned");
		float timerMax = time;
		target.GetComponent<NPCStats> ().stun(timerMax);

	}
}
