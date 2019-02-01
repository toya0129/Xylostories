using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {

    private GameControllerScript gameControllerScript;

    [SerializeField]
    GameObject character;
    [SerializeField]
    Sprite rabbit_back;

    private bool trunFlagY = true;
    private float roteY = 0.0f;
    private float roteZ = 0.0f;
    private int moveCount = 0;

    private int rabbitMoveEnd = 540; // 50:-15移動

    // Use this for initialization
    void Start () {
        StartCoroutine(RabbitAnimation());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator CharacterMove(int endCount) // Move a Characters Left and Right
    {
        if (trunFlagY == true)
        {
            if (character.transform.localPosition.x > -20)
            {
                character.transform.localPosition -= new Vector3(0.3f, 0, 0);
            }
            else
            {
                yield return StartCoroutine(TrunCharactar());
                trunFlagY = false;
            }
        }
        else if (trunFlagY == false)
        {
            if (character.transform.localPosition.x < 20)
            {
                character.transform.localPosition += new Vector3(0.3f, 0, 0);
            }
            else
            {
                yield return StartCoroutine(TrunCharactar());
                trunFlagY = true;
            }
        }
        yield return new WaitForSeconds(0.005f);

        moveCount++;

        if (endCount < moveCount)
        {
            yield break;
        }

        yield return StartCoroutine(CharacterMove(endCount));
        yield break;
    }

    IEnumerator TrunCharactar() // Trun a Characters (y)
    {
        if (trunFlagY == true)
        {
            if (roteY < 180)
            {
                character.transform.localRotation = Quaternion.Euler(0, roteY, roteZ);
                roteY += 5.0f;
            }
            else
            {
                yield break;
            }
        }
        else if (trunFlagY == false)
        {
            if (roteY > 0)
            {
                character.transform.localRotation = Quaternion.Euler(0, roteY, roteZ);
                roteY -= 5.0f;
            }
            else
            {
                yield break;
            }
        }
        yield return new WaitForSeconds(0.005f);
        yield return StartCoroutine(TrunCharactar());
        yield break;
    }

    #region RabbitAnimation (Go Back Home)
    IEnumerator RabbitAnimation()
    {
        yield return StartCoroutine(CharacterMove(rabbitMoveEnd));
        yield return new WaitForSeconds(1.0f); // delay
        yield return StartCoroutine(TrunCharactar());
        character.GetComponent<Animator>().enabled = false;
        character.GetComponent<SpriteRenderer>().sprite = rabbit_back;
        yield return StartCoroutine(GoBackHome());
        StopAllCoroutines();
        Debug.Log("Rabbit Animation End");
        gameControllerScript.OnLoadMenuScene();
        yield break;
    }

    IEnumerator GoBackHome()
    {
        if (character.transform.localPosition.z < 50)
        {
            character.transform.localPosition += new Vector3(0.0f, -0.1f, 2.0f);
        }
        else
        {
            character.SetActive(false);
            yield break;
        }
        yield return new WaitForSeconds(0.1f);
        yield return StartCoroutine(GoBackHome());
        yield break;
    }
    #endregion
}
