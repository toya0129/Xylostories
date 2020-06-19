using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    private GameControllerScript game_controller_script;

    [SerializeField]
    private GameObject[] waku;

    private int now_story = 0;

	// Use this for initialization
	private void Start () {
        game_controller_script = GameObject.Find("GameController").GetComponent<GameControllerScript>();
	}
	
	// Update is called once per frame
	private void Update () {
#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (now_story != 0)
                {
                    game_controller_script.MainStory = now_story;
                    game_controller_script.OnLoadFriendSelect();
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                now_story++;
                if (now_story == 7) now_story = 1;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                now_story--;
                if (now_story == 0) now_story = 6;
            }
            setWaku_UI();
        }
#endif
    }

    public void SelectStory(int num)
    {
        if (now_story == num)
        {
            if (now_story != 0)
            {
                game_controller_script.MainStory = now_story;
                game_controller_script.OnLoadFriendSelect();
                return;
            }
        }
        now_story = num;
        setWaku_UI();
    }

    private void setWaku_UI()
    {
        for (int i = 1; i <= waku.Length; i++)
        {
            waku[i - 1].GetComponent<Image>().color = new Color(0, 0, 0);
        }
        waku[now_story - 1].GetComponent<Image>().color = new Color(255, 0, 0);
    }
}
