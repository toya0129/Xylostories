using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudySceneCanvasController : MonoBehaviour {

	
     [SerializeField] GameControllerScript gameControllerScript;

    [SerializeField]
    GameObject backgroundArea;
    private float[] backgroundSize = new float[] { 1.61f, 3.1f ,1.61f,1.61f,1.61f, 1.61f};

    [SerializeField] 
    GameObject[] characters;

    [SerializeField]
    List<Sprite> background = new List<Sprite>();

    #region Run on Track (2)
    [SerializeField]
    GameObject tape;
    private float[] startPosX = new float[] { 2.5f, -5f, 5f, -3.5f };
    private float startPosY = 30f;
    #endregion

    #region Train (5)
    [SerializeField]
    GameObject trainField;
    #endregion


    void Awake(){
		for (int i = 0; i < 8; i++) {
			characters [i].SetActive (false);
		}

        tape.SetActive(false);
	}
		
	// Use this for initialization
	void Start () {
        //gameControllerScript = GameObject.Find("GameController").GetComponent<GameControllerScript>();
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
                        characters[i].transform.localPosition = new Vector3(startPosX[j], startPosY, 0.0f);
                        j++;
                    }
                }
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            default:
                break;
        }
    }

}
