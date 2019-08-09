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

public class StudyControllerScript : MonoBehaviour {

    private GameControllerScript gameControllerScript;
    private StudySceneCanvasController studySceneCanvasController;
    private SerialReadScript serialReadScript;

    private int mainStory;
    public int moveCharacter = 0;
    [SerializeField]
    GameObject[] characters;

	private Color[] xylophone_color = new Color[]
    {
		new Color (255f,0f,0f),
		new Color (255f,255f,255f),
		new Color (255f,255f,0f),
		new Color (0f,255f,0f),
		new Color (0f,255f,255f),
		new Color (0f,0f,255f),
		new Color (128f,0f,128f),
		new Color (255f,0f,0f)
    };


	private bool animationEndFlag = false;

    private string serialData = "";

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
    GameObject[] rope;
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
        serialReadScript = GameObject.Find("SerialConecter").GetComponent<SerialReadScript>();
        mainStory = gameControllerScript.MainStory;
        
    }

	// Update is called once per frame
	void Update()
	{
		serialData = serialReadScript.OutData;
		Debug.Log(serialReadScript.OutData);
		if (serialReadScript.OutData != "")
		{
			switch (serialReadScript.OutData)
			{
				case "CC":
					moveCharacter = 1;
					break;
				case "DD":
					moveCharacter = 2;
					break;
				case "EE":
					moveCharacter = 3;
					break;
				case "FF":
					moveCharacter = 4;
					break;
				case "GG":
					moveCharacter = 5;
					break;
				case "AA":
					moveCharacter = 6;
					break;
				case "BB":
					moveCharacter = 7;
					break;
				case "C2":
					moveCharacter = 8;
					break;
				default:
					moveCharacter = 0;
					break;
			}
		}
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

		if (moveCharacter != 0)
		{
			switch (mainStory)
			{
				case 1:

					break;
				case 2:
					StartCoroutine(RunningAnimation(moveCharacter - 1, track[moveCharacter - 1], runAnimationEnd));
					break;
				case 3:
					break;
				case 4:
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
			serialReadScript.OutData = "";
			moveCharacter = 0;
		}

		if (animationEndFlag)
		{
			AnimationFinish();
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
    IEnumerator RunningAnimation(int number,int trackNum,int animationCount)
    {
        if (characters[number].transform.localPosition.y > -25.0f)
        {
            switch (trackNum)
            {
                case 0:
                    characters[number].transform.localScale += new Vector3(0.005f, 0.005f, 0);
                    characters[number].transform.localPosition -= new Vector3(0.006f, 0.2f, 0.0f);
                    break;
                case 1:
                    characters[number].transform.localScale += new Vector3(0.005f, 0.005f, 0);
                    characters[number].transform.localPosition -= new Vector3(0.05f, 0.2f, 0.0f);
                    break;
                case 2:
                    characters[number].transform.localScale += new Vector3(0.005f, 0.005f, 0);
                    characters[number].transform.localPosition -= new Vector3(-0.05f, 0.2f, 0.0f);
                    break;
                case 3:
                    characters[number].transform.localScale += new Vector3(0.005f, 0.005f, 0);
                    characters[number].transform.localPosition -= new Vector3(0.001f, 0.2f, 0.0f);
                    break;
            }
        }
        else
        {
            animationEndFlag = true;
            yield break;
        }

        yield return new WaitForSeconds(0.01f);

        if(animationCount > 0)
        {
            animationCount--;
            yield return StartCoroutine(RunningAnimation(number, trackNum,animationCount));
        }

        if ((serialData != "") && (serialData == serialReadScript.OutData))
        {
            yield return StartCoroutine(RunningAnimation(number, trackNum, runAnimationEnd));
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
	//IEnumerator GetMoon()
	//{
	//    if (moon.transform.localPosition.x < hero.transform.localPosition.x)
	//    {
	//        if (trunFlagZ == true)
	//        {
	//            if (roteZ < 13)
	//            {
	//                hero.transform.localRotation = Quaternion.Euler(0, 0, roteZ);
	//                roteZ += 1.0f;
	//            }
	//            else
	//            {
	//                trunFlagZ = false;
	//            }
	//        }
	//        else if (trunFlagZ == false)
	//        {
	//            if (roteZ > -13)
	//            {
	//                hero.transform.localRotation = Quaternion.Euler(0, 0, roteZ);
	//                roteZ -= 1.0f;
	//            }
	//            else
	//            {
	//                moon.transform.localPosition += new Vector3(2.0f, 0, 0);
	//                moon.transform.localPosition -= new Vector3(0, 0.7f, 0);
	//                trunFlagZ = true;
	//            }
	//        }
	//    }
	//    else
	//    {
	//        hero.transform.localRotation = Quaternion.Euler(0, 0, 0);
	//        rope.SetActive(false);
	//        if (hero.transform.localPosition.x > 0)
	//        {
	//            hero.transform.localPosition -= new Vector3(0.5f, 0, 0);
	//            moon.transform.localPosition -= new Vector3(0.5f, 0, 0);
	//        }
	//        else
	//        {
	//            yield break;
	//        }
	//    }
	//    yield return new WaitForSeconds(0.01f);
	//    yield break;
	//}
	#endregion

	#region Make Candy House (5)
	IEnumerator ShootStartCandy(int number)
	{
		Transform now_character = characters[number].transform;
		characters[number].transform.localPosition = new Vector3(now_character.localPosition.x, -3f, 0);
		yield return new WaitForSeconds(0.2f);
		characters[number].transform.localPosition = new Vector3(now_character.localPosition.x, -8f, 0);
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
        //}
        //else
        //{
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

        //}
        
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

    private void AnimationFinish()
    {
        endflag.SetActive(true);
    }

    public void LoadTitle()
    {
        gameControllerScript.OnLoadTitle();
    }

    #region getter and setter
    public bool AnimationEndFlag
    {
        set { animationEndFlag = value; }
    }
    #endregion
}
