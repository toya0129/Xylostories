using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveControllerScript : MonoBehaviour {

	[SerializeField] SpriteRenderer[] characters;

	[SerializeField] Canvas xylophoneArea;

	bool trigger;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (trigger == false) {
			if (Input.GetKey (KeyCode.A)) {
				StartCoroutine (CharacterJump (0));
				trigger = true;
			}
		}
	}


	private void setCharacterAnimation(int nowCharacter){


	}


	IEnumerator CharacterJump(int nowCharacter){
		while (xylophoneArea.transform.localPosition.y > characters [nowCharacter].transform.localPosition.y) {
			characters [nowCharacter].transform.localPosition += new Vector3 (0.0f, 1.0f, 0.0f);
			characters [nowCharacter].transform.localScale -= new Vector3 (0.1f, 0.1f, 0.1f);
			yield return null;
		}
		yield return StartCoroutine (CharacterReturn (nowCharacter));
		trigger = false;
	}

	IEnumerator CharacterReturn(int nowCharacter){
		while (characters [nowCharacter].transform.localPosition.y > 0.0f) {
			characters [nowCharacter].transform.localPosition -= new Vector3 (0.0f, 1.0f, 0.0f);
			characters [nowCharacter].transform.localScale += new Vector3 (0.1f, 0.1f, 0.1f);
			yield return new WaitForSeconds (0.05f);
		}
		characters [nowCharacter].transform.localPosition = new Vector3 (0f, 0f, 0f);
		characters [nowCharacter].transform.localScale = new Vector3 (1f, 1f, 1f);
	}
}
