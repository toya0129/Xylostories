using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

	public XylophoneScript xylophoneScript;

	private bool serectTrigger;
	private bool[] xylophone = new bool[8];
	private int nowXylo;

	private float[] time = new float[8];
	private int interval = 3;

	// Use this for initialization
	void Start () {
		serectTrigger = false;

		for (int i = 0; i < 8; i++) {
			xylophone[i] = false;
			time [i] = 0.0f;
		}
		nowXylo = 0;
	}
	
	// Update is called once per frame
	void Update () {
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
				xylophoneSerect (nowXylo);
			}
		}

			
		for (int i = 0; i < 4; i++) {
			if (xylophone [i] == true) {
				time [i] += Time.deltaTime;
				if (time [i] > interval) {
					time [i] = 0.0f;
					xylophone [i] = false;
				}
			}
		}
	}

	private void xylophoneSerect(int nowXylo){
		xylophoneScript.changeFlashTrigger (); 
		switch (this.nowXylo) {
		case 1:
			xylophoneScript.changeRedFlashTrigger ();
			break;
		case 2:
			xylophoneScript.changeYellowFlashTrigger ();
			break;
		case 3:
			xylophoneScript.changeGreenFlashTrigger ();
			break;
		case 4:
			xylophoneScript.changePurpleFlashTrigger ();
			break;
		}
	}
}
