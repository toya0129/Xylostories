/* number : Character Number
 * 
 * 
 * 
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
using XyloStoriesSocket;
#endif

public class StudyControllerScript : MonoBehaviour {

    private GameControllerScript gameControllerScript;
    [SerializeField]
    StudySceneCanvasController studySceneCanvasController;

    private int mainStory;
    private int moveCharacter = 0;
    [SerializeField]
    private GameObject[] characters;

    private bool animationStartFlag = false;
	private bool animationEndFlag = false;

    private string read_data = "";

    private bool hidden_trigger = false;
    public List<int> input_hidden_command = new List<int>();
    public int[] hidden_command =
    {
        1,1,2,3,8,7,6,5,1,1
    };
    private int[] score =
    {
        1,2,3,4,3,2,1,3,4,5,6,5,4,3,1,1,1,1,1,1,2,2,3,3,4,4,3,2,1
    };

    [SerializeField]
    private GameObject blank_panel;

    #region Find Friend (1)
    private int find_move_count = 0;
	#endregion

	#region Run (2) many character
    [SerializeField]
    GameObject endflag;
    #endregion

    #region eat food (3) many character

    #endregion

    #region get moon (4) one character
    [SerializeField]
    GameObject rope;
    #endregion

    #region make candy house (5)
    
    #endregion

    #region jump train (6)

    #endregion

    // Use this for initialization
    void Start () {
        blank_panel.SetActive(false);
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        mainStory = gameControllerScript.MainStory;       
    }

	// Update is called once per frame
	void Update()
	{
        if (animationStartFlag)
        {
#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
            InputData_Sensor();
            InputData_Key();
#endif
            if (hidden_trigger)
            {
                if(moveCharacter != 0)
                {
                    input_hidden_command.Add(moveCharacter);
                }
            }

            if(input_hidden_command.Count == 10)
            {
                if (CheckCommand())
                {
                    StartCoroutine(HiddenCommandStart());
                }
                input_hidden_command = new List<int>();
            }

            AnimationStart();
        }

		if (animationEndFlag)
		{
            StartCoroutine(AnimationFinish());
		}
	}

#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
    private void InputData_Sensor()
    {
        read_data = Socket_Server.Read_Data;
        if (read_data != "")
        {
            switch (read_data)
            {
                case "1":
                    moveCharacter = 1;
                    if (!hidden_trigger)
                    {
                        hidden_trigger = true;
                    }
                    break;
                case "2":
                    moveCharacter = 2;
                    break;
                case "3":
                    moveCharacter = 3;
                    break;
                case "4":
                    moveCharacter = 4;
                    break;
                case "5":
                    moveCharacter = 5;
                    break;
                case "6":
                    moveCharacter = 6;
                    break;
                case "7":
                    moveCharacter = 7;
                    break;
                case "8":
                    moveCharacter = 8;
                    break;
                default:
                    moveCharacter = 0;
                    break;
            }
        }
    }

    private void InputData_Key()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                moveCharacter = 1;
                if (!hidden_trigger)
                {
                    hidden_trigger = true;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                moveCharacter = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                moveCharacter = 3;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                moveCharacter = 4;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                moveCharacter = 5;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                moveCharacter = 6;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                moveCharacter = 7;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                moveCharacter = 8;
            }
            else
            {
                moveCharacter = 0;
            }
        }
    }
#endif

    public void InputData_Toutch(int num)
    {
        moveCharacter = num;

        if(moveCharacter == 1)
        {
            if (!hidden_trigger)
            {
                hidden_trigger = true;
            }
        }

        if (hidden_trigger)
        {
            if (moveCharacter != 0)
            {
                input_hidden_command.Add(moveCharacter);
            }
        }

        if (input_hidden_command.Count == 10)
        {
            if (CheckCommand())
            {
                StartCoroutine(HiddenCommandStart());
            }
            input_hidden_command = new List<int>();
        }

        AnimationStart();
    }

    private void AnimationStart()
    {
        if (moveCharacter != 0)
        {
            if (gameControllerScript.Characters[moveCharacter - 1])
            {
                StartCoroutine(studySceneCanvasController.Xylophone_OnColor(moveCharacter - 1));
                switch (mainStory)
                {
                    case 1:
                        StartCoroutine(characters[moveCharacter - 1].GetComponent<CharacterMoveScript>().CharacterJump_Cloud());
                        break;
                    case 2:
                        StartCoroutine(characters[moveCharacter - 1].GetComponent<CharacterMoveScript>().RunningAnimation());
                        break;
                    case 3:
                        StartCoroutine(characters[moveCharacter - 1].GetComponent<CharacterMoveScript>().EatFood());
                        break;
                    case 4:
                        StartCoroutine(characters[moveCharacter - 1].GetComponent<CharacterMoveScript>().PullRope(rope));
                        break;
                    case 5:
                        StartCoroutine(characters[moveCharacter - 1].GetComponent<CharacterMoveScript>().ShootStartCandy());
                        break;
                    case 6:
                        StartCoroutine(characters[moveCharacter - 1].GetComponent<CharacterMoveScript>().JumpCharacter_OnTrain());
                        break;
                    default:
                        break;
                }
                moveCharacter = 0;
            }
        }
    }

    #region Animation End
    private IEnumerator AnimationFinish()
    {
        animationStartFlag = false;
        animationEndFlag = false;
        endflag.SetActive(true);
        yield return new WaitForSeconds(3f);
        LoadTitle();
        yield break;
    }

    public void LoadMenu()
    {
        gameControllerScript.OnLoadMenuScene();
    }
    public void LoadTitle()
    {
        gameControllerScript.OnLoadTitle();
    }
    #endregion

    private bool CheckCommand()
    {
        hidden_trigger = false;
        animationStartFlag = false;

        for(int i = 0; i < input_hidden_command.Count; i++)
        {
            if(hidden_command[i] != input_hidden_command[i])
            {
                animationStartFlag = true;
                return false;
            }
        }
        blank_panel.SetActive(true);
        return true;
    }

    private IEnumerator HiddenCommandStart()
    {
        yield return new WaitForSeconds(1f);

        int count = 0;

        while (count < score.Length)
        {
            StartCoroutine(studySceneCanvasController.Xylophone_OnColor(score[count] - 1));
            switch (mainStory)
            {
                case 1:
                    StartCoroutine(characters[score[count] - 1].GetComponent<CharacterMoveScript>().CharacterJump_Cloud());
                    break;
                case 2:
                    StartCoroutine(characters[score[count] - 1].GetComponent<CharacterMoveScript>().RunningAnimation());
                    break;
                case 3:
                    StartCoroutine(characters[score[count] - 1].GetComponent<CharacterMoveScript>().EatFood());
                    break;
                case 4:
                    StartCoroutine(characters[score[count] - 1].GetComponent<CharacterMoveScript>().PullRope(rope));
                    break;
                case 5:
                    StartCoroutine(characters[score[count] - 1].GetComponent<CharacterMoveScript>().ShootStartCandy());
                    break;
                case 6:
                    StartCoroutine(characters[score[count] - 1].GetComponent<CharacterMoveScript>().JumpCharacter_OnTrain());
                    break;
                default:
                    break;
            }
            count++;

            yield return new WaitForSeconds(0.5f);

            if (count == 7 || count == 14 || count == 15 || count == 16 || count == 17 || count == 18 || count == 27 || count == 28 || count == 29)
            {
                yield return new WaitForSeconds(0.5f);
            }
        }

        animationStartFlag = true;
        blank_panel.SetActive(false);

        yield break;
    }

    #region getter and setter
    public bool AnimationStartFlag
    {
        set { animationStartFlag = value; }
    }

    public bool AnimationEndFlag
    {
        set { animationEndFlag = value; }
    }
    #endregion
}
