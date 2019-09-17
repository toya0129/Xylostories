using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {

    private GameControllerScript gameControllerScript;

    [SerializeField]
    private GameObject character;
    [SerializeField]
    private Sprite rabbit_back;

    private bool trunFlagY = true;
    private float roteY = 0.0f;
    private float roteZ = 0.0f;
    private int moveCount = 0;

    private int rabbitMoveEnd = 540; // 50:-15移動

    // Use this for initialization
    void Start () {
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        StartCoroutine(RabbitAnimation());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator CharacterMove() // Move a Characters Left and Right
    {
        while (moveCount < rabbitMoveEnd)
        {
            if (trunFlagY)
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
            else if (!trunFlagY)
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

        }
        yield break;
    }

    IEnumerator TrunCharactar() // Trun a Characters (y)
    {
        while (true)
        {
            if (trunFlagY)
            {
                if (roteY < 180)
                {
                    character.transform.localRotation = Quaternion.Euler(0, roteY, roteZ);
                    roteY += 5.0f;
                }
                else
                {
                    break;
                }
            }
            else if (!trunFlagY)
            {
                if (roteY > 0)
                {
                    character.transform.localRotation = Quaternion.Euler(0, roteY, roteZ);
                    roteY -= 5.0f;
                }
                else
                {
                    break;
                }
            }
            yield return new WaitForSeconds(0.005f);
        }
        yield break;
    }

    #region RabbitAnimation (Go Back Home)
    IEnumerator RabbitAnimation()
    {
        yield return StartCoroutine(CharacterMove());
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
        while (character.transform.localPosition.z < 50)
        {
            character.transform.localPosition += new Vector3(0.0f, -0.1f, 2.0f);
            yield return new WaitForSeconds(0.1f);
        }

        character.SetActive(false);
        yield break;
    }
    #endregion
}
