using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XylophoneScript : MonoBehaviour {

	public SerialConnecter serialConnecter;
	public SelectGameControllerScript gameController;
	public FlashScript flashScript;
	public CharacterControllerScript characterControllerScript;

	private string[] sensState = new string[9];
	private int loop;

	private bool[] xylophone = new bool[8];
	private int nowXylo;
	private int oldXylo;

	private bool selectTrigger;

	private bool xylophoneDelay;
	private float time;
	private float interval = 0.2f;


	// Use this for initialization
	void Start () {
		serialConnecter.OnDataReceived += OnDataReceived;

		loop = 0;

		selectTrigger = false;
		nowXylo = 0;
		oldXylo = 0;

		time = 0.0f;
		xylophoneDelay = true;

		for (int i = 0; i < 8; i++) {
			xylophone [i] = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Xylophone
		if (selectTrigger == false) {
//			loop = 0;
//			while (loop < sensState.Length) {
//				if (sensState [loop] == "1") {
//					xylophone [loop] = true;
//					nowXylo = loop;
//					if (selectTrigger == false) {
//						if (oldXylo == nowXylo) {
//							selectTrigger = true;
//							gameController.setDecision (true);
//							gameController.SelectCharactor = nowXylo;
//						}
//						xylophoneSerect (oldXylo);
//						xylophoneSerect (nowXylo);
//						xylophoneDelay = false;
//						break;
//					}
//				}
//				loop++;
//			}
			if (sensState [0] == "1") {
				xylophone [0] = true;
				nowXylo = 0;
				if (selectTrigger == false) {
					if (oldXylo == nowXylo) {
						selectTrigger = true;
						gameController.setDecision (true);
						gameController.SelectCharactor = nowXylo;
					}
					xylophoneSerect (oldXylo);
					xylophoneSerect (nowXylo);
					xylophoneDelay = false;
				}
			}

			if (sensState [2] == "1") {
				xylophone [2] = true;
				nowXylo = 1;
				if (selectTrigger == false) {
					if (oldXylo == nowXylo) {
						selectTrigger = true;
						gameController.setDecision (true);
						gameController.SelectCharactor = nowXylo;
					}
					xylophoneSerect (oldXylo);
					xylophoneSerect (nowXylo);
					xylophoneDelay = false;
				}
			}

			if (sensState [4] == "1") {
				xylophone [4] = true;
				nowXylo = 2;
				if (selectTrigger == false) {
					if (oldXylo == nowXylo) {
						selectTrigger = true;
						gameController.setDecision (true);
						gameController.SelectCharactor = nowXylo;
					}
					xylophoneSerect (oldXylo);
					xylophoneSerect (nowXylo);
					xylophoneDelay = false;
				}
			}

			if (sensState [6] == "1") {
				xylophone [6] = true;
				nowXylo = 3;
				if (selectTrigger == false) {
					if (oldXylo == nowXylo) {
						selectTrigger = true;
						gameController.setDecision (true);
						gameController.SelectCharactor = nowXylo;
					}
					xylophoneSerect (oldXylo);
					xylophoneSerect (nowXylo);
					xylophoneDelay = false;
				}

			}
		}

		//手動
		if (Input.GetKeyDown (KeyCode.A)) {
			xylophone [0] = true;
			nowXylo = 1;
			if (selectTrigger == false) {
				if (oldXylo == nowXylo) {
					selectTrigger = true;
					gameController.setDecision (true);
					gameController.SelectCharactor = nowXylo;
				}
				xylophoneSerect (oldXylo);
				xylophoneSerect (nowXylo);
			}
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			xylophone [1] = true;
			nowXylo = 2;
			if (selectTrigger == false) {
				if (oldXylo == nowXylo) {
					selectTrigger = true;
					gameController.setDecision (true);
					gameController.SelectCharactor = nowXylo;
				}
				xylophoneSerect (oldXylo);
				xylophoneSerect (nowXylo);
			}
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			xylophone [2] = true;
			nowXylo = 3;
			if (selectTrigger == false) {
				if (oldXylo == nowXylo) {
					selectTrigger = true;
					gameController.setDecision (true);
					gameController.SelectCharactor = nowXylo;
				}
				xylophoneSerect (oldXylo);
				xylophoneSerect (nowXylo);
			}
		}
		if (Input.GetKeyDown (KeyCode.F)) {
			xylophone [3] = true;
			nowXylo = 4;
			if (selectTrigger == false) {
				if (oldXylo == nowXylo) {
					selectTrigger = true;
					gameController.setDecision (true);
					gameController.SelectCharactor = nowXylo;
				}
				xylophoneSerect (oldXylo);
				xylophoneSerect (nowXylo);
			}
		}
		if (selectTrigger == false) {
			characterControllerScript.setNowCharacter (nowXylo);
			characterControllerScript.setMoveType (1);
		}
	}

	void OnDataReceived(string message)
	{
		var data = message.Split (new string[]{ "\t" }, System.StringSplitOptions.None);

		if (data.Length < 9) {
			return;
		}

		try{
			sensState[0] = data[0];
			sensState[1] = data[1];
			sensState[2] = data[2];
			sensState[3] = data[3];
			sensState[4] = data[4];
			sensState[5] = data[5];
			sensState[6] = data[6];
			sensState[7] = data[7];
			sensState[8] = data[8]; //バグ取り用
		}catch(System.Exception e){
			Debug.LogWarning (e.Message);
		}
	}

	private void xylophoneSerect(int nowXylo){
		if (nowXylo != 0) {
			characterControllerScript.setNowCharacter (nowXylo);
			flashScript.changeFlashTrigger (); 
			characterControllerScript.setAnimationChangeTrigger (true);
		}
		oldXylo = nowXylo;
		switch (nowXylo) {
		case 1:
			flashScript.changeRedFlashTrigger ();
			break;
		case 2:
			flashScript.changeYellowFlashTrigger ();
			break;
		case 3:
			flashScript.changeGreenFlashTrigger ();
			break;
		case 4:
			flashScript.changePurpleFlashTrigger ();
			break;
		default:
			break;
		}
	}
}
