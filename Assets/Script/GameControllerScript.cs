using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{

    private int mainCharacter;
    private bool[] friendsCharacter = new bool[8];

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        for (int i = 0; i < 8; i++)
        {
            friendsCharacter[i] = false;
        }

        test();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void test()
    {
        mainCharacter = 1;

        friendsCharacter[mainCharacter] = true;
        friendsCharacter[4] = true;
        friendsCharacter[7] = true;

    }


    #region Scene Load
    public void OnLoadMainSound()
    {
        Debug.Log("Go Main Sound");
        SceneManager.LoadScene("MainSoundSelect");
    }

    public void OnLoadFriendSelect()
    {
        Debug.Log("Go Friends Select");
        SceneManager.LoadScene("FriendSelectScene");
    }

    public void OnLoadAnimation()
    {
        Debug.Log("Go Animation");
        SceneManager.LoadScene("AnimationScene");
    }

    public void OnLoadStudy()
    {
        Debug.Log("Go Study");
        SceneManager.LoadScene("StudyScene");

    }
    #endregion


    #region Getter and Setter
    public int MainCharacter
    {
        get { return mainCharacter; }
        set { mainCharacter = value; }
    }

    public bool[] FriendsCharacter
    {
        get { return friendsCharacter; }
        set { friendsCharacter = value; }
    }
    #endregion

}
