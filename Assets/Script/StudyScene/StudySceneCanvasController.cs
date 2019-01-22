using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudySceneCanvasController : MonoBehaviour {

	private GameControllerScript gameControllerScript;

    [SerializeField] GameObject[] xylophones;
    [SerializeField] GameObject[] characters;


	void Awake(){
		for (int i = 0; i < 8; i++) {
			xylophones [i].SetActive (false);
			characters [i].SetActive (false);
		}
	}
		
	// Use this for initialization
	void Start () {
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameControllerScript>();
		setCharacter ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void setCharacter(){
        xylophones[gameControllerScript.MainCharacter - 1].SetActive(true);
        characters[gameControllerScript.MainCharacter - 1].SetActive(true);
        for (int i = 0; i < 8; i++) {
			if (gameControllerScript.FriendsCharacter [i] == true) {
				xylophones [i].SetActive (true);
				characters [i].SetActive (true);
			}
		}
	}

    public void LoadTitle()
    {
        gameControllerScript.OnLoadTitle();
    }
}
