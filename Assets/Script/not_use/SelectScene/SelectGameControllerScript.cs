using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGameControllerScript : MonoBehaviour {

	public SelectMoveControllerScript selectMoveControllerScript;
	public CharacterControllerScript characterControllerScript;
	public FlashScript flashScriot;

	private bool decisionCharacter;
	private static int selectCharacter;

	private bool friendsWalkTrigger;

	// Use this for initialization
	void Start () {
		decisionCharacter = false;
		selectCharacter = 0;

		friendsWalkTrigger = false;
	}
	
	// Update is called once per frame
	void Update () {
		if  (decisionCharacter == true){
			decisionCharacter = false;
			flashScriot.changeFlashTrigger ();
			characterControllerScript.animationAllReset ();
			selectMoveControllerScript.setMoveTrigger (true);
		}

		if(friendsWalkTrigger == true){
			friendsWalkTrigger = false;
			selectMoveControllerScript.setfriendsWalkTrigger (true);
		}
	}

	public void setDecision(bool now){
		decisionCharacter = now;
	}

	public int SelectCharactor{
		get { return selectCharacter; }
		set { selectCharacter = value;}
	}

	public void setfriendsWalkTrigger(bool trigger){
		friendsWalkTrigger = trigger;
	}
}
