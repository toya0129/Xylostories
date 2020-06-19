using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;

public class FilterImport : MonoBehaviour
{
    [DllImport("testlib")]
    private static extern int Add(int a, int b);

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Add(1, 2));
	}
}
    //librosa
    //matpotlib
    //madmon
    