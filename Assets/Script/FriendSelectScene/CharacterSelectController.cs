using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterSelectController : MonoBehaviour {

    [SerializeField]
    GameObject canvasScript;
    private GameObject gameController;
    private int character_num = 0;
    private List<int> character = new List<int>();
    private bool fTrigger = false;

    // Use this for initialization
    void Start () {
        gameController = GameObject.Find("GameController");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (character.Count != 0)
            {
                for (int j = 0; j < character.Count;j++){
                    gameController.GetComponent<GameControllerScript>().Characters[character[j] - 1] = true;
                }
                gameController.GetComponent<GameControllerScript>().OnLoadStudy();
            }
        }

        if (Input.anyKeyDown)
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    switch (code)
                    {
                        case KeyCode.Alpha1:
                            character_num = 1;
                            break;
                        case KeyCode.Alpha2:
                            character_num = 2;
                            break;
                        case KeyCode.Alpha3:
                            character_num = 3;
                            break;
                        case KeyCode.Alpha4:
                            character_num = 4;
                            break;
                        case KeyCode.Alpha5:
                            character_num = 5;
                            break;
                        case KeyCode.Alpha6:
                            character_num = 6;
                            break;
                        case KeyCode.Alpha7:
                            character_num = 7;
                            break;
                        case KeyCode.Alpha8:
                            character_num = 8;
                            break;
                        default:
                            character_num = 0;
                            break;
                    }

                    if ((character_num != 0))
                    {
                        canvasScript.GetComponent<CharacterSelectCanvasScript>().SetCharacter(character_num);

                        for (int i = 0; i < character.Count; i++)
                        {
                            if (character[i] == character_num)
                            {
                                character.RemoveAt(i);
                                fTrigger = true;
                            }
                        }

                        if (fTrigger != true)
                        {
                            character.Add(character_num);
                        }
                    }
                    character_num = 0;
                    fTrigger = false;
                }
            }
        }
    }
}
