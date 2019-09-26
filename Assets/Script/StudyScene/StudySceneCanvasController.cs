using System;
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
    private GameObject xylophone_area;
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

    [SerializeField]
    private GameObject go_title;

    private float[] start_posx = { -70f, -60f, -50f, -40f, 40f, 50f, 60f, 70f };

    #region Find Friends (1)
    [SerializeField]
    private GameObject cloud_area;
    [SerializeField]
    private GameObject friend_parts_area;
    [SerializeField]
    private GameObject friend_area;
    [SerializeField]
    private GameObject friend;
    [SerializeField]
    private GameObject stream;
    #endregion

    #region Run on Track (2)
    [SerializeField]
    private GameObject tape;
    [SerializeField]
    private GameObject run_track_background;
    private float[] startPosX = { 2.5f, -5f, 5f, -3.5f };
    private float startPosY = 30f;
    #endregion

    #region eat food (3)
    [SerializeField]
    private GameObject food_prefub;
    [SerializeField]
    private Sprite[] food_sprite;
    private bool allow = true;
    private int food_end_flag = 50;
    #endregion


    #region Get Moon (4)
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
	private float startPosY_candy = -22f;
    [SerializeField]
    private GameObject house;
    [SerializeField]
    private GameObject candy_prefub;
    [SerializeField]
    private Sprite[] candy_sprite;
    [SerializeField]
    private List<GameObject> candy = new List<GameObject>();

    private int max_candy = 20;
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
    private float train_characterY = -6.5f;
    #endregion


    void Awake(){
        InitObject();
	}
		
	// Use this for initialization
	void Start () {
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        setCharacter();
        StartCoroutine(SetUI(gameControllerScript.MainStory));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator Xylophone_OnColor(int num)
    {
        StartCoroutine(gameControllerScript.SoundPlay(num));
        GameObject now = xylophone_area.transform.GetChild(num).gameObject;
        now.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        yield return new WaitForSeconds(0.5f);
        now.GetComponent<Image>().color = new Color32(255, 255, 255, 150);
        yield break;
    }

    private void setCharacter()
    {
        for (int i = 0; i < 8; i++)
        {
            if (gameControllerScript.Characters[i])
            {
                characters[i].SetActive(true);
                xylophone_area.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    private void InitObject()
    {
        go_title.SetActive(false);
        canvas_front.SetActive(true);
        main_camera.SetActive(true);

        character_area.transform.localPosition = new Vector3(0, 0, 0);
		character_area.GetComponent<HorizontalLayoutGroup>().enabled = false;

        xylophone_area.SetActive(false);

        for (int i = 0; i < 8; i++)
        {
            characters[i].SetActive(false);
            xylophone_area.transform.GetChild(i).gameObject.SetActive(false);
        }

        cloud_area.SetActive(false);
        friend_parts_area.SetActive(false);
        friend_area.SetActive(false);

        tape.SetActive(false);

        rope.SetActive(false);
        get_moon_background.SetActive(false);
        moon.SetActive(false);

        house.SetActive(false);

        mountains.SetActive(false);
        trainField.SetActive(false);
    }

    private IEnumerator SetUI(int story)
    {
        backgroundArea.GetComponent<SpriteRenderer>().sprite = background[story - 1];
        backgroundArea.transform.localScale = new Vector3(backgroundSize[story - 1], backgroundSize[story - 1], 1);
        switch (story)
        {
            case 1:
                character_area.SetActive(false);
                character_area.transform.localPosition = new Vector3(0f, -9f, 0f);
                yield return StartCoroutine(FriendWalk_OnFlower());
                yield return StartCoroutine(UpToFriends());
                character_area.SetActive(true);
                yield return StartCoroutine(SetStartPos());
                yield return StartCoroutine(DownClouds());
                character_area.GetComponent<HorizontalLayoutGroup>().enabled = true;

                for(int i = 0; i < 8; i++)
                {
                    characters[i].transform.parent = cloud_area.transform.GetChild(i).gameObject.transform;
                    characters[i].transform.localPosition = new Vector3(0f, -1f, 0f);
                }
                break;
            case 2:
                int j = 0;
                run_track_background.SetActive(true);
                main_camera.transform.localPosition = new Vector3(0, 35f, -30f);
                tape.SetActive(true);
                character_area.transform.localPosition = new Vector3(0, 26f, 0);
                yield return StartCoroutine(SetStartPos());
                yield return StartCoroutine(MainCameraSet());
                for (int i = 0; i < 8; i++)
                {
                    if (gameControllerScript.Characters[i])
                    {
                        int num = j % 4;
                        characters[i].transform.localPosition = new Vector3(startPosX[num], startPosY, 0.0f);
                        characters[i].GetComponent<SpriteRenderer>().sortingOrder = 5;
                        characters[i].GetComponent<CharacterMoveScript>().Track = num;
                        j++;
                    }
                }
                character_area.transform.localPosition = new Vector3(0, 0, 0);
                break;
            case 3:
                character_area.transform.localPosition = new Vector3(0f, -9f, 0f);
                yield return StartCoroutine(SetStartPos());
                character_area.GetComponent<HorizontalLayoutGroup>().enabled = true;
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
                        StartCoroutine(FallFood(characters[i]));
                    }
                }
                character_area.transform.localPosition = new Vector3(0f, -2f, 0f);
                character_area.GetComponent<HorizontalLayoutGroup>().enabled = true;
                break;
            case 4:
                moon.SetActive(true);
                get_moon_background.SetActive(true);
                backgroundArea.GetComponent<SpriteRenderer>().color = back_color_moon;
                character_area.transform.localPosition = new Vector3(17f, -18f, 0f);
                for (int i = 0; i < characters.Length; i++)
                {
                    characters[i].SetActive(false);
                }
                for (int i = 0; i < characters.Length; i++)
                {
                    if (gameControllerScript.Characters[i])
                    {
                        characters[i].SetActive(true);
                        characters[i].transform.localPosition = new Vector3(0f, 0f, 0f);
                        break;
                    }
                }
                rope.SetActive(true);
                yield return StartCoroutine(ThrowRope());
                for (int i = 0; i < characters.Length; i++)
                {
                    if (gameControllerScript.Characters[i])
                    {
                        characters[i].SetActive(true);
                    }
                }
                character_area.GetComponent<HorizontalLayoutGroup>().enabled = true;
                break;
            case 5:
                character_area.GetComponent<HorizontalLayoutGroup>().enabled = true;
                character_area.transform.localPosition = new Vector3(0f, -9f, 0f);
                int k = 0;
                house.SetActive(true);
                yield return StartCoroutine(SetStartPos());
                for (int i = 0; i < 8; i++)
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
                        CreateCandy(i);
                        k++;
                    }
                }
                character_area.GetComponent<HorizontalLayoutGroup>().enabled = true;
                character_area.transform.localPosition = new Vector3(0f, -5f, 0f);
                break;
            case 6:
                trainField.SetActive(true);
                mountains.SetActive(true);
                for (int i = 0; i < 8; i++)
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
                        characters[i].transform.localPosition = new Vector3(train_characterX[i], train_characterY, 0);
                        characters[i].transform.parent = train[i].transform;
                    }
                }
                StartCoroutine(MoveMountains());
                yield return StartCoroutine(StartOfTrain());
                break;
            default:
                Debug.Log("Error");
                break;
        }

        studyControllerScript.AnimationStartFlag = true;
        xylophone_area.SetActive(true);
        go_title.SetActive(true);
        yield break;
    }

    private IEnumerator SetStartPos()
    {
        List<float> pos = new List<float>();
        bool trigger = true;
        character_area.GetComponent<HorizontalLayoutGroup>().enabled = true;
        character_area.GetComponent<HorizontalLayoutGroup>().enabled = false;
        for (int i = 0; i < 8; i++)
        {
            pos.Add(characters[i].transform.localPosition.x);
        }

        for (int i = 0; i < 8; i++)
        {
            characters[i].transform.localPosition = new Vector3(start_posx[i], -7.5f, 0);
        }

        while (trigger)
        {
            for (int i = 0; i < 4; i++)
            {
                if (characters[i].transform.localPosition.x < pos[i])
                {
                    characters[i].transform.localPosition += new Vector3(0.5f, 0, 0);
                    trigger = true;
                }
                else
                {
                    trigger = false;
                }
            }
            for (int i = 4; i < 8; i++)
            {
                if (characters[i].transform.localPosition.x > pos[i])
                {
                    characters[i].transform.localPosition -= new Vector3(0.5f, 0f, 0);
                    trigger = true;
                }
                else
                {
                    trigger = false;
                }
            }
            yield return new WaitForSeconds(0.0005f);
        }
        yield break;
    }

    private IEnumerator MainCameraSet()
    {
        while(Math.Abs(main_camera.transform.localPosition.y) > 0)
        {
            main_camera.transform.localPosition -= new Vector3(0, 1f, 0);
            yield return new WaitForSeconds(0.005f);
        }
        yield break;
    }

    #region Find Friends (1)
    private IEnumerator FriendWalk_OnFlower()
    {
        friend_parts_area.SetActive(true);
        friend_area.SetActive(true);

        friend.transform.localPosition = new Vector3(40f, -17f, 0);

        // walk
        while(friend.transform.localPosition.x > 10f)
        {
            friend.transform.localPosition -= new Vector3(0.1f, 0, 0);
            yield return new WaitForSeconds(0.000001f);
        }

        yield return new WaitForSeconds(1f);

        // on flower
        while(friend.transform.localPosition.x > 0f)
        {
            friend.transform.localPosition -= new Vector3(0.1f, -0.08f, 0);
            yield return new WaitForSeconds(0.0000005f);
        }
        yield break;
    }

    private IEnumerator UpToFriends()
    {
        while (friend_area.transform.localPosition.y < 45f)
        {
            stream.transform.localScale += new Vector3(0, 0.1f, 0);
            friend_area.transform.localPosition += new Vector3(0, 1f, 0);
            stream.transform.localPosition -= new Vector3(0, 1f, 0);
            main_camera.transform.localPosition += new Vector3(0, 1f, 0);
            yield return new WaitForSeconds(0.05f);
        }
        main_camera.transform.localPosition = new Vector3(0f, 0f, -30f);
        yield break;
    }
    private IEnumerator DownClouds()
    {
        cloud_area.SetActive(true);
        while (cloud_area.transform.localPosition.y > -8f)
        {
            cloud_area.transform.localPosition -= new Vector3(0, 1f, 0);
            yield return new WaitForSeconds(0.005f);
        }

        yield return new WaitForSeconds(1f);

        cloud_area.transform.localPosition = new Vector3(0f, 0f, 0f);

        for (int i = 0; i < 8; i++)
        {
            if (!characters[i].activeSelf)
            {
                cloud_area.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        yield break;
    }
    #endregion

    #region Eat Food(3)
    public IEnumerator FallFood(GameObject parent_obj)
    {
        int rand = UnityEngine.Random.Range(0, 3);
        bool fall_trigger = true;

        GameObject obj = Instantiate(food_prefub);
        Transform parent_transform = parent_obj.transform;

        obj.GetComponent<SpriteRenderer>().sprite = food_sprite[rand];
        obj.transform.parent = parent_transform;
        obj.transform.localPosition = new Vector3(0, 20f, 0);

        while (fall_trigger)
        {

            obj.transform.localPosition -= new Vector3(0, 0.5f, 0);

            if (parent_obj.name == "rabbit")
            {
                if (obj.transform.localPosition.y <= 1.5f)
                {
                    fall_trigger = false;
                }
            }
            else
            {
                if (obj.transform.localPosition.y <= 3f)
                {
                    fall_trigger = false;
                }
            }
            yield return new WaitForSeconds(0.005f);
        }

 //       food_end_flag--;
        if(food_end_flag < 0)
        {
            studyControllerScript.AnimationEndFlag = true;
        }

        yield break;
    }
    #endregion

    #region Get Moon(4)
    private IEnumerator ThrowRope()
    {
        yield return new WaitForSeconds(1f);

        canvas_front.SetActive(false);
        while (main_camera.transform.localPosition.x > -62f)
        {
            main_camera.transform.localPosition -= new Vector3(1f, 0f, 0f);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1f);
        while (main_camera.transform.localPosition.x < 0)
        {
            main_camera.transform.localPosition += new Vector3(1f, 0f, 0f);
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1f);
        rope.GetComponent<SpriteRenderer>().sprite = rope_sprite_middle;
        rope.transform.localPosition = new Vector3(0f, -3f, 0f);
        rope.transform.localScale = new Vector3(2f, 1.5f, 1f);
        yield return new WaitForSeconds(1f);

        while(rope.transform.localPosition.x > -62f)
        {
            main_camera.transform.localPosition -= new Vector3(1f, 0f, 0f);
            rope.transform.localPosition -= new Vector3(1f, -0.03f, 0f);
            yield return new WaitForSeconds(0.02f);
        }

        main_camera.transform.localPosition = new Vector3(0f, 0f, -30f);
        rope.transform.localPosition = new Vector3(-62f, 2f, 0);
        rope.transform.localScale = new Vector3(2f, 1f, 1f);
        canvas_front.SetActive(true);

        character_area.transform.localPosition = new Vector3(0f, -2f, 0f);
        character_area.GetComponent<HorizontalLayoutGroup>().enabled = true;

        moon.transform.parent = rope.transform;
        yield break;
    }
    #endregion

    #region Create Candy (5)
    public void CreateCandy(int number)
    {
        //if (candy.Count > max_candy)
        //{
        //    studyControllerScript.AnimationEndFlag = true;
        //    return;
        //}
        int rand = UnityEngine.Random.Range(0, 2);

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

    #region train jump(6)
    private IEnumerator StartOfTrain()
    {
        GameObject train_all = trainField.transform.GetChild(0).gameObject;
        train_all.transform.localPosition = new Vector3(70f, 0, 0);
        while(Math.Abs(train_all.transform.localPosition.x) > 0)
        {
            train_all.transform.localPosition -= new Vector3(1f, 0, 0);
            yield return new WaitForSeconds(0.001f);
        }
        train_all.transform.localPosition -= new Vector3(1f, 0, 0);
        yield break;
    }

    private IEnumerator MoveMountains()
    {
        while (mountainAnimationEnd != 0)
        {
            if (mountains.transform.localPosition.x > 150)
            {
                mountains.transform.localPosition = new Vector3(-120, 0, 0);
                //mountainAnimationEnd--;
            }
            else
            {
                mountains.transform.localPosition += new Vector3(2, 0, 0);
            }
            yield return new WaitForSeconds(0.1f);
        }
        studyControllerScript.AnimationEndFlag = true;
        yield break;
    }
	#endregion
}
