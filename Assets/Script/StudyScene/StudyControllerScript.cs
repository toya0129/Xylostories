using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyControllerScript : MonoBehaviour {

    private GameControllerScript gameControllerScript;
    private StudySceneCanvasController studySceneCanvasController;
    private SerialReadScript serialReadScript;

    private int mainStory;
    public int moveCharacter = 0;
    public GameObject[] characters;

    private string serialData = "";

    #region Run
    private int[] track = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
    private int animationEnd = 10;
    [SerializeField]
    GameObject endflag;
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

            if(moveCharacter != 0)
            {
                StartCoroutine(RunningAnimation(moveCharacter - 1, track[moveCharacter - 1],animationEnd));
            }
            /*switch (moveCharacter)
            {
                case 1:
                    StartCoroutine(RunningAnimation(moveCharacter - 1, track[moveCharacter - 1]));
                    break;
                default:
                    break;
            }*/
            serialReadScript.OutData = "";
            //moveCharacter = 0;
        }
    }


    #region Animation Run
    IEnumerator RunningAnimation(int number,int trackNum,int animationCount)
    {
        if (characters[number].transform.localPosition.y > -25.0f)
        {
            switch (trackNum)
            {
                case 0:
                    characters[number].transform.localScale += new Vector3(0.01f, 0.01f, 0);
                    characters[number].transform.localPosition -= new Vector3(0.006f, 0.4f, 0.0f);
                    //characters[number].transform.localScale += new Vector3(0.5f, 0.5f, 0);
                    //characters[number].transform.localPosition -= new Vector3(0.3f, 20.0f, 0.0f);
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
            AnimationFinish();
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
            yield return StartCoroutine(RunningAnimation(number, trackNum,animationEnd));
        }

        yield break;
    }

    public int[] Track
    {
        set { track = value; }
    }
    #endregion


    private void AnimationFinish()
    {
        endflag.SetActive(true);
        LoadTitle();
    }

    public void LoadTitle()
    {
        gameControllerScript.OnLoadTitle();
    }
}
