using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMoveControllerScript : MonoBehaviour {

	public SelectGameControllerScript selectGameControllerScript;

	public Transform cameraTransform;
	public Transform charactersTransform;
	public Transform flowersTransform;
	public Transform stemsTransform;
	public Transform xylophoneTransform; 

	private Vector3 movePosition;

	public GameObject[] characters;
	private bool[] walkEnd;
	private int loop = 0;

	private bool moveTrigger;
	private bool cameraMoveTrigger;
	private bool characterMoveTrigger;
	private bool flowerMoveTrigger;
	private bool stemsMoveTrigger;
	private bool xylophoneTrigger;

	private int selectCharacter;
	private bool friendsWalkTrigger;

	// Use this for initialization
	void Start () {
		moveTrigger = false;
		cameraMoveTrigger = true;
		characterMoveTrigger = true;
		flowerMoveTrigger = true;
		stemsMoveTrigger = true;
		xylophoneTrigger = false;
		friendsWalkTrigger = false;

		movePosition = new Vector3 (0, 1, 0);

		walkEnd = new bool[characters.Length];

		for (int i = 0; i < characters.Length; i++) {
			walkEnd [i] = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (moveTrigger == true) {
			characterSelect ();
		}
		if (friendsWalkTrigger == true) {
			friendsWalks (selectGameControllerScript.SelectCharactor - 1);
		}
	}

	private void characterSelect(){
		if (flowersTransform.localPosition.y > -20.0f) {
			if (flowersTransform.localPosition.y > -14.0f) {
				stemsTransform.localPosition -= movePosition;
			} else {
				if (stemsMoveTrigger == true) {
					Destroy (stemsTransform.gameObject);
					stemsMoveTrigger = false;
				}
			}
			flowersTransform.localPosition -= movePosition;
		} else {
			flowerMoveTrigger = false;
		}

		if (charactersTransform.localPosition.y > -59.0f) {
			charactersTransform.localPosition -= movePosition;
		} else {
			characterMoveTrigger = false;
		}

/*		if(xylophoneTransform.localPosition.y > -57.0f){
			xylophoneTransform.localPosition -= movePosition;
		}else{
			xylophoneTrigger =false;
		}
*/
		if (cameraTransform.localPosition.y > -57.0f) {
			cameraTransform.localPosition -= movePosition;
		} else {
			cameraMoveTrigger = false;
		}

		if ((cameraMoveTrigger == false) && (characterMoveTrigger == false) && (flowerMoveTrigger == false) && (xylophoneTrigger == false)) {
			moveTrigger = false;
			selectGameControllerScript.setfriendsWalkTrigger (true);
		} 
	}

	private void friendsWalks(int myCharacter){
		walkEnd [myCharacter] = true;
		loop = 0;
		while(loop < characters.Length){
			if (myCharacter != loop) {
				if (characters [loop].transform.localPosition.x > -27.0f) {
					characters [loop].transform.localPosition -= new Vector3 (UnityEngine.Random.Range (0.1f, 2.0f), 0, 0);
				} else {
					walkEnd [loop] = true;
				}
			}
			loop++;
		}

		for (int i = 0; i < characters.Length; i++) {
			if (walkEnd [i] != true) {
				return;
			}
		}
		friendsWalkTrigger = false;
	}

	public void setMoveTrigger(bool trigger){
		moveTrigger = trigger;
	}
	public void setfriendsWalkTrigger(bool trigger){
		friendsWalkTrigger = trigger;
	}
}
