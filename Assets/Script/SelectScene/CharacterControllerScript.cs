using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour {

	public RuntimeAnimatorController[] DeerAnime = new RuntimeAnimatorController[3];
	public Animator nowDeerAnime;

	public RuntimeAnimatorController[] FoxAnime = new RuntimeAnimatorController[3];
	public Animator nowFoxAnime;

	public RuntimeAnimatorController[] RabbitAnime = new RuntimeAnimatorController[3];
	public Animator nowRabbitAnime;

	public RuntimeAnimatorController[] RaccoonAnime = new RuntimeAnimatorController[3];
	public Animator nowRaccoonAnime;

	private bool animationChangeTrigger;
	private int nowCharacter;
	private int moveType; // 0 = idle, 1 = wave, 2 = walk 

	// Use this for initialization
	void Start () {
		animationChangeTrigger = false;
		nowCharacter = 0;
		moveType = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (animationChangeTrigger == true) {
			animationChangeTrigger = false;
			animationChange (nowCharacter, moveType);
		}
	}

	public void animationChange(int character,int move){
		nowFoxAnime.runtimeAnimatorController = FoxAnime [0];
		nowDeerAnime.runtimeAnimatorController = DeerAnime[0];
		nowRabbitAnime.runtimeAnimatorController = RabbitAnime [0];
		nowRaccoonAnime.runtimeAnimatorController = RaccoonAnime [0];
		switch (character) {
		case 1:
			nowFoxAnime.runtimeAnimatorController = FoxAnime [move];
			break;
		case 2:
			nowRaccoonAnime.runtimeAnimatorController = RaccoonAnime [move];
			break;
		case 3:
			nowRabbitAnime.runtimeAnimatorController = RabbitAnime [move];
			break;
		case 4:
			nowDeerAnime.runtimeAnimatorController = DeerAnime [move];
			break;
		default:
			break;
		}
	}

	public void setNowCharacter(int count){
		nowCharacter = count;
	}
	public void setMoveType(int type){
		moveType = type;
	}
	public void setAnimationChangeTrigger(bool trigger){
		animationChangeTrigger = trigger;
	}
			
}
