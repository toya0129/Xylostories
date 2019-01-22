using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSoundCanvasScript : MonoBehaviour {

    [SerializeField]
    List<GameObject> xylophone = new List<GameObject>();
    [SerializeField]
    List<GameObject> character = new List<GameObject>();

	// Use this for initialization
	void Start () {
        for (int i = 0; i < xylophone.Count;i++){
            xylophone[i].SetActive(false);
            character[i].SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void SetMainCharacter(int number)
    {
        for (int i = 0; i < character.Count; i++)
        {
            xylophone[i].SetActive(false);
            character[i].SetActive(false);
        }
        xylophone[number - 1].SetActive(true);
        character[number - 1].SetActive(true);
    }
}
