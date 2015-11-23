using UnityEngine;
using System.Collections;

public class EquiptmentSwap : MonoBehaviour {

	public GameObject[] equipment;
	private int currentSelection, selectionMax;

	private Mesh equipmentMesh;

	// Use this for initialization
	void Start () {
		currentSelection = 0;
		selectionMax = equipment.Length;
		gameObject.AddComponent<MeshFilter> ();
		gameObject.AddComponent<MeshRenderer> ();
		equipmentMesh = equipment[currentSelection].GetComponent<MeshFilter> ().sharedMesh;
		gameObject.GetComponent<MeshFilter> ().mesh = equipmentMesh;
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			currentSelection++;
			if(currentSelection >= selectionMax){
				currentSelection = 0;
			}
			equipmentMesh = equipment[currentSelection].GetComponent<MeshFilter> ().sharedMesh;
			gameObject.GetComponent<MeshFilter> ().mesh = equipmentMesh;
		}

		else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			currentSelection--;
			if(currentSelection < 0){
				currentSelection = selectionMax;
			}
			equipmentMesh = equipment[currentSelection].GetComponent<MeshFilter> ().sharedMesh;
			gameObject.GetComponent<MeshFilter> ().mesh = equipmentMesh;
		}

	}
}
