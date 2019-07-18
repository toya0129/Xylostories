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
    private float[] backgroundSize = new float[] { 1.61f, 3.1f ,1.61f,1.61f,1.61f, 3.1f};

    [SerializeField] 
    GameObject[] characters;

    [SerializeField]
    List<Sprite> background = new List<Sprite>();

    #region Run on Track (2)
    [SerializeField]
    GameObject tape;
    private float[] startPosX = new float[] { 2.5f, -5f, 5f, -3.5f };
    private float startPosY = 30f;
    private int[] trackNum = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
    #endregion

    #region Train (5)
    [SerializeField]
    GameObject trainField;
    [SerializeField]
    List<GameObject> train;
    [SerializeField]
    GameObject mountains;
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
            if (gameControllerScript.Characters[i] == true)
            {
                characters[i].SetActive(true);
            }
        }
    }

    private void InitObject()
    {
        for (int i = 0; i < 8; i++)
        {
            characters[i].SetActive(false);
        }

        tape.SetActive(false);

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
                    if (gameControllerScript.Characters[i] == true)
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
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                trainField.SetActive(true);
                mountains.SetActive(true);
                StartCoroutine(MoveMountains());
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    IEnumerator MoveMountains()
    {
        if(mountains.transform.localPosition.x > 150)
        {
            mountains.transform.localPosition = new Vector3(-120, 0, 0);
        }
        else
        {
            mountains.transform.localPosition += new Vector3(2, 0, 0);
        }

        yield return new WaitForSeconds(0.1f);
        yield return StartCoroutine(MoveMountains());
        yield break;
    }
}
