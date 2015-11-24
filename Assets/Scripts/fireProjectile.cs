using UnityEngine;
using System.Collections;

public class fireProjectile : MonoBehaviour {

	float speed;
	GameObject projectileBase;
	private GameObject player;

	void Start () {
		projectileBase = Resources.Load ("projectileBasic") as GameObject;
		float speed = projectileBase.GetComponent<projectileAttributes> ().speed;
		player = GameObject.Find("NewPlayer");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			//Debug.log ("FIRED");
			int weaponSelected = player.GetComponent<characterStats>().weaponSelected;
			if(weaponSelected==0){
				if(player.GetComponent<characterStats>().baseAmmo>0){
					player.GetComponent<characterStats>().baseAmmo--;
					GameObject projClone = Instantiate(projectileBase, transform.position, transform.rotation) as GameObject;
					Rigidbody rb = projClone.GetComponent<Rigidbody>();
					rb.velocity += -transform.right*20;
					Destroy(projClone, 5f);
				}
				else{
					//No basic ammo!
				}
			}
			else if(weaponSelected==1){
				if(player.GetComponent<characterStats>().stunAmmo>0){
					player.GetComponent<characterStats>().stunAmmo--;
					GameObject projClone = Instantiate(projectileBase, transform.position, transform.rotation) as GameObject;
					Rigidbody rb = projClone.GetComponent<Rigidbody>();
					rb.velocity +=  -transform.right*20;
					Destroy(projClone, 5f);
				}
				else{
					//No stun ammo!
				}
			}
			else if(weaponSelected==2){
				if(player.GetComponent<characterStats>().distractAmmo>0){
					player.GetComponent<characterStats>().distractAmmo--;
					GameObject projClone = Instantiate(projectileBase, transform.position, transform.rotation) as GameObject;
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
