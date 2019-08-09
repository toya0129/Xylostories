//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;

//public class MainSoundSelectController : MonoBehaviour {

//    [SerializeField]
//    GameObject canvasScript;
//    private GameObject gameController;
//    private int main = 0;

//	// Use this for initialization
//	void Start () {
//        gameController = GameObject.Find("GameController");
//	}
	
//	// Update is called once per frame
//	void Update () {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            if (gameController.GetComponent<GameControllerScript>().MainCharacter != 0)
//            {
//                gameController.GetComponent<GameControllerScript>().OnLoadFriendSelect();
//            }
//        }

//        if (Input.anyKeyDown)
//        {
//            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
//            {
//                if (Input.GetKeyDown(code))
//                {
//                    switch (code)
//                    {
//                        case KeyCode.Alpha1:
//                            main = 1;
//                            break;
//                        case KeyCode.Alpha2:
//                            main = 2;
//                            break;
//                        case KeyCode.Alpha3:
//                            main = 3;
//                            break;
//                        case KeyCode.Alpha4:
//                            main = 4;
//                            break;
//                        case KeyCode.Alpha5:
//                            main = 5;
//                            break;
//                        case KeyCode.Alpha6:
//                            main = 6;
//                            break;
//                        case KeyCode.Alpha7:
//                            main = 7;
//                            break;
//                        case KeyCode.Alpha8:
//                            main = 8;
//                            break;
//                        default:
//                            main = 0;
//                            break;
//                    }
//                    if(main != 0){
//                        canvasScript.GetComponent<MainSoundCanvasScript>().SetMainCharacter(main);
//                        gameController.GetComponent<GameControllerScript>().MainCharacter = main;
//                    }
//                }
//            }
//        }
//    }
//}
