using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XylophoneController : MonoBehaviour {

	private int mainCharacter;
	private bool[] friendsCharacter = new bool[7] ();

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {

		//手動
		if (Input.GetKeyDown (KeyCode.A)) {
			mainCharacter = 1;
		} else if (Input.GetKeyDown (KeyCode.S)) {
			mainCharacter = 2;
		} else if (Input.GetKeyDown (KeyCode.D)) {
			mainCharacter = 3;
		} else if (Input.GetKeyDown (KeyCode.F)) {
			mainCharacter = 4;
		} else if (Input.GetKeyDown (KeyCode.G)) {
			mainCharacter = 5;
		} else if (Input.GetKeyDown (KeyCode.H)) {
			mainCharacter = 6;
		} else if (Input.GetKeyDown (KeyCode.J)) {
			mainCharacter = 7;
		} else if (Input.GetKeyDown (KeyCode.K)) {
			mainCharacter = 8;
		}


	}
}
