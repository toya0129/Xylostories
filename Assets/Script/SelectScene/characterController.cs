using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {

	public Animator[] DeerAnime = new Animator[3];
	public Animator nowDeerAnime;

	public Animator[] FoxAnime = new Animator[3];
	public Animator nowFoxAnime;

	public Animator[] RabbitAnime = new Animator[3];
	public Animator nowRabbitAnime;

	public Animator[] RaccoonAnime = new Animator[3];
	public Animator nowRaccoonAnime;

	private int nowCharacter;

	// Use this for initialization
	void Start () {
		nowCharacter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		animationChange (nowCharacter);
	}

	public void animationChange(int now){
		nowFoxAnime = FoxAnime [0];
		nowDeerAnime = DeerAnime [0];
		nowRabbitAnime = RabbitAnime [0];
		nowRaccoonAnime = RaccoonAnime [0];
		switch (now) {
		case 1:
			nowFoxAnime = FoxAnime [1];
			break;
		case 2:
			nowDeerAnime = DeerAnime [1];
			break;
		case 3:
			nowRabbitAnime = RabbitAnime [1];
			break;
		case 4:
			nowRaccoonAnime = RaccoonAnime [1];
			break;
		}
	}

	public void setNowCharacter(int count){
		nowCharacter = count;
	}
			
}
