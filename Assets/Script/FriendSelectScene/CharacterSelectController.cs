﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterSelectController : MonoBehaviour
{

    [SerializeField]
    private GameObject canvasScript;
    private GameObject gameController;

    private int character_num = 0;
    public List<int> character = new List<int>();

    [SerializeField]
    private List<GameObject> characters = new List<GameObject>();
    [SerializeField]
    private GameObject xylophone_area;
    [SerializeField]
    private GameObject button;

    private bool end_flag = true;
    private float[] end_pos = { -50f, 50f };

    [SerializeField]
    private GameObject comment;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.Find("GameController");
        comment.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
        if (Input.GetKeyDown(KeyCode.Return))
        {
            NextSceneButton();
        }

        if (Input.anyKeyDown)
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    switch (code)
                    {
                        case KeyCode.Alpha1:
                            character_num = 1;
                            break;
                        case KeyCode.Alpha2:
                            character_num = 2;
                            break;
                        case KeyCode.Alpha3:
                            character_num = 3;
                            break;
                        case KeyCode.Alpha4:
                            character_num = 4;
                            break;
                        case KeyCode.Alpha5:
                            character_num = 5;
                            break;
                        case KeyCode.Alpha6:
                            character_num = 6;
                            break;
                        case KeyCode.Alpha7:
                            character_num = 7;
                            break;
                        case KeyCode.Alpha8:
                            character_num = 8;
                            break;
                        default:
                            character_num = 0;
                            break;
                    }
                    if (character_num != 0)
                    {
                        CharacterSelect(character_num);
                    }
                }
            }
        }
#endif
    }

    public void CharacterSelect(int number)
    {
        bool fTrigger = false;
        canvasScript.GetComponent<FriendSelect.CanvasController>().SetCharacter(number);

        for (int i = 0; i < character.Count; i++)
        {
            if (character[i] == number)
            {
                character.RemoveAt(i);
                fTrigger = true;
            }
        }

        if (fTrigger != true)
        {
            character.Add(number);
        }
    }

    public void NextSceneButton()
    {
        if (character.Count != 0)
        {
            for (int j = 0; j < character.Count; j++)
            {
                gameController.GetComponent<GameControllerScript>().Characters[character[j] - 1] = true;
            }
            StartCoroutine(NextAnimation());
        }
        else
        {
            comment.SetActive(true);
        }
    }

    private IEnumerator NextAnimation()
    {
        comment.SetActive(false);
        button.SetActive(false);
        xylophone_area.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        while (end_flag)
        {
            for (int i = 4; i < 8; i++)
            {
                if (characters[i].transform.localPosition.x < end_pos[1])
                {
                    characters[i].transform.localPosition += new Vector3(0.5f, 0f, 0);
                    end_flag = true;
                }
                else
                {
                    end_flag = false;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (characters[i].transform.localPosition.x > end_pos[0])
                {
                    characters[i].transform.localPosition -= new Vector3(0.5f, 0, 0);
                    end_flag = true;
                }
                else
                {
                    end_flag = false;
                }
            }
            yield return new WaitForSeconds(0.05f);
        }
        gameController.GetComponent<GameControllerScript>().OnLoadStudy();
        yield break;
    }
}