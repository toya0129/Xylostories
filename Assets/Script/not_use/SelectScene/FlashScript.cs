using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashScript : MonoBehaviour {

	public SpriteRenderer none;
	public SpriteRenderer red;
	public SpriteRenderer orange;
	public SpriteRenderer yellow;
	public SpriteRenderer green;
	public SpriteRenderer purple;

	private bool trigger;
	private float interval = 0.7f;
	private float time;
	private int colorInterval = 0;

	private bool flashTrigger;

	private bool redFlashTrigger;
	private bool yellowFlashTrigger;
	private bool greenFlashTrigger;
	private bool purpleFlashTrigger;

	private bool walkTrigger;

	// Use this for initialization
	void Start () {
		trigger = false;
		flashTrigger = false;

		redFlashTrigger = false;
		yellowFlashTrigger = false;
		greenFlashTrigger = false;
		purpleFlashTrigger = false;

		walkTrigger = false;

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
				
		}

		if (walkTrigger == true) {
			time += Time.deltaTime;

			if (time > interval) {
				time = 0.0f;
				trigger = !trigger;
			}
			if (trigger == true) {
				none.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
				red.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
				orange.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
			} else if (trigger == false) {
				none.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
				red.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
				orange.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
			}
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
	
	}

	public void changeFlashTrigger(){
		flashTrigger = !flashTrigger;
		allFalseFlashTrigger ();
		colorInterval = 0;
		trigger = false;
		none.color = new Color (255.0f, 255.0f, 255.0f, 1.0f);
		red.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
		yellow.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
		green.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
		purple.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
		time = 0.0f;
	}

	public void allFalseFlashTrigger(){
		redFlashTrigger = false;
		yellowFlashTrigger = false;
		greenFlashTrigger = false;
		purpleFlashTrigger = false;
		walkTrigger = false;
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

	public void changeWalkFlashTrigger(){
		walkTrigger = !walkTrigger;
	}
}
