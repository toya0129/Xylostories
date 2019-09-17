using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
using XyloStoriesSocket;
#endif

public class GameControllerScript : MonoBehaviour
{
    [SerializeField]
    private SerialReadScript serialReadScript;

    //mainStory 0:none 1:find friends 2:run 3:eat food 4: get moon 5:make candy house 6:train
    [SerializeField]
    private int mainStory = 0;
    [SerializeField]
    private bool[] characters = new bool[8];

#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
    public bool server_Close = false;
#endif

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Initialized();
        Socket_Server.ServerStart_local();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
        if (server_Close)
        {
            server_Close = false;
            Socket_Server.ServerClose();
        }
#endif
    }

    private void Initialized()
    {
        mainStory = 0;

        for (int i = 0; i < 8; i++)
        {
            characters[i] = false;
        }
    }

    #region Scene Load
    public void OnLoadTitle()
    {
        Debug.Log("Go Title");
        SceneManager.LoadScene("TitleScene");
#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
        Socket_Server.ServerClose();
#endif
        Destroy(this.gameObject);
    }

    public void OnLoadStartScene()
    {
        Debug.Log("Go Start Scene");
        SceneManager.LoadScene("StartScene");
    }

    public void OnLoadMenuScene()
    {
        Debug.Log("Go Menu Scene");
        Initialized();
        SceneManager.LoadScene("MenuScene");
    }

    public void OnLoadFriendSelect()
    {
        Debug.Log("Go Characters Select");
        SceneManager.LoadScene("CharacterSelectScene");
    }

    public void OnLoadStudy()
    {
        Debug.Log("Go Study");
        SceneManager.LoadScene("StudyScene");
    }
    #endregion


    #region Getter and Setter
    public int MainStory
    {
        get { return mainStory; }
        set { mainStory = value; }
    }

    public bool[] Characters
    {
        get { return characters; }
        set { characters = value; }
    }
    #endregion
}