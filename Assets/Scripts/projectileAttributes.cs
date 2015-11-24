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
				Debug.Log (col.gameObject.tag + " speed = " + col.gameObject.GetComponent<NPCStats>().speed);
				effectTick ("stun", col.gameObject);
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

	IEnumerator effectTick(string effect, GameObject affectedObject)
	{
		if (effect == "stun") {
			yield return new WaitForSeconds (3f);
			affectedObject.GetComponent<NPCStats>().speed = affectedObject.GetComponent<NPCStats>().speed*3;
			Debug.Log (affectedObject.tag + " speed = " + affectedObject.GetComponent<NPCStats>().speed);
		} else if (effect == "distract") {
			//distract effect
		}
	}

}
