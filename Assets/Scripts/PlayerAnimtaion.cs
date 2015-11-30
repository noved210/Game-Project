using UnityEngine;
using System.Collections;

public class PlayerAnimtaion : MonoBehaviour {

	private Animation animation;
	private Vector3 lastPosition;


	// Use this for initialization
	void Start () {
		animation = GetComponent<Animation> ();
		//animation ["PlayerWalking"].speed = 1;
		//animation ["PlayerRunning"].speed = 2;
	}
	
	// Update is called once per frame
	void Update () {

		if ((Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.A)) && !Input.GetKey(KeyCode.LeftShift)) {
			animation.Play ("PlayerWalking");
			//animation.clip.frameRate = 30;
			//lastPosition = transform.position;
		}else if((Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.A))&& Input.GetKey(KeyCode.LeftShift)){
			animation.Play ("PlayerRunning");
			animation["PlayerRunning"].speed = 2;
			//animation.clip.frameRate = 120;
		} else {
			//if(!animation.IsPlaying("idle")){
				animation.Play("idle");
				//transform.position = lastPosition;
			//}
		}
	}
}
