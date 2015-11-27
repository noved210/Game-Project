using UnityEngine;
using System.Collections;

public class TorchCode : MonoBehaviour {

	public float maxIntensity;
	public float minIntensity;
	public float flickerRate;

	private float currentTime;
	private bool gettingBrighter;
	private Light lt;

	// Use this for initialization
	void Start () {
		currentTime = 0;
		gettingBrighter = false;
		lt = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		//adding some noise to the current time for more fire like effect
		if (gettingBrighter)
			currentTime += flickerRate*(Time.deltaTime);
		else
			currentTime -= flickerRate*(Time.deltaTime);


		lt.intensity = Mathf.Lerp(minIntensity, maxIntensity, currentTime);

		if (currentTime > 1.0) {
			gettingBrighter = !gettingBrighter;
		}
		if (currentTime < 0) {
			gettingBrighter = !gettingBrighter;
		}
	}
}
