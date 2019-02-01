using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{

    private int mainStory = 0;
    [SerializeField] bool[] characters = new bool[8];
    
    private int mainCharacter = 0;
    [SerializeField] bool[] friendsCharacter = new bool[8];

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        for (int i = 0; i < 8; i++)
        {
            characters[i] = false;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Scene Load
    public void OnLoadTitle()
    {
        Debug.Log("Go Title");
        SceneManager.LoadScene("TitleScene");
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
        SceneManager.LoadScene("MenuScene");
    }

    public void OnLoadFriendSelect()
    {
        Debug.Log("Go Friends Select");
        SceneManager.LoadScene("FriendSelectScene");
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
