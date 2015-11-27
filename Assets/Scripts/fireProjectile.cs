using UnityEngine;
using System.Collections;

public class fireProjectile : MonoBehaviour {

	float speed;
	GameObject projectileBase;
	GameObject player;
	GameObject projClone;

	void Start () {
		projectileBase = Resources.Load ("projectileBasic") as GameObject;
		speed = projectileBase.GetComponent<projectileAttributes> ().speed;
		player = GameObject.Find("NewPlayer");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			//Debug.log ("FIRED");
			int weaponSelected = player.GetComponent<characterStats>().weaponSelected;
			if(weaponSelected==0){
				GameObject projectile = Resources.Load ("projectileBasic") as GameObject;
				speed = projectile.GetComponent<projectileAttributes> ().speed;
				if(player.GetComponent<characterStats>().baseAmmo>0){
					player.GetComponent<characterStats>().baseAmmo--;
					projClone = Instantiate(projectile,  transform.position, transform.rotation) as GameObject;
					Rigidbody rb = projClone.GetComponent<Rigidbody>();
					rb.velocity += -transform.right*speed;
					Destroy(projClone, 5f);
				}
				else{
					//No basic ammo!
				}
			}
			else if(weaponSelected==1){
				Debug.Log ("Stun ammo used!");
				GameObject projectile = Resources.Load ("projectileStun") as GameObject;
				speed = projectile.GetComponent<projectileAttributes> ().speed;
				Debug.Log ("Speed:" + projectile.GetComponent<projectileAttributes> ().speed);
				Debug.Log ("Ammo: " + player.GetComponent<characterStats>().stunAmmo);
				if(player.GetComponent<characterStats>().stunAmmo>0){
					player.GetComponent<characterStats>().stunAmmo--;
					projClone = Instantiate(projectile,  transform.position, transform.rotation) as GameObject;
					Rigidbody rb = projClone.GetComponent<Rigidbody>();
					rb.velocity += -transform.right*speed;
					Destroy(projClone, 5f);
				}
				else{
					//No basic ammo!
				}
			}

			else if(weaponSelected==2){
				GameObject projectile = Resources.Load ("projectileDistract") as GameObject;
				speed = projectile.GetComponent<projectileAttributes> ().speed;
				if(player.GetComponent<characterStats>().distractAmmo>0){
					player.GetComponent<characterStats>().distractAmmo--;
					projClone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
					Rigidbody rb = projClone.GetComponent<Rigidbody>();
					rb.velocity +=  -transform.right*speed;
					Destroy(projClone, 5f);
				}
				else{
					//No distract ammo!
				}
			}

		}
	}
}


