using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    private GameControllerScript gameControllerScript;

    [SerializeField]
    GameObject[] waku;

    private int now_story = 1;

	// Use this for initialization
	void Start () {
        //gameControllerScript = GameObject.Find("GameController").GetComponent<GameControllerScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameControllerScript.MainStory = now_story;
                gameControllerScript.OnLoadFriendSelect();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                now_story++;
                if (now_story == 7)
                {
                    now_story = 1;
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                now_story--;
                if(now_story == 0)
                {
                    now_story = 6;
                }
            }
            setWaku_UI();
        }
	}

    private void setWaku_UI()
    {
        for (int i = 1; i <= waku.Length; i++)
        {
            waku[i - 1].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
        }
        waku[now_story - 1].GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
    }
}
