using UnityEngine;
using System.Collections;

public class fireProjectile : MonoBehaviour {
	

<<<<<<< HEAD

	void Start () {
=======
	float speed;
	GameObject projectileBase;
	private GameObject player;

	void Start () {
		projectileBase = Resources.Load ("projectileBasic") as GameObject;
		float speed = projectileBase.GetComponent<projectileAttributes> ().speed;
		player = GameObject.Find("NewPlayer");
>>>>>>> 943b04657f5ed962477778362c48d94276a53f04
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			//Debug.log ("FIRED");
			int weaponSelected = player.GetComponent<characterStats>().weaponSelected;
			if(weaponSelected==0){
<<<<<<< HEAD
				GameObject projectile = Resources.Load ("projectileBasic") as GameObject;
				float speed = projectile.GetComponent<projectileAttributes> ().speed;
				if(GetComponent<characterStats>().baseAmmo>0){
					GetComponent<characterStats>().baseAmmo--;
					GameObject projClone = Instantiate(projectile, transform.position + new Vector3(2, 0, 0), transform.rotation) as GameObject;
=======
				if(player.GetComponent<characterStats>().baseAmmo>0){
					player.GetComponent<characterStats>().baseAmmo--;
					GameObject projClone = Instantiate(projectileBase, transform.position, transform.rotation) as GameObject;
>>>>>>> 943b04657f5ed962477778362c48d94276a53f04
					Rigidbody rb = projClone.GetComponent<Rigidbody>();
					rb.velocity += -transform.right*20;
					Destroy(projClone, 5f);
				}
				else{
					//No basic ammo!
				}
			}
			else if(weaponSelected==1){
<<<<<<< HEAD
				Debug.Log ("Fired stun projectile");
				GameObject projectile = Resources.Load ("projectileStun") as GameObject;
				float speed = projectile.GetComponent<projectileAttributes> ().speed;
				if(GetComponent<characterStats>().stunAmmo>0){
					GetComponent<characterStats>().stunAmmo--;
					GameObject projClone = Instantiate(projectile, transform.position + new Vector3(2, 0, 0), transform.rotation) as GameObject;
=======
				if(player.GetComponent<characterStats>().stunAmmo>0){
					player.GetComponent<characterStats>().stunAmmo--;
					GameObject projClone = Instantiate(projectileBase, transform.position, transform.rotation) as GameObject;
>>>>>>> 943b04657f5ed962477778362c48d94276a53f04
					Rigidbody rb = projClone.GetComponent<Rigidbody>();
					rb.velocity +=  -transform.right*20;
					Destroy(projClone, 5f);
				}
				else{
					//No stun ammo!
				}
			}
			else if(weaponSelected==2){
<<<<<<< HEAD
				GameObject projectile = Resources.Load ("projectileDistract") as GameObject;
				float speed = projectile.GetComponent<projectileAttributes> ().speed;
				if(GetComponent<characterStats>().distractAmmo>0){
					GetComponent<characterStats>().distractAmmo--;
					GameObject projClone = Instantiate(projectile, transform.position + new Vector3(2, 0, 0), transform.rotation) as GameObject;
=======
				if(player.GetComponent<characterStats>().distractAmmo>0){
					player.GetComponent<characterStats>().distractAmmo--;
					GameObject projClone = Instantiate(projectileBase, transform.position, transform.rotation) as GameObject;
>>>>>>> 943b04657f5ed962477778362c48d94276a53f04
					Rigidbody rb = projClone.GetComponent<Rigidbody>();
					rb.velocity +=  -transform.right*20;
					Destroy(projClone, 5f);
				}
				else{
					//No distract ammo!
				}
			}

		}
	}
}
