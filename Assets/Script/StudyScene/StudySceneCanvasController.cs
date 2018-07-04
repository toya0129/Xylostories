using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudySceneCanvasController : MonoBehaviour {

	public GameControllerScript gameControllerScript;


	[SerializeField] CanvasRenderer[] xylophones;
	[SerializeField] CanvasRenderer[] characters;


	void Awake(){
		for (int i = 0; i < 8; i++) {
			xylophones [i].gameObject.SetActive (false);
			characters [i].gameObject.SetActive (false);
		}
	}
		
	// Use this for initialization
	void Start () {
		setCharacter ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void setCharacter(){
		for (int i = 0; i < 8; i++) {
			if (gameControllerScript.FriendsCharacter [i] == true) {
				xylophones [i].gameObject.SetActive (true);
				characters [i].gameObject.SetActive (true);
			}
		}
	}
}
