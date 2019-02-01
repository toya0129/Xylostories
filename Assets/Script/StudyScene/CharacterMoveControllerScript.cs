using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.IO.Ports;

public class CharacterMoveControllerScript : MonoBehaviour {

    #region Serial
    public SerialConnecter serialConnecter;
    string outData = "";
    #endregion

    [SerializeField] GameObject[] characters;
    [SerializeField] GameObject xylophoneArea;



    private bool[] trigger = new bool[8];
    private KeyCode[] key = new KeyCode[] { KeyCode.PageUp, KeyCode.PageDown, KeyCode.B, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8 };

	// Use this for initialization
	void Start () {
        for (int i = 0; i < trigger.Length;i++){
            trigger[i] = false;
        }
        serialConnecter.OnDataReceived += OnDataReceived;
    }

    // Update is called once per frame
    void Update()
    {
        //  keybord
        if (Input.anyKeyDown)
        {
            for (int i = 0; i < trigger.Length; i++)
            {
                if (trigger[i] == false)
                {
                    if (Input.GetKeyDown(key[i]))
                    {
                        StartCoroutine(CharacterJump(i));
                        trigger[i] = true;
                    }
                }
            }
        }

        // Xylophone
        switch (outData)
        {
            case "C":
                if(trigger[0] == false)
                {
                    StartCoroutine(CharacterJump(0));
                    trigger[0] = true;
                }
                break;
            case "D":
                if (trigger[1] == false)
                {
                    StartCoroutine(CharacterJump(1));
                    trigger[1] = true;
                }
                break;
            case "E":
                if (trigger[2] == false)
                {
                    StartCoroutine(CharacterJump(2));
                    trigger[2] = true;
                }
                break;
            case "F":
                if (trigger[3] == false)
                {
                    StartCoroutine(CharacterJump(3));
                    trigger[3] = true;
                }
                break;
            case "G":
                if (trigger[4] == false)
                {
                    StartCoroutine(CharacterJump(4));
                    trigger[4] = true;
                }
                break;
            case "A":
                if (trigger[5] == false)
                {
                    StartCoroutine(CharacterJump(5));
                    trigger[5] = true;
                }
                break;
            case "B":
                if (trigger[6] == false)
                {
                    StartCoroutine(CharacterJump(6));
                    trigger[6] = true;
                }
                break;
            case "C2":
                if (trigger[7] == false)
                {
                    StartCoroutine(CharacterJump(7));
                    trigger[7] = true;
                }
                break;
            default:
                break;
        }

    }

	IEnumerator CharacterJump(int nowCharacter){
        while (xylophoneArea.transform.position.y > characters [nowCharacter].transform.position.y) {
            characters [nowCharacter].transform.position += new Vector3 (0.0f, 1.0f, 0.0f);
			characters [nowCharacter].transform.localScale -= new Vector3 (0.05f, 0.05f, 0);
			yield return null;
		}
		yield return StartCoroutine (CharacterReturn (nowCharacter));
        trigger[nowCharacter] = false;
        yield break;
	}

	IEnumerator CharacterReturn(int nowCharacter){
        while (characters [nowCharacter].transform.position.y > 0.0f) {
            characters [nowCharacter].transform.position -= new Vector3 (0.0f, 2.0f, 0.0f);
			characters [nowCharacter].transform.localScale += new Vector3 (0.05f, 0.05f, 0.1f);
			yield return new WaitForSeconds (0.05f);
		}
        characters [nowCharacter].transform.localPosition = new Vector3 (0f, 0f, 0f);
		characters [nowCharacter].transform.localScale = new Vector3 (2f, 2f, 2f);
        yield break;
	}

    void OnDataReceived(string message)
    {
        message = message.Replace("\r", "").Replace("\n", "");
        try
        {
            outData = message;
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }
}
