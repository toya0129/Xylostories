using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XylophoneScript : MonoBehaviour {

	public SerialConnecter serialConnecter;
	public GameControllerScript gameController;
	public FlashScript flashScript;
	public characterController cc;
	private string[] sensState = new string[5];

	private bool[] xylophone = new bool[8];
	private int nowXylo;
	private int oldXylo;

	public MeshRenderer a;
	public Material[] b;

	// Use this for initialization
	void Start () {
		serialConnecter.OnDataReceived += OnDataReceived;

		for (int i = 0; i < 8; i++) {
			xylophone [i] = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//手動
		if (Input.GetKeyDown (KeyCode.A)) {
			xylophone [0] = true;
			if (nowXylo == 0) {
				nowXylo = 1;
				xylophoneSerect (nowXylo);
			} else {
				nowXylo = 0;
				xylophoneSerect (oldXylo);
			}
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			xylophone [1] = true;
			if (nowXylo == 0) {
				nowXylo = 2;
				xylophoneSerect (nowXylo);
			} else {
				nowXylo = 0;
				xylophoneSerect (oldXylo);
			}
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			xylophone [2] = true;
			if (nowXylo == 0) {
				nowXylo = 3;
				xylophoneSerect (nowXylo);
			} else {
				nowXylo = 0;
				xylophoneSerect (oldXylo);
			}
		}
		if (Input.GetKeyDown (KeyCode.F)) {
			xylophone [3] = true;
			if (nowXylo == 0) {
				nowXylo = 4;
				xylophoneSerect (nowXylo);
			} else {
				nowXylo = 0;
				xylophoneSerect (oldXylo);
			}
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
		cc.setNowCharacter(nowXylo);
		flashScript.changeFlashTrigger (); 
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
		oldXylo = nowXylo;
	}
}
