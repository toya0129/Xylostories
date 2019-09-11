using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XyloStoriesSocket;

public class TitleController : MonoBehaviour {

    [SerializeField]
    GameObject start_button;
    [SerializeField]
    GameObject comment;

	// Use this for initialization
	void Start () {
        start_button.SetActive(false);
        comment.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
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
	}
}
