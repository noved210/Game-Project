using UnityEngine;
using System.Collections;

public class fireProjectile : MonoBehaviour {

	float speed;
	GameObject projectileBase;

	void Start () {
		projectileBase = Resources.Load ("projectileBasic") as GameObject;
		float speed = projectileBase.GetComponent<projectileAttributes> ().speed;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			//Debug.log ("FIRED");
			int weaponSelected = GetComponent<characterStats>().weaponSelected;
			if(weaponSelected==0){
				if(GetComponent<characterStats>().baseAmmo>0){
					GetComponent<characterStats>().baseAmmo--;
					GameObject projClone = Instantiate(projectileBase, transform.position + new Vector3(2, 0, 0), transform.rotation) as GameObject;
					Rigidbody rb = projClone.GetComponent<Rigidbody>();
					rb.velocity +=  new Vector3(20, 0, 0);
					Destroy(projClone, 5f);
				}
				else{
					//No basic ammo!
				}
			}
			else if(weaponSelected==1){
				if(GetComponent<characterStats>().stunAmmo>0){
					GetComponent<characterStats>().stunAmmo--;
					GameObject projClone = Instantiate(projectileBase, transform.position + new Vector3(2, 0, 0), transform.rotation) as GameObject;
					Rigidbody rb = projClone.GetComponent<Rigidbody>();
					rb.velocity +=  new Vector3(20, 0, 0);
					Destroy(projClone, 5f);
				}
				else{
					//No stun ammo!
				}
			}
			else if(weaponSelected==2){
				if(GetComponent<characterStats>().distractAmmo>0){
					GetComponent<characterStats>().distractAmmo--;
					GameObject projClone = Instantiate(projectileBase, transform.position + new Vector3(2, 0, 0), transform.rotation) as GameObject;
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
