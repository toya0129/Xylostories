using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.IO.Ports;

public class serialRead : MonoBehaviour {


	public SerialConnecter serialConnecter;
	private string[] sensState = new string[5];

	public MeshRenderer a;
	public Material[] b;

	void Start()
	{
		serialConnecter.OnDataReceived += OnDataReceived;
	}

	void Update()
	{
		Debug.Log ("C = " + sensState [0]);
		Debug.Log ("D = " + sensState [1]);
		Debug.Log ("E = " + sensState [2]);
		Debug.Log ("F = " + sensState [3]);

		if (sensState [0] == "1") {
			a.material.color = b [0].color;
		}
		if (sensState [1] == "1") {
			a.material.color = b [1].color;
		}
		if (sensState [2] == "1") {
			a.material.color = b [2].color;
		}
		if (sensState [3] == "1") {
			a.material.color = b [3].color;
		}
	}

	void OnDataReceived(string message)
	{
		var data = message.Split (new string[]{ "\t" }, System.StringSplitOptions.None);

		if (data.Length < 5) {
			return;
		}

		try{
			sensState[0] = data[0];
			sensState[1] = data[1];
			sensState[2] = data[2];
			sensState[3] = data[3];
			sensState[4] = data[4];
		}catch(System.Exception e){
			Debug.LogWarning (e.Message);
		}
	}

}
