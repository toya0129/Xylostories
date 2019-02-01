using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FriendSelectController : MonoBehaviour {

    [SerializeField]
    GameObject canvasScript;
    private GameObject gameController;
    private int main = 0;
    private int f = 0;
    private List<int> friend = new List<int>();
    private bool fTrigger = false;

    // Use this for initialization
    void Start () {
        gameController = GameObject.Find("GameController");
        main = gameController.GetComponent<GameControllerScript>().MainCharacter;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (friend.Count != 0)
            {
                for (int j = 0; j < friend.Count;j++){
                    gameController.GetComponent<GameControllerScript>().FriendsCharacter[friend[j] - 1] = true;
                }
//                gameController.GetComponent<GameControllerScript>().OnLoadAnimation();
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
                            f = 1;
                            break;
                        case KeyCode.Alpha2:
                            f = 2;
                            break;
                        case KeyCode.Alpha3:
                            f = 3;
                            break;
                        case KeyCode.Alpha4:
                            f = 4;
                            break;
                        case KeyCode.Alpha5:
                            f = 5;
                            break;
                        case KeyCode.Alpha6:
                            f = 6;
                            break;
                        case KeyCode.Alpha7:
                            f = 7;
                            break;
                        case KeyCode.Alpha8:
                            f = 8;
                            break;
                        default:
                            f = 0;
                            break;
                    }

                    if ((f != 0) && (f != main))
                    {
                        canvasScript.GetComponent<FriendSelectCanvasScript>().SetFriendCharacter(f);

                        for (int i = 0; i < friend.Count; i++)
                        {
                            if (friend[i] == f)
                            {
                                friend.RemoveAt(i);
                                fTrigger = true;
                            }
                        }

                        if (fTrigger != true)
                        {
                            friend.Add(f);
                        }
                    }
                    f = 0;
                    fTrigger = false;
                }
            }
        }
    }
}
