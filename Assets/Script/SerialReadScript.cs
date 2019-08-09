using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SerialReadScript : MonoBehaviour {

    public SerialConnecter serialConnecter;
    private string outData;
    public int now = 0;

    //public int[] serialDataIndex = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 ,0};
    private string[] search = { "NN","CC", "DD", "EE", "FF", "GG", "AA", "BB", "C2" };

    private void Awake()
    {
 //       DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {
        serialConnecter.OnDataReceived += OnDataReceived;
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void OnDataReceived(string message)
    {
        string data = message.Replace("\r", "").Replace("\n", "");
        
        if (data.Length < 2)
        {
            return;
        }

        try
        {
            int dataCount = -1;
            for (int i = 0; i < search.Length; i++)
            {
                //serialDataIndex[i] = data.IndexOf(search[i], System.StringComparison.CurrentCulture);
                 if (dataCount < data.IndexOf(search[i], System.StringComparison.CurrentCulture))
                {
                    now = i;
                }
            }

            switch (now)
            {
                case 1:
                    outData = "CC";
                    break;
                case 2:
                    outData = "DD";
                    break;
                case 3:
                    outData = "EE";
                    break;
                case 4:
                    outData = "FF";
                    break;
                case 5:
                    outData = "GG";
                    break;
                case 6:
                    outData = "AA";
                    break;
                case 7:
                    outData = "BB";
                    break;
                case 8:
                    outData = "C2";
                    break;
                default:
                    outData = "";
                    break;
            }

            //jDebug.Log(outData);
            now = 0;

        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }

    public string OutData
    {
        get { return outData; }
        set { outData = value; }
    }
}
