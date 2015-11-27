using UnityEngine;
using System.Collections;

public class PlayerHints : MonoBehaviour {

	public float height, front, hintHeight, hintFront;
	public Sprite bubble;
	private GameObject newBubble;
	private GameObject hintHolder;
	private Sprite hint;
	private bool turned;

	// Use this for initialization
	void Start () {
		newBubble = null;
		hint = null;
		if (gameObject.transform.rotation.eulerAngles.y > 90) {
			turned = true;
		} else {
			turned = false;
		}
	}
	
	// Update is called once per frame
	void Update () {



		if (hint != null) {

			if (gameObject.transform.rotation.eulerAngles.y > 90) {
				hintHolder.transform.eulerAngles = new Vector3(0, 180, 0);	
			} else {
				hintHolder.transform.eulerAngles = new Vector3(0, 0, 0);	
			}

			hintHolder.transform.position = new Vector3 (newBubble.transform.position.x + hintFront, newBubble.transform.position.y + hintHeight, newBubble.transform.position.z - 1);
		}
		/*
		if (hint != null) {

			Debug.Log(gameObject.transform.rotation.eulerAngles.y +" "+ turned);

			//if parent is facing to the right pull the hint forwards, else push it back
			//hintHolder.transform.eulerAngles = new Vector3 (0, 1 * gameObject.transform.parent.gameObject.transform.rotation.eulerAngles.y, 0); 
			if(gameObject.transform.rotation.eulerAngles.y > 90 && turned){

				Debug.Log("Moving forwards");

				turned = false;
				hintHolder.transform.position = new Vector3(newBubble.transform.position.x, newBubble.transform.position.y, newBubble.transform.position.z + 1);
				hintHolder.transform.localScale = new Vector3(-3, 3, 3);
			}
			else if(gameObject.transform.rotation.eulerAngles.y < 90 && !turned){

				Debug.Log("Moving backwards");

				turned = true;
				hintHolder.transform.Translate(0, 0, -2);
				hintHolder.transform.localScale = new Vector3(-3, 3, 3);

			}
		}*/
	}


	void OnTriggerEnter(Collider trigger){

		if (trigger.gameObject.tag == "ButtonHint") {
			//thought bubble
			newBubble = new GameObject(gameObject.name + ":Bubble");
			SpriteRenderer spriteRenderer = newBubble.AddComponent<SpriteRenderer>();
			spriteRenderer.sprite = bubble;
			newBubble.transform.parent = transform;
			newBubble.transform.localScale = new Vector3(3, 3, 3);
			newBubble.transform.position = new Vector3(gameObject.transform.position.x + front, gameObject.transform.position.y + height, gameObject.transform.position.z);
		
			//keyboard key
			hintHolder = new GameObject(gameObject.name + ":Hint");
			SpriteRenderer spriteRendererKB = hintHolder.AddComponent<SpriteRenderer>();
			hint = trigger.gameObject.GetComponent<Hint>().hint;
			spriteRendererKB.sprite = hint;
			hintHolder.transform.parent = transform;
			hintHolder.transform.localScale = new Vector3(5, 5, 5);
			if(turned)
				hintHolder.transform.position = new Vector3(gameObject.transform.position.x + hintFront, gameObject.transform.position.y + hintHeight, gameObject.transform.position.z +2);
			else
				hintHolder.transform.position = new Vector3(gameObject.transform.position.x + hintFront, gameObject.transform.position.y + hintHeight, gameObject.transform.position.z -2);
		}

	}

	void OnTriggerExit(Collider trigger){
		
		if (trigger.gameObject.tag == "ButtonHint") {
			Destroy(GameObject.Find(gameObject.name+":Bubble"));
			Destroy(GameObject.Find(gameObject.name+":Hint"));
			hint = null;
		}
		
	}

}
