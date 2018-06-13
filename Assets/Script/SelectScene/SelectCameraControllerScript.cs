using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCameraControllerScript : MonoBehaviour {

	public SelectGameControllerScript selectGameControllerScript;

	private Transform cameraTransform;
	private Vector3 cameraPosition;
	private bool cameraMoveTrigger;
	private int selectCharacter;

	// Use this for initialization
	void Start () {
		cameraMoveTrigger = false;
		cameraTransform = gameObject.GetComponent<Transform> ();
		cameraPosition = new Vector3 (0, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (cameraMoveTrigger == true) {
			moveStart ();
		}
	}

	private void moveStart(){
		if (cameraTransform.localPosition.y > -57.0f) {
			cameraTransform.localPosition -= cameraPosition;
		} else {
			cameraMoveTrigger = false;
		}
		
	}

	public void setCameraMoveTrugger(bool trigger){
		cameraMoveTrigger = trigger;
	}
}
