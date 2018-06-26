using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

	private string mainCharacter;
	private bool[] friendsCharacter = new bool[8] ();

	// Use this for initialization
	void Start () {

		for (int i = 0; i < 8; i++) {
			friendsCharacter [i] = false;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool FriendsCharacter{
		get { return friendsCharacter; }
		set { friendsCharacter =value;}
	}
}
