using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudySceneCanvasController : MonoBehaviour {

	[SerializeField] 
    GameControllerScript gameControllerScript;

    [SerializeField]
    StudyControllerScript studyControllerScript;

    [SerializeField]
    GameObject backgroundArea;
    private float[] backgroundSize = { 1.61f, 3.1f ,1.61f,1.61f,1.61f, 3.1f};

	[SerializeField]
	GameObject character_area;

    [SerializeField] 
    GameObject[] characters;

    [SerializeField]
    List<Sprite> background = new List<Sprite>();

    #region Run on Track (2)
    [SerializeField]
    GameObject tape;
    private float[] startPosX = { 2.5f, -5f, 5f, -3.5f };
    private float startPosY = 30f;
    private int[] trackNum = { 0, 0, 0, 0, 0, 0, 0, 0 };
	#endregion

	#region eat food (3)


	#endregion


	#region Get Moon (4)
	private Color back_color_moon = new Color(5f, 5f, 70f);
    [SerializeField]
    GameObject moon;
	#endregion

	#region Make Candy House (5) scale 2
	//private float[] startPosX_candy = { -4f, 4f, -12f, 12f, -20f, 20f, -28f, 28f };
	private float[] startPosX_candy = { -28f,-20f, -12f,-4f, 4f, 12f, 20f,28f };
	private float startPosY_candy = -22f;
    [SerializeField]
    GameObject house;
    #endregion

    #region Train (6)
    [SerializeField]
    GameObject trainField;
    [SerializeField]
    List<GameObject> train;
    [SerializeField]
    GameObject mountains;

    private int mountainAnimationEnd = 2;
    private float[] train_characterX = { -17f, -10f, -4f, 2.3f, 8.7f, 15f, 21.5f, 28f };
    private float train_characterY = -8;
    #endregion


    void Awake(){
        InitObject();
	}
		
	// Use this for initialization
	void Start () {
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        setCharacter();
        setUI(gameControllerScript.MainStory);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void setCharacter()
    {
        for (int i = 0; i < 8; i++)
        {
            if (gameControllerScript.Characters[i])
            {
                characters[i].SetActive(true);
            }
        }
    }

    private void InitObject()
    {
		character_area.transform.localPosition = new Vector3(0, 0, 0);
		character_area.GetComponent<HorizontalLayoutGroup>().enabled = false;

		for (int i = 0; i < 8; i++)
        {
            characters[i].SetActive(false);
        }

        tape.SetActive(false);

        moon.SetActive(false);

        house.SetActive(false);

        mountains.SetActive(false);
        trainField.SetActive(false);
    }

    private void setUI(int story)
    {
        backgroundArea.GetComponent<SpriteRenderer>().sprite = background[story - 1];
        backgroundArea.transform.localScale = new Vector3(backgroundSize[story - 1], backgroundSize[story - 1], 1);
        switch (story)
        {
            case 1:
                break;
            case 2:
                int j = 0;
                tape.SetActive(true);
                for (int i = 0; i < 8; i++)
                {
                    if (gameControllerScript.Characters[i])
                    {
                        int num = j % 4;
                        trackNum[i] = num;
                        characters[i].transform.localPosition = new Vector3(startPosX[num], startPosY, 0.0f);
                        j++;
                    }
                }
                studyControllerScript.Track = trackNum;
                break;
            case 3:
				character_area.GetComponent<HorizontalLayoutGroup>().enabled = true;
				character_area.transform.localPosition = new Vector3(0, -10f, 0);
				for (int i = 0; i < 8; i++)
				{
					if (gameControllerScript.Characters[i])
					{
						if (i == 7)
						{
							characters[i].transform.localScale = new Vector3(1.5f, 1.5f, 1);
						}
						else
						{
							characters[i].transform.localScale = new Vector3(2f, 2f, 1);
						}
						studyControllerScript.CreateFood(i);
					}
				}
                break;
            case 4:
                moon.SetActive(true);
                backgroundArea.GetComponent<SpriteRenderer>().color = back_color_moon;
                break;
            case 5:
				character_area.GetComponent<HorizontalLayoutGroup>().enabled = true;
				character_area.transform.localPosition = new Vector3(0, -12f, 0);
                int k = 0;
                house.SetActive(true);
                for(int i = 0; i < 8; i++)
                {
                    if (gameControllerScript.Characters[i])
                    {
                        if (i == 7)
                        {
                            characters[i].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                        }
                        else
                        {
                            characters[i].transform.localScale = new Vector3(2f, 2f, 2f);
                        }
                        studyControllerScript.CreateCandy(i);
                        k++;
                    }
                }
                break;
            case 6:
                trainField.SetActive(true);
                mountains.SetActive(true);
                for (int i = 0; i < 8; i++)
                {
                    if (gameControllerScript.Characters[i])
                    {
                        if(i == 7)
                        {
                            characters[i].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                        }
                        else
                        {
                            characters[i].transform.localScale = new Vector3(2f, 2f, 2f);
                        }
                        characters[i].transform.localPosition = new Vector3(train_characterX[i], train_characterY, 0);
                        characters[i].transform.parent = train[i].transform;
                    }
                }
                StartCoroutine(MoveMountains());
                break;
            default:
                Debug.Log("Error");
                break;
        }
	}

	#region train jump(5)
	IEnumerator MoveMountains()
    {
        if(mountains.transform.localPosition.x > 150)
        {
            mountains.transform.localPosition = new Vector3(-120, 0, 0);
            mountainAnimationEnd--;
        }
        else
        {
            mountains.transform.localPosition += new Vector3(2, 0, 0);
        }

        //if(mountainAnimationEnd == 0)
        //{
        //    studyControllerScript.AnimationEndFlag = true;
        //    yield break;
        //}

        yield return new WaitForSeconds(0.1f);
        yield return StartCoroutine(MoveMountains());
        yield break;
    }
	#endregion
}
