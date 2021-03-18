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

    private GameControllerScript game_controller_script;
    [SerializeField]
    StudySceneCanvasController study_scene_canvas_controller;

    private int main_story;
    private int move_character = 0;
    [SerializeField]
    private GameObject[] characters;

    private bool animation_start_flag = false;
	private bool animation_end_flag = false;

    private string read_data = "";

    private bool hidden_trigger = false;
    private List<int> input_hidden_command = new List<int>();
    public int[] hidden_command =
    {
        1,1,2,3,8,7,6,5,1,1
    };

    private List<List<int>> score = new List<List<int>>()
    {
        new List<int>() { 1,2,3,4,3,2,1,3,4,5,6,5,4,3,1,1,1,1,1,1,2,2,3,3,4,4,3,2,1 },
        new List<int>() { 1,2,3,1,2,3,5,3,2,1,2,3,2,1,2,3,1,2,3,5,3,2,1,2,3,1,5,5,3,5,6,6,5,3,3,2,2,1}
    };

    [SerializeField]
    private GameObject blank_panel;

    [SerializeField]
    private GameObject go_menu;

    #region Find Friend (1)
    private int find_move_count = 0;
	#endregion

	#region Run (2) many character
    [SerializeField]
    private GameObject run_end_flag;
    #endregion

    #region get moon (4) one character
    [SerializeField]
    private GameObject rope;
    #endregion

    // Use this for initialization
    private void Start () {
        blank_panel.SetActive(false);
        go_menu.SetActive(false);
        game_controller_script = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        main_story = game_controller_script.MainStory;       
    }

	// Update is called once per frame
	private void Update()
	{
        if (animation_start_flag)
        {
#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
            InputData_Sensor();
            InputData_Key();
#endif
            if (hidden_trigger)
            {
                if(move_character != 0)
                {
                    input_hidden_command.Add(move_character);
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

		if (animation_end_flag)
		{
            StartCoroutine(AnimationFinish());
		}
	}

#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
    private void InputData_Sensor()
    {
        read_data = SocketServer.ReadData;
        if (read_data != "")
        {
            switch (read_data)
            {
                case "1":
                    move_character = 1;
                    if (!hidden_trigger)
                    {
                        hidden_trigger = true;
                    }
                    break;
                case "2":
                    move_character = 2;
                    break;
                case "3":
                    move_character = 3;
                    break;
                case "4":
                    move_character = 4;
                    break;
                case "5":
                    move_character = 5;
                    break;
                case "6":
                    move_character = 6;
                    break;
                case "7":
                    move_character = 7;
                    break;
                case "8":
                    move_character = 8;
                    break;
                default:
                    move_character = 0;
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
                move_character = 1;
                if (!hidden_trigger)
                {
                    hidden_trigger = true;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                move_character = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                move_character = 3;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                move_character = 4;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                move_character = 5;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                move_character = 6;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                move_character = 7;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                move_character = 8;
            }
            else
            {
                move_character = 0;
            }
        }
    }
#endif

    public void InputData_Toutch(int num)
    {
        move_character = num;

        if(move_character == 1)
        {
            if (!hidden_trigger)
            {
                hidden_trigger = true;
            }
        }

        if (hidden_trigger)
        {
            if (move_character != 0)
            {
                input_hidden_command.Add(move_character);
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
        if (move_character != 0)
        {
            if (game_controller_script.Characters[move_character - 1])
            {
                StartCoroutine(study_scene_canvas_controller.Xylophone_OnColor(move_character - 1));
                switch (main_story)
                {
                    case 1:
                        StartCoroutine(characters[move_character - 1].GetComponent<CharacterMoveScript>().CharacterJump_Cloud());
                        break;
                    case 2:
                        StartCoroutine(characters[move_character - 1].GetComponent<CharacterMoveScript>().RunningAnimation());
                        break;
                    case 3:
                        StartCoroutine(characters[move_character - 1].GetComponent<CharacterMoveScript>().EatFood());
                        break;
                    case 4:
                        StartCoroutine(characters[move_character - 1].GetComponent<CharacterMoveScript>().PullRope(rope));
                        break;
                    case 5:
                        StartCoroutine(characters[move_character - 1].GetComponent<CharacterMoveScript>().ShootStartCandy());
                        break;
                    case 6:
                        StartCoroutine(characters[move_character - 1].GetComponent<CharacterMoveScript>().JumpCharacter_OnTrain());
                        break;
                    default:
                        break;
                }
                move_character = 0;
            }
        }
    }

    #region Animation End
    private IEnumerator AnimationFinish()
    {
        animation_start_flag = false;
        animation_end_flag = false;
        run_end_flag.SetActive(true);
        go_menu.SetActive(true);

        yield return new WaitForSeconds(3f);
        LoadTitle();
        yield break;
    }

    public void LoadMenu()
    {
        game_controller_script.OnLoadMenuScene();
    }
    public void LoadTitle()
    {
        game_controller_script.OnLoadTitle();
    }
    #endregion

    #region hidden command
    private bool CheckCommand()
    {
        hidden_trigger = false;
        animation_start_flag = false;

        for(int i = 0; i < input_hidden_command.Count; i++)
        {
            if(hidden_command[i] != input_hidden_command[i])
            {
                animation_start_flag = true;
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
        int rand = Random.Range(0,score.Count);

        while (count < score[rand].Count)
        {
            StartCoroutine(study_scene_canvas_controller.Xylophone_OnColor(score[rand][count] - 1));
            switch (main_story)
            {
                case 1:
                    StartCoroutine(characters[score[rand][count] - 1].GetComponent<CharacterMoveScript>().CharacterJump_Cloud());
                    break;
                case 2:
                    StartCoroutine(characters[score[rand][count] - 1].GetComponent<CharacterMoveScript>().RunningAnimation());
                    break;
                case 3:
                    StartCoroutine(characters[score[rand][count] - 1].GetComponent<CharacterMoveScript>().EatFood());
                    break;
                case 4:
                    StartCoroutine(characters[score[rand][count] - 1].GetComponent<CharacterMoveScript>().PullRope(rope));
                    break;
                case 5:
                    StartCoroutine(characters[score[rand][count] - 1].GetComponent<CharacterMoveScript>().ShootStartCandy());
                    break;
                case 6:
                    StartCoroutine(characters[score[rand][count] - 1].GetComponent<CharacterMoveScript>().JumpCharacter_OnTrain());
                    break;
                default:
                    break;
            }
            count++;

            switch (rand)
            {
                case 0:
                    yield return StartCoroutine(Frog_Song(count));
                    break;
                case 1:
                    yield return StartCoroutine(Tulips_Song(count));
                    break;
                default:
                    break;
            }
            
        }

        animation_start_flag = true;
        blank_panel.SetActive(false);

        yield break;
    }

    private IEnumerator Frog_Song(int num)
    {
        if (num == 7 || num == 14 || num == 15 || num == 16 || num == 17 || num == 18)
        {
            yield return new WaitForSeconds(1f);
        }
        else if (num == 19 || num == 20 || num == 21 || num == 22 || num == 23 || num == 24 || num == 25 || num == 26)
        {
            yield return new WaitForSeconds(0.25f);
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
        }
        yield break;
    }

    private IEnumerator Tulips_Song(int num)
    {
        if(num == 3 || num == 6 || num == 13 || num == 16 || num == 19 || num == 26 || num == 33)
        {
            yield return new WaitForSeconds(1f);
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
        }
        yield break;
    }
    #endregion

    #region getter and setter
    public bool AnimationStartFlag
    {
        set { animation_start_flag = value; }
    }

    public bool AnimationEndFlag
    {
        set { animation_end_flag = value; }
    }
    #endregion
}
