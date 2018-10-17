using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    private int mainCharacter;

    [SerializeField]
    RuntimeAnimatorController[] characterAnimation = new RuntimeAnimatorController[7];

    [SerializeField]
    Sprite[] characters = new Sprite[7];

    [SerializeField]
    Sprite[] background = new Sprite[7]; //0:1.61 1:3.1 
    private float[] backgroundScale = new float[] { 1.61f, 3.1f };

    [SerializeField]
    GameObject hero;
    [SerializeField]
    GameObject backgroundField;

    [SerializeField]
    GameControllerScript gameControllerScript;

    #region Animation 
    private float roteY;
    private float roteZ;
    private bool trunFlag = true;
    private int moveCount = 0;
    private int shakeCount = 0;
    #endregion

    #region Bear
    private int bearMoveEnd = 400; //Animation End Flag
    #endregion

    #region Rabbit
    private int rabbitMoveEnd = 350; //Animation End Flag
    [SerializeField]
    Sprite rabbit_back;
    #endregion

    #region Fox
    private int foxShakeEnd = 240; // Animation End Flag
    [SerializeField]
    GameObject moon;
    [SerializeField]
    GameObject rope;
    #endregion


    // Use this for initialization
    void Start()
    {
        //        gameControllerScript = GameObject.Find("GameController").GetComponent<GameControllerScript>();

        mainCharacter = 0;
        //mainCharactar = gameControllerScript.MainCharacter;

        //CharacterSet();

        switch (mainCharacter)
        {
            case 1:
                StartCoroutine(BearAnimation());
                break;
            case 2:
                StartCoroutine(RabbitAnimation());
                break;
            case 3:
                StartCoroutine(TigerAnimation());
                break;
            case 0:
                StartCoroutine(FoxAnimation());
                break;
            case 5:

                break;
            case 6:

                break;
            case 7:

                break;
            case 8:

                break;
            default:
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CharacterSet()
    {
        hero.GetComponent<SpriteRenderer>().sprite = characters[mainCharacter - 1];
        hero.GetComponent<Animator>().runtimeAnimatorController = characterAnimation[mainCharacter - 1];
        backgroundField.GetComponent<SpriteRenderer>().sprite = background[mainCharacter - 1];
        backgroundField.transform.localScale = new Vector3(backgroundScale[mainCharacter - 1], backgroundScale[mainCharacter - 1], 1);
    }

    #region Common Character Animation
    IEnumerator CharacterMove(int endCount) // Move a Characters Left and Right
    {
        if (trunFlag == true)
        {
            if (hero.transform.localPosition.x > -20)
            {
                hero.transform.localPosition -= new Vector3(0.3f, 0, 0);
            }
            else
            {
                yield return StartCoroutine(TrunCharactar());
                trunFlag = false;
            }
        }
        else if (trunFlag == false)
        {
            if (hero.transform.localPosition.x < 20)
            {
                hero.transform.localPosition += new Vector3(0.3f, 0, 0);
            }
            else
            {
                yield return StartCoroutine(TrunCharactar());
                trunFlag = true;
            }
        }
        yield return new WaitForSeconds(0.005f);

        moveCount++;

        if (endCount < moveCount)
        {
            yield break;
        }

        yield return StartCoroutine(CharacterMove(endCount));
    }

    IEnumerator TrunCharactar() // Trun a Characters (y)
    {
        if (trunFlag == true)
        {
            if (roteY < 180)
            {
                hero.transform.localRotation = Quaternion.Euler(0, roteY, 0);
                roteY += 5.0f;
            }
            else
            {
                yield break;
            }
        }
        else if (trunFlag == false)
        {
            if (roteY > 0)
            {
                hero.transform.localRotation = Quaternion.Euler(0, roteY, 0);
                roteY -= 5.0f;
            }
            else
            {
                yield break;
            }
        }
        yield return new WaitForSeconds(0.005f);
        yield return StartCoroutine(TrunCharactar());
    }

    IEnumerator ShakeCharacter(int endCount){
        if (trunFlag == true)
        {
            if (roteZ < 13)
            {
                hero.transform.localRotation = Quaternion.Euler(0, 0, roteZ);
                roteZ += 0.5f;
            }
            else
            {
                trunFlag = false;
            }
        }
        else if (trunFlag == false)
        {
            if (roteZ > -13)
            {
                hero.transform.localRotation = Quaternion.Euler(0, 0, roteZ);
                roteZ -= 0.5f;
            }
            else
            {
                trunFlag = true;
            }
        }
        shakeCount++;
        if(endCount < shakeCount){
            yield break;
        }
        yield return new WaitForSeconds(0.005f);
        yield return StartCoroutine(ShakeCharacter(endCount));
    }
    #endregion

    #region Bear Animation (Friend Find)
    IEnumerator BearAnimation()
    {
        yield return StartCoroutine(CharacterMove(bearMoveEnd));
        Debug.Log("Bear Animation End");
        //gameControllerScript.OnLoadStudy();
    }
    #endregion

    #region RabbitAnimation (Go Back Home)
    IEnumerator RabbitAnimation()
    {
        hero.transform.localPosition = new Vector3(25.0f, -17.0f, 0);
        yield return StartCoroutine(CharacterMove(rabbitMoveEnd));
        yield return new WaitForSeconds(1.0f); // delay
        yield return StartCoroutine(TrunCharactar());
        hero.GetComponent<Animator>().enabled = false;
        hero.GetComponent<SpriteRenderer>().sprite = rabbit_back;
        yield return StartCoroutine(GoBackHome());
        Debug.Log("Rabbit Animation End");
        //gameControllerScript.OnLoadStudy();
    }

    IEnumerator GoBackHome()
    {
        if (hero.transform.localScale.x > 0)
        {
            hero.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            hero.transform.localPosition += new Vector3(0.0f, 0.5f, 0.0f);
        }
        else
        {
            yield break;
        }
        yield return new WaitForSeconds(0.1f);
        yield return StartCoroutine(GoBackHome());
    }
    #endregion

    #region TigerAnimation (Running)
    IEnumerator TigerAnimation(){
        hero.transform.localPosition = new Vector3(0.0f, 12.0f, 0);
        hero.transform.localScale= new Vector3(1.0f, 1.0f, 1.0f);
        yield return StartCoroutine(RunningAnimation());
        Debug.Log("End Tiger Animation");
        //gameControllerScript.OnLoadStudy();
        yield break;
    }

    IEnumerator RunningAnimation()
    {
        if (hero.transform.localPosition.y > -35.0f)
        {
            hero.transform.localScale += new Vector3(0.05f, 0.05f, 0);
            hero.transform.localPosition -= new Vector3(0.0f, 0.4f, 0.0f);
        }
        else
        {
            yield break;
        }
        yield return new WaitForSeconds(0.1f);
        yield return StartCoroutine(RunningAnimation());
    }
    #endregion

    #region FoxAnimation (Get Moon)
    IEnumerator FoxAnimation(){
        hero.transform.localPosition = new Vector3(25.0f, -17.0f, 0);
        //moon.SetActive(true);
        yield return StartCoroutine(ShakeCharacter(foxShakeEnd));
        rope.SetActive(true);
        yield return StartCoroutine(ThrowRope());
        Debug.Log("End Fox Animation");
        //gameControllerScript.OnLoadStudy();
        yield break;
    }

    IEnumerator ThrowRope(){
        if (rope.transform.localPosition.x > -18.0f)
        {
            rope.transform.localPosition -= new Vector3(0.2f, 0.1f, 0);
        }
        else
        {
            yield break;
        }
        yield return new WaitForSeconds(0.1f);
        yield return StartCoroutine(ThrowRope());
    }

    IEnumerator GetMoon(){
        yield break;
    }

    #endregion

    #region PigAnimation (Candy House)


    #endregion

    #region GiraffeAnimation (Eat Reef)


    #endregion

    #region MonkeyAnimation (Train)


    #endregion
}