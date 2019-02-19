using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyControllerScript : MonoBehaviour {

    private GameControllerScript gameControllerScript;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadTitle()
    {
        gameControllerScript.OnLoadTitle();
    }
}
