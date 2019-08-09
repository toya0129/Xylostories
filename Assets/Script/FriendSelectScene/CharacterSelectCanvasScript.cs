using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectCanvasScript : MonoBehaviour {

    [SerializeField]
    List<GameObject> xylophone = new List<GameObject>();
    [SerializeField]
    List<GameObject> character = new List<GameObject>();

    // Use this for initialization
    void Start () {
        for (int i = 0; i < xylophone.Count; i++)
        {
            xylophone[i].SetActive(false);
            character[i].SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetCharacter(int number)
    {
        xylophone[number - 1].SetActive(!xylophone[number - 1].activeSelf);
        character[number - 1].SetActive(!character[number - 1].activeSelf);
    }
}
