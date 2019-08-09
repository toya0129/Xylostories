using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    [SerializeField]
    SerialReadScript serialReadScript;

    //mainStory 0:none 1:find friends 2:run 3:eat food 4: get moon 5:make candy house 6:train
    [SerializeField] int mainStory = 0; 
    [SerializeField] bool[] characters = new bool[8];
    

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        for (int i = 0; i < 8; i++)
        {
            //characters[i] = false;
        }
    }

    // Use this for initialization
    void Start()
    {
		mainStory = 0;
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
//        serialReadScript.gameObject.GetComponent<SerialConnecter>().close = true;
//        Destroy(serialReadScript.gameObject);
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
        Debug.Log("Go Characters Select");
        SceneManager.LoadScene("CharacterSelectScene");
    }

    public void OnLoadStudy()
    {
        Debug.Log("Go Study");
        SceneManager.LoadScene("StudyScene");
		serialReadScript = GameObject.Find("SerialConnecter").GetComponent<SerialReadScript>();

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
