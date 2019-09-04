using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudySceneCanvasController : MonoBehaviour {

	[SerializeField]
    private GameControllerScript gameControllerScript;

    [SerializeField]
    private StudyControllerScript studyControllerScript;

    [SerializeField]
    private GameObject main_camera;
    [SerializeField]
    private GameObject canvas_front;

    [SerializeField]
    private GameObject backgroundArea;
    private float[] backgroundSize = { 1.61f, 3.1f ,1.61f,3.1f,1.61f, 3.1f};

	[SerializeField]
    private GameObject character_area;

    [SerializeField]
    private GameObject[] characters;

    [SerializeField]
    private List<Sprite> background = new List<Sprite>();

    #region Run on Track (2)
    [SerializeField]
    private GameObject tape;
    private float[] startPosX = { 2.5f, -5f, 5f, -3.5f };
    private float startPosY = 30f;
    private int[] trackNum = { 0, 0, 0, 0, 0, 0, 0, 0 };
    #endregion

    #region eat food (3)


    #endregion


    #region Get Moon (4)
    [SerializeField]
    private GameObject moon_camera;
    private Vector3 camera_pos_get_moon = new Vector3(-62, 0 - 30);
    private Color32 back_color_moon = new Color32(5, 5, 70, 255);
    [SerializeField]
    private GameObject moon;
    [SerializeField]
    private GameObject rope;
    [SerializeField]
    private Sprite rope_sprite_middle;
    [SerializeField]
    private GameObject get_moon_background;
	#endregion

	#region Make Candy House (5) scale 2
	//private float[] startPosX_candy = { -4f, 4f, -12f, 12f, -20f, 20f, -28f, 28f };
	private float[] startPosX_candy = { -28f,-20f, -12f,-4f, 4f, 12f, 20f,28f };
	private float startPosY_candy = -22f;
    [SerializeField]
    private GameObject house;
    #endregion

    #region Train (6)
    [SerializeField]
    private GameObject trainField;
    [SerializeField]
    private List<GameObject> train;
    [SerializeField]
    private GameObject mountains;

    private int mountainAnimationEnd = 2;
    private float[] train_characterX = { -17f, -10f, -4f, 2.3f, 8.7f, 15f, 21.5f, 28f };
    private float train_characterY = -11;
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
        canvas_front.SetActive(true);
        main_camera.SetActive(true);

        character_area.transform.localPosition = new Vector3(0, 0, 0);
		character_area.GetComponent<HorizontalLayoutGroup>().enabled = false;

		for (int i = 0; i < 8; i++)
        {
            characters[i].SetActive(false);
        }

        tape.SetActive(false);

        moon_camera.SetActive(false);
        rope.SetActive(false);
        get_moon_background.SetActive(false);
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
				character_area.transform.localPosition = new Vector3(0f, -10f, 0f);
				for (int i = 0; i < 8; i++)
				{
					if (gameControllerScript.Characters[i])
					{
						if (i == 7)
						{
							characters[i].transform.localScale = new Vector3(1.5f, 1.5f, 1f);
						}
						else
						{
							characters[i].transform.localScale = new Vector3(2f, 2f, 1f);
						}
						studyControllerScript.CreateFood(i);
					}
				}
                break;
            case 4:
                moon_camera.SetActive(true);
                moon.SetActive(true);
                get_moon_background.SetActive(true);
                backgroundArea.GetComponent<SpriteRenderer>().color = back_color_moon;
                character_area.transform.localPosition = new Vector3(17f, -18f, 0f);
                for(int i = 0; i < characters.Length; i++)
                {
                    characters[i].SetActive(false);
                }
                for(int i = 0; i < characters.Length; i++)
                {
                    if (gameControllerScript.Characters[i])
                    {
                        characters[i].SetActive(true);
                        characters[i].transform.localPosition = new Vector3(0f, 0f, 0f);
                        break;
                    }
                }
                rope.SetActive(true);
                StartCoroutine(ThrowRope());
                break;
            case 5:
				character_area.GetComponent<HorizontalLayoutGroup>().enabled = true;
				character_area.transform.localPosition = new Vector3(0f, -12f, 0f);
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

        if (story != 4)
        {
            studyControllerScript.AnimationStartFlag = true;
        }
    }

    #region Get Moon(4)
    IEnumerator ThrowRope()
    {
        yield return new WaitForSeconds(1f);

        canvas_front.SetActive(false);
        main_camera.SetActive(false);
        while (moon_camera.transform.localPosition.x > -62f)
        {
            moon_camera.transform.localPosition -= new Vector3(1f, 0f, 0f);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1f);
        while (moon_camera.transform.localPosition.x < 0)
        {
            moon_camera.transform.localPosition += new Vector3(1f, 0f, 0f);
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1f);
        rope.GetComponent<SpriteRenderer>().sprite = rope_sprite_middle;
        rope.transform.localPosition = new Vector3(0f, -3f, 0f);
        rope.transform.localScale = new Vector3(2f, 1.5f, 1f);
        yield return new WaitForSeconds(1f);

        while(rope.transform.localPosition.x > -62f)
        {
            moon_camera.transform.localPosition -= new Vector3(1f, 0f, 0f);
            rope.transform.localPosition -= new Vector3(1f, -0.03f, 0f);
            yield return new WaitForSeconds(0.02f);
        }

        moon_camera.GetComponent<Camera>().rect = new Rect(0.7f, 0.7f, 0.3f, 0.3f);
        main_camera.SetActive(true);
        canvas_front.SetActive(true);

        character_area.transform.localPosition = new Vector3(0f, -10f, 0f);
        character_area.GetComponent<HorizontalLayoutGroup>().enabled = true;

        for(int i = 0; i < characters.Length; i++)
        {
            if (gameControllerScript.Characters[i])
            {
                characters[i].SetActive(true);
            }
        }

        moon.transform.parent = rope.transform;

        studyControllerScript.AnimationStartFlag = true;
        yield break;
    }
    #endregion

    #region train jump(5)
    IEnumerator MoveMountains()
    {
        while (mountainAnimationEnd != 0)
        {
            if (mountains.transform.localPosition.x > 150)
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
        }
        yield break;
    }
	#endregion
}
