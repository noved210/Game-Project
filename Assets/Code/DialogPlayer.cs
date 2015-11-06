using UnityEngine;
using System.Collections;
using System.Xml;

public class DialogPlayer : MonoBehaviour {

	public XmlDocument dialogs;
	public GameManager gameManager;
	public Sprite bubble;
	public AudioClip noise;
	public AudioClip agroNoise;

	/*
	 * -1: cutscene
	 * 0: player
	 * 1: mummy
	 * 2: guard
	 * 3: robber
	 * 
	 */
	public int characterType;
	public float dialogIntervals;
	public float height, front;

	private float dialogTimer;
	private int currentLevel;
	private PlayerDetection playerDetection;
	private bool playingSounds;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		//currentLevel = gameManager.getCurrentLevel ();
		audioSource = gameObject.AddComponent<AudioSource> ();
		audioSource.clip = noise;
		if (characterType != -1 || characterType != 0) {
			playerDetection = GetComponentInChildren<PlayerDetection>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		dialogLogic ();
	}

	void dialogLogic(){

		if (characterType == -1) {
		} else if (characterType == 0) {
		} else if (characterType == 1) {
			mummyDialog();
		} else if (characterType == 2) {
		} else if (characterType == 3) {
		}

	}

	//every so often make a mummy sound
	void mummyDialog(){

		//if enough time has passed then play a sound and show some text
		//remove any speech bubbles 
		if (!audioSource.isPlaying) {
			dialogTimer += Time.deltaTime;
			Destroy(GameObject.Find(gameObject.name+":Bubble"));
		}
		//show the dialog box
		else {
			if(playingSounds == true){
				GameObject newBubble = new GameObject(gameObject.name + ":Bubble");
				SpriteRenderer spriteRenderer = newBubble.AddComponent<SpriteRenderer>();
				spriteRenderer.sprite = bubble;
				newBubble.transform.parent = transform;
				newBubble.transform.position = new Vector3(gameObject.transform.position.x + front, gameObject.transform.position.y + height, gameObject.transform.position.z);
				playingSounds = false;
			}
		}

		//if the player isn't seen play the idle clip
		if (dialogTimer > dialogIntervals && !(playerDetection.getSeen() || playerDetection.getInView())) {
			//play the sound clip and create a child object
			playingSounds = true;
			audioSource.clip = noise;
			audioSource.Play();
			dialogTimer = 0;
		}
		//if the player is seen play the Agro. clip
		else if(dialogTimer > dialogIntervals && (playerDetection.getSeen() || playerDetection.getInView())){
			playingSounds = true;
			audioSource.clip = agroNoise;
			audioSource.Play();
			dialogTimer = 0;
		}


	}

}
