using UnityEngine;
using System.Collections;

public class characterStats : MonoBehaviour {

	public float health = 10;
	public float speed = 0.25f;
	public float damage = 1;
	public float detection = 0;
	public int baseAmmo = 10;
	public int stunAmmo = 5;
	public int distractAmmo = 0;
	public int weaponSelected = 0;
	//Check maxAmmo whever adding ammo from pickup
	public int maxAmmo = 10;

	// Use this for initialization
	void Start () {
		
	}
	public void applyDamage(float damage, Vector3 force)
	{
		transform.position = transform.position + force;
		health -= damage;
		if (health <= 0) {
			Die ();
		}
	}
	void OnControllerColliderHit (ControllerColliderHit hit)
	{

		if(hit.gameObject.tag == "Mummy")
		{
			Debug.Log ("Hit the mummy");

			Ray ray = new Ray(transform.position, transform.position);
			RaycastHit rayHit;
			
			Physics.Raycast(ray, out rayHit);
			Debug.Log ("Ray hit:"+ rayHit);
			Vector3 normal = rayHit.normal;
			normal = rayHit.transform.TransformDirection (normal);
			//if(rayHit.exists){
				if(normal == gameObject.transform.forward)
				{
					Debug.Log ("Hit from front");
					applyDamage (damage, new Vector3(-1, 0, 0));
				}
				else if(normal == -gameObject.transform.forward)
				{
					Debug.Log ("Hit from Rear");
					applyDamage (damage, new Vector3(1, 0, 0));
				}
				else if(normal == -gameObject.transform.up)
				{
					Debug.Log ("Hit from Bellow");
					applyDamage (damage, new Vector3(0, 3, 0));
				}
				else if(normal == gameObject.transform.up)
				{
					Debug.Log ("Hit from Above");
					applyDamage (damage, new Vector3(0, 3, 0));
				}
			/*}
			else{
				Debug.Log ("No RayHit Detected");
			}*/
		}
	}

	void Die() {
		Application.LoadLevel(Application.loadedLevel);
		
	}

	void Update () {
		if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey (KeyCode.Alpha1)) {
			weaponSelected = 0;
			Debug.Log ("Weapon 1 selected");
		} else if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey (KeyCode.Alpha2)) {
			weaponSelected = 1;
			Debug.Log ("Weapon 2 selected");
		} else if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey (KeyCode.Alpha3)) {
			weaponSelected = 2;
			Debug.Log ("Weapon 3 selected");
		}

	}

}
