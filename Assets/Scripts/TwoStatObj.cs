using UnityEngine;
using System.Collections;

public class TwoStatObj : MonoBehaviour {

	//if you want to use this for the postion the check this (set to true)
	public bool positionState;

	//if the object has two stats (ex: open and closed) then this is the script
	public bool stateOneOn;
	
	//if the state is the position of an object use these
	public GameObject stateOnePosition;
	public GameObject stateTwoPosition;

	//in the case of a rotation (swinging doors)
	public float angleToRotate;
	public Vector3 stateOneRotation;
	public Vector3 stateTwoRotation;
	private GameObject rotationPoint;

	//timer for the current state of the animation
	private float timer;
	private bool currentState;
	private bool stateToBe;
	public float animationSpeed;

	public bool oneUse;
	private int useCount;
	private float firstAngle, secondAngle;


	// Use this for initialization
	void Start () {

		if (positionState) {
			if (stateOneOn) {
				gameObject.transform.position = stateOnePosition.transform.position;
			} else {
				gameObject.transform.position = stateTwoPosition.transform.position;
			}
		} else {

			rotationPoint = transform.parent.gameObject;

			firstAngle = gameObject.transform.parent.gameObject.transform.rotation.eulerAngles.y;
			secondAngle = firstAngle + angleToRotate;

			if(!stateOneOn){
				rotationPoint.transform.eulerAngles = new Vector3(0, firstAngle, 0);
			}
			else{
				rotationPoint.transform.eulerAngles = new Vector3(0, secondAngle, 0);			}
		}

		currentState = stateOneOn;
		stateToBe = currentState;
		useCount = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//if the state needs to be changed animate the change
		if (currentState != stateToBe) {
			timer += Time.deltaTime*animationSpeed;
			if(timer >= 1)
				currentState = stateToBe;

			if(positionState){
				if(!stateToBe){
					Debug.Log ("Going up");
					gameObject.transform.position = Vector3.Lerp(stateOnePosition.transform.position, stateTwoPosition.transform.position, timer);
				}
				else{
					Debug.Log ("Going down");
					gameObject.transform.position = Vector3.Lerp(stateTwoPosition.transform.position, stateOnePosition.transform.position, timer);
				}
			}
			else{
				if(stateToBe){
					rotationPoint.transform.eulerAngles = new Vector3(0, Mathf.Lerp(firstAngle, secondAngle, timer*animationSpeed), 0);
				}
				else{
					rotationPoint.transform.eulerAngles = new Vector3(0, Mathf.Lerp(secondAngle, firstAngle, timer*animationSpeed), 0);
				}
			}

		}
	}

	public void changeState(){
		if (useCount == 0 && oneUse || !oneUse) {
			if (stateToBe == currentState) {
				useCount ++;
				timer = 0;
				stateToBe = !stateToBe;
			}
		}

	}
}
