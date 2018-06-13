using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGameControllerScript : MonoBehaviour {

	public SelectCameraControllerScript selectCameraControllerScript;

	private bool decision;
	private int selectCharacter;

	// Use this for initialization
	void Start () {
		decision = false;
		selectCharacter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if  (decision == true){
			decision = false;
			selectCameraControllerScript.setCameraMoveTrugger (true);
		}
	}

	public void setDecision(bool now){
		decision = now;
	}
	public void setSelectCharactor(int now){
		selectCharacter = now;
	}
}
