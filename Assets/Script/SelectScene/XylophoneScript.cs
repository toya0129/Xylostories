using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XylophoneScript : MonoBehaviour {

	public SpriteRenderer none;
	public SpriteRenderer red;
	public SpriteRenderer yellow;
	public SpriteRenderer green;
	public SpriteRenderer purple;

//	public CanvasRenderer none;
//	public CanvasRenderer red;
//	public CanvasRenderer yellow;
//	public CanvasRenderer green;
//	public CanvasRenderer purple;


	private bool trigger;
	private float interval = 0.7f;
	private float time;
	private int colorInterval = 0;

	private bool flashTrigger;

	private bool redFlashTrigger;
	private bool yellowFlashTrigger;
	private bool greenFlashTrigger;
	private bool purpleFlashTrigger;

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
		flashTrigger = false;

		redFlashTrigger = false;

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
		if (flashTrigger == false) {
			time += Time.deltaTime;

			if (time > interval) {
				time = 0.0f;
				if (colorInterval == 16) {
					colorInterval = 1;
				} else {
					colorInterval++;
				}
				trigger = !trigger;
			}

			//SpriteRenderer
			if (trigger == true) {
				none.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
				if (colorInterval < 5) {
					red.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
				} else if (colorInterval < 9) {
					yellow.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
				} else if (colorInterval < 13) {
					green.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
				} else if (colorInterval < 17) {
					purple.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
				}
			} else if (trigger == false) {
				none.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
				if (colorInterval < 5) {
					red.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
				} else if (colorInterval < 9) {
					yellow.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
				} else if (colorInterval < 13) {
					green.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
				} else if (colorInterval < 17) {
					purple.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
				}
			}

			//Canvas
//			if (trigger == true) {
//				none.Getcomponent<Image>().color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
//				if (colorInterval < 5) {
//					red.Getcomponent<Image>().color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
//				} else if (colorInterval < 9) {
//					yellow.Getcomponent<Image>().color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
//				} else if (colorInterval < 13) {
//					green.Getcomponent<Image>().color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
//				} else if (colorInterval < 17) {
//					purple.Getcomponent<Image>().color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
//				}
//			} else if (trigger == false) {
//				none.Getcomponent<Image>().color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
//				if (colorInterval < 5) {
//					red.Getcomponent<Image>().color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
//				} else if (colorInterval < 9) {
//					yellow.Getcomponent<Image>().color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
//				} else if (colorInterval < 13) {
//					green.Getcomponent<Image>().color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
//				} else if (colorInterval < 17) {
//					purple.Getcomponent<Image>().color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
//				}
//			}


		}

		if (redFlashTrigger == true) {
			time += Time.deltaTime;

			if (time > interval) {
				time = 0.0f;
				trigger = !trigger;
			}
			if (trigger == true) {
				none.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
				red.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
			} else if (trigger == false) {
				none.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
				red.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
			}
		} else if (yellowFlashTrigger == true) {
			time += Time.deltaTime;

			if (time > interval) {
				time = 0.0f;
				trigger = !trigger;
			}
			if (trigger == true) {
				none.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
				yellow.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
			} else if (trigger == false) {
				none.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
				yellow.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
			}
		}else if (greenFlashTrigger == true) {
			time += Time.deltaTime;

			if (time > interval) {
				time = 0.0f;
				trigger = !trigger;
			}
			if (trigger == true) {
				none.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
				green.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
			} else if (trigger == false) {
				none.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
				green.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
			}
		}else if (purpleFlashTrigger == true) {
			time += Time.deltaTime;

			if (time > interval) {
				time = 0.0f;
				trigger = !trigger;
			}
			if (trigger == true) {
				none.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
				purple.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
			} else if (trigger == false) {
				none.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
				purple.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
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

	public void changeFlashTrigger(){
		flashTrigger = !flashTrigger;
		none.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
		red.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
		yellow.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
		green.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
		purple.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
		time = 0.0f;
	}

	public void changeRedFlashTrigger(){
		redFlashTrigger = !redFlashTrigger;
	}

	public void changeYellowFlashTrigger(){
		yellowFlashTrigger = !yellowFlashTrigger;
	}
		
	public void changeGreenFlashTrigger(){
		greenFlashTrigger = !greenFlashTrigger;
	}

	public void changePurpleFlashTrigger(){
		purpleFlashTrigger = !purpleFlashTrigger;
	}
}
