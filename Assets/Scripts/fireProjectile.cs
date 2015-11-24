using UnityEngine;
using System.Collections;

public class fireProjectile : MonoBehaviour {
	


	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			//Debug.log ("FIRED");
			int weaponSelected = GetComponent<characterStats>().weaponSelected;
			if(weaponSelected==0){
				GameObject projectile = Resources.Load ("projectileBasic") as GameObject;
				float speed = projectile.GetComponent<projectileAttributes> ().speed;
				if(GetComponent<characterStats>().baseAmmo>0){
					GetComponent<characterStats>().baseAmmo--;
					GameObject projClone = Instantiate(projectile, transform.position + new Vector3(2, 0, 0), transform.rotation) as GameObject;
					Rigidbody rb = projClone.GetComponent<Rigidbody>();
					rb.velocity +=  new Vector3(20, 0, 0);
					Destroy(projClone, 5f);
				}
				else{
					//No basic ammo!
				}
			}
			else if(weaponSelected==1){
				Debug.Log ("Fired stun projectile");
				GameObject projectile = Resources.Load ("projectileStun") as GameObject;
				float speed = projectile.GetComponent<projectileAttributes> ().speed;
				if(GetComponent<characterStats>().stunAmmo>0){
					GetComponent<characterStats>().stunAmmo--;
					GameObject projClone = Instantiate(projectile, transform.position + new Vector3(2, 0, 0), transform.rotation) as GameObject;
					Rigidbody rb = projClone.GetComponent<Rigidbody>();
					rb.velocity +=  new Vector3(20, 0, 0);
					Destroy(projClone, 5f);
				}
				else{
					//No stun ammo!
				}
			}
			else if(weaponSelected==2){
				GameObject projectile = Resources.Load ("projectileDistract") as GameObject;
				float speed = projectile.GetComponent<projectileAttributes> ().speed;
				if(GetComponent<characterStats>().distractAmmo>0){
					GetComponent<characterStats>().distractAmmo--;
					GameObject projClone = Instantiate(projectile, transform.position + new Vector3(2, 0, 0), transform.rotation) as GameObject;
					Rigidbody rb = projClone.GetComponent<Rigidbody>();
					rb.velocity +=  new Vector3(20, 0, 0);
					Destroy(projClone, 5f);
				}
				else{
					//No distract ammo!
				}
			}

		}
	}
}
