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
using System.Threading;
using XyloStoriesSocket;

public class StudyControllerScript : MonoBehaviour {

    private GameControllerScript gameControllerScript;
    private StudySceneCanvasController studySceneCanvasController;
    private SerialReadScript serialReadScript;

    private int mainStory;
    public int moveCharacter = 0;
    [SerializeField]
    private GameObject[] characters;

    private Color32[] xylophone_color =
    {
        new Color32 (255,0,0,255),
        new Color32 (255,155,0,255),
        new Color32 (255,255,0,255),
        new Color32 (0,255,0,255),
        new Color32 (0,255,255,255),
        new Color32 (0,0,255,255),
        new Color32 (128,0,128,255),
        new Color32 (255,0,0,255)
    };

    private bool animationStartFlag = false;
	private bool animationEndFlag = false;

    private string read_data = "";

	#region Find Friend (1)

	#endregion

	#region Run (2) many character
	public int[] track = { 0, 0, 0, 0, 0, 0, 0, 0 };
    private int runAnimationEnd = 10;
    [SerializeField]
    GameObject endflag;
    #endregion

    #region eat food (3) many character
    [SerializeField]
    GameObject food_prefub;
	[SerializeField]
	Sprite[] food_sprite;
    #endregion

    #region get moon (4) one character
    [SerializeField]
    GameObject moon;
    [SerializeField]
    GameObject rope;
    [SerializeField]
    Sprite rope_sprite_last;
    #endregion

    #region make candy house (5)
    [SerializeField]
    GameObject candy_area;
    [SerializeField]
    List<GameObject> candy = new List<GameObject>(); 
    [SerializeField]
    Sprite[] candy_sprite;
    [SerializeField]
    GameObject candy_prefub;
    private int max_candy = 20;
    #endregion

    #region jump train (6)
    private int trainAnimationEnd = 1;
    #endregion

    // Use this for initialization
    void Start () {
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        mainStory = gameControllerScript.MainStory;
        
    }

	// Update is called once per frame
	void Update()
	{
        if (animationStartFlag)
        {
            InputData_Sensor();
            InputData_Key();
            AnimationStart();
        }

		if (animationEndFlag)
		{
            animationStartFlag = false;
            animationEndFlag = false;
			AnimationFinish();
		}
	}

    private void InputData_Sensor()
    {
        read_data = Socket_Server.Read_Data;
        if (read_data != "")
        {
            switch (read_data)
            {
                case "1":
                    moveCharacter = 1;
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

    private void InputData_Toutch()
    {

    }

    private void AnimationStart()
    {
        if (moveCharacter != 0)
        {
            switch (mainStory)
            {
                case 1:

                    break;
                case 2:
                    StartCoroutine(RunningAnimation(moveCharacter - 1, track[moveCharacter - 1]));
                    break;
                case 3:

                    break;
                case 4:
                    StartCoroutine(PullRope(moveCharacter - 1));
                    break;
                case 5:
                    StartCoroutine(ShootStartCandy(moveCharacter - 1));
                    break;
                case 6:
                    StartCoroutine(JumpCharacter_OnTrain(moveCharacter - 1));
                    break;
                default:
                    break;
            }
            //serialReadScript.OutData = "";
            moveCharacter = 0;
        }
    }

    #region Find Friends (1)
    IEnumerator CharacterJump_Grass()
    {
        yield break;
    }

    IEnumerator FindFriends()
    {
        yield break;
    }
    #endregion


    #region Animation Run (2)
    IEnumerator RunningAnimation(int number,int trackNum)
    {
        int animationCount = runAnimationEnd;
        while (animationCount != 0)
        {
            if (characters[number].transform.localPosition.y > -25.0f)
            {
                switch (trackNum)
                {
                    case 0:
                        characters[number].transform.localPosition -= new Vector3(0.001f, 0.1f, 0.0f);
                        break;
                    case 1:
                        characters[number].transform.localPosition -= new Vector3(0.02f, 0.1f, 0.0f);
                        break;
                    case 2:
                        characters[number].transform.localPosition -= new Vector3(-0.02f, 0.1f, 0.0f);
                        break;
                    case 3:
                        characters[number].transform.localPosition -= new Vector3(0.001f, 0.1f, 0.0f);
                        break;
                }
                characters[number].transform.localScale += new Vector3(0.005f, 0.005f, 0);
            }
            else
            {
                animationEndFlag = true;
                yield break;
            }

            yield return new WaitForSeconds(0.01f);
            animationCount--;
        }
        yield break;
    }

    public int[] Track
    {
        set { track = value; }
    }
	#endregion

	#region Eat Food (3)
	public void CreateFood(int number)
	{
		int rand = Random.Range(0, 3);
		GameObject obj = Instantiate(food_prefub);
		obj.GetComponent<SpriteRenderer>().sprite = food_sprite[rand];
		obj.transform.parent = characters[number].transform;

		if (number == 1 || number == 7)
		{
			obj.transform.localPosition = new Vector3(0, 1.5f, 0);
		}
		else
		{
			obj.transform.localPosition = new Vector3(0, 3f, 0);
		}
	}
	#endregion

	#region Get Moon (4)
    IEnumerator PullRope(int number)
    {
        Transform now_character_pos_moon = characters[number].transform;
        characters[number].transform.localPosition = new Vector3(now_character_pos_moon.localPosition.x, -3f, 0);
        yield return new WaitForSeconds(0.2f);
        characters[number].transform.localPosition = new Vector3(now_character_pos_moon.localPosition.x, -8f, 0);

        if(rope.transform.localPosition.x < 20)
        {
            rope.transform.localPosition += new Vector3(1f, -0.02f, 0f);
            yield return new WaitForSeconds(0.1f);
            rope.transform.GetChild(0).transform.position -= new Vector3(1f, -0.02f, 0f);
        }
        else
        {
            animationEndFlag = true;
        }
        yield break;
    }
	#endregion

	#region Make Candy House (5)
	IEnumerator ShootStartCandy(int number)
	{
		Transform now_character_pos_candy = characters[number].transform;
		characters[number].transform.localPosition = new Vector3(now_character_pos_candy.localPosition.x, -3f, 0);
		yield return new WaitForSeconds(0.2f);
		characters[number].transform.localPosition = new Vector3(now_character_pos_candy.localPosition.x, -8f, 0);
		yield return new WaitForSeconds(0.2f);

		characters[number].transform.GetChild(0).GetComponent<MoveCandyScript>().enabled = true;
		characters[number].transform.GetChild(0).parent = candy_area.transform;
		CreateCandy(number);
		yield break;
	}

    public void CreateCandy(int number)
    {
        //if (candy.Count > max_candy)
        //{
        //    animationEndFlag = true;
        //    return;
        //}
        int rand = Random.Range(0, 4);

        GameObject obj = Instantiate(candy_prefub);
        obj.GetComponent<MoveCandyScript>().enabled = false;
        candy.Add(obj);

        obj.GetComponent<SpriteRenderer>().sprite = candy_sprite[rand];
        obj.transform.parent = characters[number].transform;

        if (rand == 2 || rand == 3)
        {
            obj.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }

        if (number == 1)
        {
            obj.transform.localPosition = new Vector3(0, 2f, 0);
        }
        else
        {
            obj.transform.localPosition = new Vector3(0, 3f, 0);
        }

        obj.GetComponent<SpriteRenderer>().color = xylophone_color[number];
    }
    #endregion

    #region jump train (6)
    IEnumerator JumpCharacter_OnTrain(int number)
    {
        characters[number].transform.parent.localPosition = new Vector3(0, 5, 0);
        yield return new WaitForSeconds(0.5f);
        characters[number].transform.parent.localPosition = new Vector3(0, 0, 0);
        yield break;
    }
    #endregion

    #region Animation End
    private void AnimationFinish()
    {
        animationStartFlag = false;
        endflag.SetActive(true);
        //Thread.Sleep(5000); // 5s delay
        //LoadTitle();
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