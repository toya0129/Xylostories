using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

	public XylophoneScript xylophoneScript;

	private bool serectTrigger;
	private bool[] xylophone = new bool[8];
	private int nowXylo;

	private int count = 0;

	private float time;
	private int interval = 3;

	// Use this for initialization
	void Start () {
		serectTrigger = false;

		for (int i = 0; i < 8; i++) {
			xylophone[i] = false;
		}
		nowXylo = 0;
		time = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (nowXylo == 0) {
			//Xylophone

			//手動
			if (Input.GetKeyDown (KeyCode.A)) {
				xylophone [0] = true;
				nowXylo = 1; 
			} else if (Input.GetKeyDown (KeyCode.S)) {
				xylophone [1] = true;
				nowXylo = 2;
			} else if (Input.GetKeyDown (KeyCode.D)) {
				xylophone [2] = true;
				nowXylo = 3;
			} else if (Input.GetKeyDown (KeyCode.F)) {
				xylophone [3] = true;
				nowXylo = 4;
			}

			for (int i = 0; i < 8; i++) {
				if (xylophone [i] == true) {
					xylophoneScript.changeFlashTrigger ();
					xylophoneSerect (nowXylo);
					break;
				}
			}
		} else {
			time += Time.deltaTime;
			if (time > interval) {
				time = 0.0f;
				for (int i = 0; i < 8; i++) {
					xylophone [i] = false;
				}
				nowXylo = 0;
			}
		}
	}

	private void xylophoneSerect(int nowXylo){
		switch (this.nowXylo) {
		case 1:
			xylophoneScript.changeRedFlashTrigger ();
			nowXylo = 0;
			break;
		case 2:
			xylophoneScript.changeYellowFlashTrigger ();
			nowXylo = 0;
			break;
		case 3:
			xylophoneScript.changeGreenFlashTrigger ();
			nowXylo = 0;
			break;
		case 4:
			xylophoneScript.changePurpleFlashTrigger ();
			nowXylo = 0;
			break;
		}
	}
}
