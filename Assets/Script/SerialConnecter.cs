using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;


public class SerialConnecter : MonoBehaviour {

	public delegate void SerialDataReceivedEventHandler(string message);
	public event SerialDataReceivedEventHandler OnDataReceived;

	public string portName = "/dev/cu.usbmodemFA131";
	public int bandRate = 57600;
	private Parity parity = Parity.None;
	private int dataBits = 8;
	private StopBits stopBits = StopBits.None;
	private SerialPort serialPort;

	private Thread thread;
	private bool isRunning = false;

	private string message;
	private bool isNewMessageReceived = false;

	public bool close = false;

	void Awake(){
		DontDestroyOnLoad(this.gameObject);
		Open ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isNewMessageReceived) {
			OnDataReceived (message);
		}

		if (close == true) {
			close = false;
			Close ();
		}
	}


	private void Destroy(){
		Close ();
	}

	private void Open(){
		serialPort = new SerialPort (portName, bandRate, parity, dataBits, stopBits);
		serialPort.Open ();

		isRunning = true;

		thread = new Thread (Read);
		thread.Start ();
	}

	private void Close(){
		isRunning = false;

		if (thread != null && thread.IsAlive) {
			thread.Join ();
		}

		if(serialPort != null && serialPort.IsOpen){
			serialPort.Close ();
			serialPort.Dispose ();
		}
	}

	private void Read(){
		while(isRunning && serialPort != null && serialPort.IsOpen){
			try{
				if(serialPort.BytesToRead>0){
					message = serialPort.ReadLine();
					isNewMessageReceived = true;
				}
			}catch(System.Exception e){
				Debug.LogWarning (e.Message);
			}
		}
	}

	public void Write(string message){
		try{
			serialPort.Write(message);
		}catch(System.Exception e){
			Debug.LogWarning (e.Message);
		}
	}
}
