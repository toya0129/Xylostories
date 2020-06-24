using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
using XyloStoriesSocket;
#endif

public class GameControllerScript : MonoBehaviour
{
    //mainStory 0:none 1:find friends 2:run 3:eat food 4: get moon 5:make candy house 6:train
    [SerializeField]
    private int main_story = 0;
    [SerializeField]
    private bool[] characters = new bool[8];

    [SerializeField]
    private List<AudioClip> xylophone_sound = new List<AudioClip>();
    [SerializeField]
    private GameObject audio_play_prefab;

    [SerializeField]
    private GameObject comment;

#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
    public bool server_close = false;
#endif

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Initialized();
#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
        SocketServer.ServerStartLocal();
#endif
    }

    // Use this for initialization
    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    private void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
        if (server_close)
        {
            server_close = false;
            SocketServer.ServerClose();
        }
#endif
    }

    private void Initialized()
    {
        comment.SetActive(false);

        main_story = 0;

        for (int i = 0; i < 8; i++)
        {
            characters[i] = false;
        }
    }

    public IEnumerator SoundPlay(int num)
    {
        GameObject obj = this.gameObject.transform.GetChild(num).gameObject;
        GameObject prefab = Instantiate(audio_play_prefab);
        prefab.transform.parent = obj.transform;
        AudioSource game_audiosource = prefab.GetComponent<AudioSource>();
        game_audiosource.clip = xylophone_sound[num];
        game_audiosource.Play();
        yield return new WaitForSeconds(0.5f);
        while (game_audiosource.isPlaying)
        {
            game_audiosource.volume -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(prefab);
        yield break;
    }

    public void InfoStart(bool s)
    {
        StartCoroutine(SensorConnectInfo(s));
    }

    private IEnumerator SensorConnectInfo(bool state)
    {
        comment.GetComponent<Text>().text = state ? "Sensor Connected" : "Sensor Disconnected";

        comment.SetActive(true);
        yield return new WaitForSeconds(1f);
        comment.SetActive(false);

        yield break;
    }

    #region Scene Load
    public void OnLoadTitle()
    {
        Debug.Log("Go Title");
        SceneManager.LoadScene("TitleScene");
#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
        SocketServer.ServerClose();
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
        SceneManager.LoadScene("MenuScene");
    }

    public void OnLoadFriendSelect()
    {
        MemoryFree();
        Debug.Log("Go Characters Select");
        SceneManager.LoadScene("CharacterSelectScene");
    }

    public void OnLoadStudy()
    {
        Debug.Log("Go Study");
        SceneManager.LoadScene("StudyScene");
    }
    #endregion

    private void MemoryFree()
    {
        System.GC.Collect();
        Resources.UnloadUnusedAssets();
    }


    #region Getter and Setter
    public int MainStory
    {
        get { return main_story; }
        set { main_story = value; }
    }

    public bool[] Characters
    {
        get { return characters; }
        set { characters = value; }
    }
    #endregion
}