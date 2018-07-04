using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

	private int mainCharacter;
	private bool[] friendsCharacter = new bool[8];

	void Awake(){
		for (int i = 0; i < 8; i++) {
			friendsCharacter [i] = false;
		}

		test ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void test(){
		mainCharacter = 0;

		friendsCharacter [mainCharacter] = true;
		friendsCharacter [4] = true;
		friendsCharacter [7] = true;

	}

	public int MainCharacter {
		get { return mainCharacter; }
		set { mainCharacter = value; }
	}

	public bool[] FriendsCharacter{
		get { return friendsCharacter; }
		set { friendsCharacter = value; }
	}
}
