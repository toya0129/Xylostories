using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendSelectCanvasScript : MonoBehaviour {

    [SerializeField]
    List<GameObject> xylophone = new List<GameObject>();
    [SerializeField]
    List<GameObject> character = new List<GameObject>();

    private int main;


    // Use this for initialization
    void Start () {
        main = GameObject.Find("GameController").GetComponent<GameControllerScript>().MainCharacter;
        for (int i = 0; i < xylophone.Count; i++)
        {
            xylophone[i].SetActive(false);
            character[i].SetActive(false);
        }
        xylophone[main - 1].SetActive(true);
        character[main - 1].SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetFriendCharacter(int number){
        if (number != main)
        {
            xylophone[number - 1].SetActive(!xylophone[number - 1].activeSelf);
            character[number - 1].SetActive(!character[number - 1].activeSelf);
        }

    }
}
