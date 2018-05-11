using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {

	public CanvasRenderer none;
	public CanvasRenderer red;
	public CanvasRenderer yellow;
	public CanvasRenderer green;
	public CanvasRenderer purple;

	private bool trigger;
	private float interval = 0.7f;
	private float time;
	private int colorInterval = 0;

	//点滅用
//	private float speed = 0.05f;
//	private float boyNoneAlpha;
//	private float boyRedAlpha;
//	private bool boyChange;
//	private float girlNoneAlpha;
//	private float girlPurpleAlpha;
//	private bool girlChange;

	// Use this for initialization
	void Start () {
		trigger = false;

		//点滅用
//		boyNoneAlpha = boyNone.GetComponent<Image> ().color.a;
//		boyRedAlpha = boyRed.GetComponent<Image> ().color.a;
//
//		girlNoneAlpha = boyNone.GetComponent<Image> ().color.a;
//		girlPurpleAlpha = boyRed.GetComponent<Image> ().color.a;
//
//		boyChange = true;
//		girlChange = true;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (time > interval) {
			time = 0.0f;
			if (colorInterval == 16) {
				colorInterval = 1;
			} else {
				colorInterval++;
			}
			trigger = !trigger;
			Debug.Log (colorInterval);
		}


		if (trigger == true) {
			none.GetComponent<Image> ().color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
			if (colorInterval < 5) {
				red.GetComponent<Image> ().color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
			} else if (colorInterval < 9) {
				yellow.GetComponent<Image> ().color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
			} else if (colorInterval < 13) {
				green.GetComponent<Image> ().color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
			} else if (colorInterval < 17) {
				purple.GetComponent<Image> ().color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
			}
		} else if (trigger == false) {
			none.GetComponent<Image> ().color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
			if (colorInterval < 5) {
				red.GetComponent<Image> ().color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
			} else if (colorInterval < 9) {
				yellow.GetComponent<Image> ().color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
			} else if (colorInterval < 13) {
				green.GetComponent<Image> ().color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
			} else if (colorInterval < 17) {
				purple.GetComponent<Image> ().color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
			}
		}



		//点滅用プログラム
//		boyNone.GetComponent<Image>().color = new Color (255.0f, 255.0f, 255.0f, boyNoneAlpha);
//		boyRed.GetComponent<Image> ().color = new Color (255.0f, 255.0f, 255.0f, boyRedAlpha);
//
//		girlNone.GetComponent<Image>().color = new Color (255.0f, 255.0f, 255.0f, girlNoneAlpha);
//		girlPurple.GetComponent<Image> ().color = new Color (255.0f, 255.0f, 255.0f, girlPurpleAlpha);
//
//
//		if (boyChange == true) {
//			boyNoneAlpha -= speed;
//			boyRedAlpha = 1.0f - boyNoneAlpha;
//		} else if(boyChange == false){
//			boyNoneAlpha += speed;
//			boyRedAlpha = 1.0f - boyNoneAlpha;
//		}
//
//		if (girlChange == true) {
//			girlNoneAlpha -= speed;
//			girlPurpleAlpha = 1.0f - girlNoneAlpha;
//		} else if(girlChange == false){
//			girlNoneAlpha += speed;
//			girlPurpleAlpha = 1.0f - girlNoneAlpha;
//		}
//
//
//		if ((boyNoneAlpha <= 0.0f) && (boyRedAlpha >= 1.0f) && (boyChange == true)) {
//			boyChange = false;
//		} else if ((boyNoneAlpha >= 1.0f) && (boyRedAlpha <= 0.0f) && (boyChange == false)) {
//			boyChange = true;
//		}
//
//		if ((girlNoneAlpha <= 0.0f) && (girlPurpleAlpha >= 1.0f) && (girlChange == true)) {
//			girlChange = false;
//		} else if ((girlNoneAlpha >= 1.0f) && (girlPurpleAlpha <= 0.0f) && (girlChange == false)) {
//			girlChange = true;
//		}
//			
	}
}
