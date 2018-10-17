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
    private float[] backgroundScal = new float[] { 1.61f, 3.1f };

    [SerializeField]
    GameObject hero;
    [SerializeField]
    GameObject backgroundField;

    [SerializeField]
    GameControllerScript gameControllerScript;

    #region Animation 
    private float roteY;
    private bool trunFlag = true;
    private int animationCount = 0;
    #endregion

    #region Bear
    private int bearEnd = 400; //Animation End Flag
    #endregion

    #region Rabbit
    private int rabbitEnd = 350; //Animation End Flag
    [SerializeField]
    Sprite rabbit_back;
    #endregion

    // Use this for initialization
    void Start()
    {
        //        gameControllerScript = GameObject.Find("GameController").GetComponent<GameControllerScript>();

        mainCharacter = 1;
        //mainCharactar = gameControllerScript.MainCharacter;

        CharacterSet();

        switch (mainCharacter)
        {
            case 1:
                StartCoroutine(BearAnimation());
                break;
            case 2:
                StartCoroutine(RabbitAnimation());
                break;
            case 3:

                break;
            case 4:

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
        backgroundField.transform.localScale = new Vector3(backgroundScal[mainCharacter - 1], backgroundScal[mainCharacter - 1], 1);
    }

    #region Common Character Animation
    IEnumerator CharacterMove(int endCount)
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

        animationCount++;

        if (endCount < animationCount)
        {
            yield break;
        }

        yield return StartCoroutine(CharacterMove(endCount));
    }

    IEnumerator TrunCharactar()
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

    #endregion

    #region Bear Animation (Friend Find)
    IEnumerator BearAnimation()
    {
        yield return StartCoroutine(CharacterMove(bearEnd));
        Debug.Log("Bear Animation End");
        //gameControllerScript.OnLoadStudy();
    }
    #endregion

    #region RabbitAnimation (Go Back Home)
    IEnumerator RabbitAnimation()
    {
        hero.transform.localPosition = new Vector3(25.0f, -17.0f, 0);
        yield return StartCoroutine(CharacterMove(rabbitEnd));
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



    #endregion

    #region FoxAnimation (Get Moon)



    #endregion

    #region PigAnimation (Candy House)


    #endregion

    #region GiraffeAnimation (Eat Reef)


    #endregion

    #region MonkeyAnimation (Train)


    #endregion
}