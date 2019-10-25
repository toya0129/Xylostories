using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartScene
{
    public class AnimationScript : MonoBehaviour
    {
        [SerializeField]
        private StartScene.CanvasController canvasController;

        private GameObject character;
        [SerializeField]
        private Sprite rabbit_back;

        private float roteY = 0.0f;
        private float roteZ = 0.0f;
        private int move_count = 0;


        private bool move_trigger = true;
        private bool turn_trigger = false;

        private int rabbit_move_end = 5;

        // Use this for initialization
        private void Start()
        {
            Initialized();
            StartCoroutine(RabbitAnimation());
        }

        private void Initialized()
        {
            character = this.gameObject;
        }


        public void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.tag == "turn_trigger")
            {
                if (!turn_trigger)
                {
                    move_trigger = !move_trigger;
                    turn_trigger = true;
                }
            }
        }

        private IEnumerator CharacterMove()
        {
            while (move_count != rabbit_move_end)
            {
                if (move_trigger)
                {
                    character.transform.localPosition += new Vector3(5f, 0, 0);
                }
                else
                {
                    character.transform.localPosition -= new Vector3(5f, 0, 0);
                }

                if (turn_trigger)
                {
                    yield return StartCoroutine(TurnCharacter());
                    move_count++;
                    turn_trigger = false;
                }

                yield return new WaitForSeconds(0.00000000001f);
            }
            yield break;
        }

        private IEnumerator TurnCharacter()
        {
            while (true)
            {
                if (!move_trigger)
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
                else
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
        private IEnumerator RabbitAnimation()
        {
            yield return StartCoroutine(CharacterMove());
            yield return StartCoroutine(GoBackHome());
            Debug.Log("Rabbit Animation End");
            canvasController.LoadToMenuScene();
            character.SetActive(false);
            yield break;
        }

        private IEnumerator GoBackHome()
        {
            while (character.transform.localPosition.x > 0)
            {
                character.transform.localPosition -= new Vector3(5f, 0, 0);
                yield return new WaitForSeconds(0.00000000001f);
            }

            yield return new WaitForSeconds(1.0f); // delay

            move_trigger = true;
            yield return StartCoroutine(TurnCharacter());

            character.GetComponent<Animator>().enabled = false;
            character.GetComponent<SpriteRenderer>().sprite = rabbit_back;

            while (character.transform.localPosition.z < 1000)
            {
                character.transform.localPosition += new Vector3(0.0f, -1f, 5f);
                yield return new WaitForSeconds(0.00000000001f);
            }

            yield break;
        }
        #endregion
    }
}