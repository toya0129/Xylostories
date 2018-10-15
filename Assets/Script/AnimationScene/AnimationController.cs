using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    private int mainCharactar;

    private bool animationStartFlag;

    private Animator[] charactarAnimation = new Animator[7];
    private SpriteRenderer[] charactars = new SpriteRenderer[7];

    [SerializeField]
    GameObject hero;

    #region Bear
    private Vector3 bearPosition;
    private float bearRotation;
    private float roteY = 0.0f;
    private bool trunFlag;
    private int bearCount;
    #endregion

    // Use this for initialization
    void Start()
    {
        animationStartFlag = true;
        bearCount = 0;

        trunFlag = true;

        mainCharactar = 1;


        switch (mainCharactar)
        {
            case 1:
                BearAnimation();
                break;
            case 2:
                RabbitAnimation();
                break;
            case 3:

                break;
            case 4:

                break;



        }

    }

    // Update is called once per frame
    void Update()
    {

    }


    #region Bear Animation
    private void BearAnimation()
    {
        StartCoroutine(FindFriends());
    }

    IEnumerator FindFriends()
    {
        bearPosition = hero.transform.localPosition;
        if (trunFlag == true)
        {
            if (bearPosition.x > -20)
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
            if (bearPosition.x < 20)
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
        bearCount++;
        if (bearCount > 400)
        {
            yield break;
        }
        yield return StartCoroutine(FindFriends());
    }

    IEnumerator TrunCharactar()
    {
        bearRotation = hero.transform.localEulerAngles.y;
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

    #region RabbitAnimation
    private void RabbitAnimation()
    {

    }


    #endregion
}
