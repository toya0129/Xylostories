using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyControllerScript : MonoBehaviour {

    private GameControllerScript gameControllerScript;
    private StudySceneCanvasController studySceneCanvasController;
    private SerialReadScript serialReadScript;

    //
    private int mainStory;
    public int moveCharacter = 0;
    public GameObject[] characters;

    private string serialData = "";

    #region Run (2) many character
    public int[] track = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
    private int animationEnd = 10;
    [SerializeField]
    GameObject endflag;
    #endregion

    #region eat food (3) many character

    #endregion

    #region get moon (4) one character
    [SerializeField]
    GameObject moon;
    [SerializeField]
    GameObject rope;
    #endregion

    #region make candy house (5)
    [SerializeField]
    Sprite[] candy;
    #endregion

    #region jump train (6)

    #endregion

    // Use this for initialization
    void Start () {
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        //serialReadScript = GameObject.Find("SerialConecter").GetComponent<SerialReadScript>();
        mainStory = gameControllerScript.MainStory;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) { 
        //serialData = serialReadScript.OutData;
        //Debug.Log(serialReadScript.OutData);
        //if (serialReadScript.OutData != "")
        //{
            //switch (serialReadScript.OutData)
            //{
            //    case "CC":
            //        moveCharacter = 1;
            //        break;
            //    case "DD":
            //        moveCharacter = 2;
            //        break;
            //    case "EE":
            //        moveCharacter = 3;
            //        break;
            //    case "FF":
            //        moveCharacter = 4;
            //        break;
            //    case "GG":
            //        moveCharacter = 5;
            //        break;
            //    case "AA":
            //        moveCharacter = 6;
            //        break;
            //    case "BB":
            //        moveCharacter = 7;
            //        break;
            //    case "C2":
            //        moveCharacter = 8;
            //        break;
            //    default:
            //        moveCharacter = 0;
            //        break;
            //}

            if (Input.GetKeyDown(KeyCode.A))
            {
                moveCharacter = 1;
            }else if (Input.GetKeyDown(KeyCode.S))
            {
                moveCharacter = 2;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                moveCharacter = 3;
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                moveCharacter = 4;
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                moveCharacter = 5;
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                moveCharacter = 6;
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                moveCharacter = 7;
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                moveCharacter = 8;
            }
            else
            {
                moveCharacter = 0;
            }

            if (moveCharacter != 0)
            {
                switch (mainStory)
                {
                    case 1:

                        break;
                    case 2:
                        StartCoroutine(RunningAnimation(moveCharacter - 1, track[moveCharacter - 1], animationEnd));
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
            }
            //serialReadScript.OutData = "";
            moveCharacter = 0;
        }
    }


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


    #region jump train (6)



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
