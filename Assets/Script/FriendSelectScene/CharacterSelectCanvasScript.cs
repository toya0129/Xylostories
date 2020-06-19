using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectCanvasScript : MonoBehaviour {

    [SerializeField]
    private List<GameObject> xylophone = new List<GameObject>();
    [SerializeField]
    private List<GameObject> character = new List<GameObject>();
    [SerializeField]
    private GameObject click_area;


    // Use this for initialization
    private void Start () {
        Initialized();
    }

    private void Initialized()
    {
        click_area.SetActive(true);
        for (int i = 0; i < xylophone.Count; i++)
        {
            xylophone[i].SetActive(true);
            xylophone[i].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 100);
            character[i].SetActive(true);
            character[i].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 100);
        }
    }

    public void SetCharacter(int number)
    {
        byte alpha = 0;

        if (xylophone[number - 1].GetComponent<SpriteRenderer>().color.a == 1)
        {
            alpha = 100;
        }
        else
        {
            alpha = 255;
        }
        xylophone[number - 1].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, alpha);
        character[number - 1].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, alpha);
    }
}