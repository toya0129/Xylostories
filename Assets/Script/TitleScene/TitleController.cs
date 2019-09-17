using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
using XyloStoriesSocket;
#endif

public class TitleController : MonoBehaviour {

    [SerializeField]
    GameObject start_button;
    [SerializeField]
    GameObject comment;

	// Use this for initialization
	void Start () {
        if(Application.platform != RuntimePlatform.Android || Application.platform != RuntimePlatform.IPhonePlayer)
        {
            start_button.SetActive(false);
            comment.SetActive(true);
        }
        else
        {
            start_button.SetActive(true);
            comment.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
        if (Socket_Server.Connect_Flag)
        {
            start_button.SetActive(true);
            comment.SetActive(false);
        }
        else
        {
            start_button.SetActive(false);
            comment.SetActive(true);
        }
#endif
    }

}
