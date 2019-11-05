using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveScript : MonoBehaviour {

    private StudySceneCanvasController studySceneCanvasController;

    // bear=0, rabbit=1, tiger=2, fox=3, pig=4, girafte=5, monkey=6, small_bear=7
    [SerializeField]
    private int this_character_number;

    #region Run (2) many character
    private int track = 0;
    private int runAnimationEnd = 10;
    #endregion

    #region eat food (3) many character
    private int eat_count = 0;
    private int eat_end_flag = 10;
    #endregion

    private IEnumerator animation = null;

    private void Start()
    {
        studySceneCanvasController = GameObject.Find("Canvas").GetComponent<StudySceneCanvasController>();
    }

    private void AnimationFinish()
    {
        GameObject.Find("StudyController").GetComponent<StudyControllerScript>().AnimationEndFlag = true;
        this.gameObject.GetComponent<CharacterMoveScript>().enabled = false;
    }

    public void AnimationStart(int story)
    {
        if (animation != null)
        {
            StopCoroutine(animation);
            animation = null;
        }

        switch (story)
        {
            case 1:
                animation = CharacterJump_Cloud();
                break;
            case 2:
                animation = RunningAnimation();
                break;
            case 3:
                animation = EatFood();
                break;
            case 4:
                animation = PullRope();
                break;
            case 5:
                animation = ShootStartCandy();
                break;
            case 6:
                animation = JumpCharacter_OnTrain();
                break;
            default:
                animation = null;
                break;
        }

        StartCoroutine(animation);
    }

    #region Find Friends (1)
    public IEnumerator CharacterJump_Cloud()
    {
        this.gameObject.transform.localPosition = new Vector3(0, 1f, 0);
        yield return new WaitForSeconds(0.5f);
        this.gameObject.transform.localPosition = new Vector3(0, -1f, 0);
        this.gameObject.transform.parent.transform.localPosition += new Vector3(0f, 1f, 0f);
        Camera.main.transform.localPosition += new Vector3(0f, 0.1f, 0f);

        if(this.gameObject.transform.parent.transform.localPosition.y > 35f)
        {
            Camera.main.transform.localPosition = new Vector3(0f, 42f, -30f);
            AnimationFinish();
        }

        yield break;
    }
    #endregion

    #region Animation Run (2)
    public IEnumerator RunningAnimation()
    {
        int animationCount = runAnimationEnd;
        while (animationCount != 0)
        {
            if (this.gameObject.transform.localPosition.y > -25.0f)
            {
                switch (track)
                {
                    case 0:
                        this.gameObject.transform.localPosition -= new Vector3(0.001f, 0.1f, 0.0f);
                        break;
                    case 1:
                        this.gameObject.transform.localPosition -= new Vector3(0.02f, 0.1f, 0.0f);
                        break;
                    case 2:
                        this.gameObject.transform.localPosition -= new Vector3(-0.02f, 0.1f, 0.0f);
                        break;
                    case 3:
                        this.gameObject.transform.localPosition -= new Vector3(0.001f, 0.1f, 0.0f);
                        break;
                }
                this.gameObject.transform.localScale += new Vector3(0.005f, 0.005f, 0);
            }
            else
            {
                AnimationFinish();
                yield break;
            }

            yield return new WaitForSeconds(0.01f);
            animationCount--;
        }
        yield break;
    }

    public int Track
    {
        set { track = value; }
    }
    #endregion

    #region Eat Food (3)
    public IEnumerator EatFood()
    {
        while (this.gameObject.transform.localScale.x <= 3)
        {
            this.gameObject.transform.localScale += new Vector3(0.1f, 0.01f, 0.1f);
        }

        yield return new WaitForSeconds(0.2f);

        while (this.gameObject.transform.localScale.x >= 2)
        {
            this.gameObject.transform.localScale -= new Vector3(0.1f, 0.01f, 0.1f);
        }
        eat_count++;

        if (eat_count == eat_end_flag)
        {
            eat_count = 0;
            this.gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            Destroy(this.gameObject.transform.GetChild(0).gameObject);
            StartCoroutine(studySceneCanvasController.FallFood(this.gameObject));
        }
        yield break;
    }
    #endregion

    #region Get Moon (4)
    public IEnumerator PullRope()
    {
        GameObject rope = GameObject.Find("rope");

        Transform now_character_pos_moon = this.gameObject.transform;
        this.gameObject.transform.localPosition = new Vector3(now_character_pos_moon.localPosition.x, -3f, 0);
        yield return new WaitForSeconds(0.2f);
        this.gameObject.transform.localPosition = new Vector3(now_character_pos_moon.localPosition.x, -8f, 0);

        if (rope.transform.localPosition.x < 20)
        {
            rope.transform.localPosition += new Vector3(1f, -0.02f, 0f);
            yield return new WaitForSeconds(0.1f);
            rope.transform.GetChild(0).transform.position -= new Vector3(1f, -0.02f, 0f);
        }
        else
        {
            AnimationFinish();
        }
        yield break;
    }
    #endregion

    #region Make Candy House (5)
    public IEnumerator ShootStartCandy()
    {
        Transform now_character_pos_candy = this.gameObject.transform;
        this.gameObject.transform.localPosition = new Vector3(now_character_pos_candy.localPosition.x, -3f, 0);
        yield return new WaitForSeconds(0.2f);
        this.gameObject.transform.localPosition = new Vector3(now_character_pos_candy.localPosition.x, -8f, 0);
        yield return new WaitForSeconds(0.2f);
        this.gameObject.transform.GetChild(0).GetComponent<MoveCandyScript>().enabled = true;
        studySceneCanvasController.CreateCandy(this_character_number);
        yield break;
    }
    #endregion

    #region jump train (6)
    public IEnumerator JumpCharacter_OnTrain()
    {
        this.gameObject.transform.parent.localPosition = new Vector3(0, 5f, 0);
        yield return new WaitForSeconds(0.1f);
        this.gameObject.transform.parent.localPosition = new Vector3(0, 0f, 0);
        yield break;
    }
    #endregion
}
