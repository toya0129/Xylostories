using System.Collections;
using UnityEngine;

public class AnimationScript : MonoBehaviour {

    private GameControllerScript game_controller_script;

    [SerializeField]
    private GameObject character;
    [SerializeField]
    private Sprite rabbit_back;

    private bool trun_flag_y = true;
    private float rote_y = 0.0f;
    private float rote_z = 0.0f;
    private int move_count = 0;

    private int rabbit_move_end = 270; // 50:-15移動

    // Use this for initialization
    private void Start () {
        game_controller_script = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        StartCoroutine(RabbitAnimation());
	}
	
    private IEnumerator CharacterMove() // Move a Characters Left and Right
    {
        while (move_count < rabbit_move_end)
        {
            if (trun_flag_y)
            {
                if (character.transform.localPosition.x > -20)
                {
                    character.transform.localPosition -= new Vector3(0.3f, 0, 0);
                }
                else
                {
                    yield return StartCoroutine(TrunCharactar());
                    trun_flag_y = false;
                }
            }
            else if (!trun_flag_y)
            {
                if (character.transform.localPosition.x < 20)
                {
                    character.transform.localPosition += new Vector3(0.3f, 0, 0);
                }
                else
                {
                    yield return StartCoroutine(TrunCharactar());
                    trun_flag_y = true;
                }
            }
            yield return new WaitForSeconds(0.005f);

            move_count++;

        }
        yield break;
    }

    private IEnumerator TrunCharactar() // Trun a Characters (y)
    {
        while (true)
        {
            if (trun_flag_y)
            {
                if (rote_y < 180)
                {
                    character.transform.localRotation = Quaternion.Euler(0, rote_y, rote_z);
                    rote_y += 5.0f;
                }
                else
                {
                    break;
                }
            }
            else if (!trun_flag_y)
            {
                if (rote_y > 0)
                {
                    character.transform.localRotation = Quaternion.Euler(0, rote_y, rote_z);
                    rote_y -= 5.0f;
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
    private IEnumerator RabbitAnimation()
    {
        yield return StartCoroutine(CharacterMove());
        yield return new WaitForSeconds(1.0f); // delay
        yield return StartCoroutine(TrunCharactar());
        character.GetComponent<Animator>().enabled = false;
        character.GetComponent<SpriteRenderer>().sprite = rabbit_back;
        yield return StartCoroutine(GoBackHome());
        StopAllCoroutines();
        Debug.Log("Rabbit Animation End");
        LoadToMenuScene();
        yield break;
    }

    private IEnumerator GoBackHome()
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

    public void LoadToMenuScene()
    {
        StopAllCoroutines();
        game_controller_script.OnLoadMenuScene();
    }
}