using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour {

	private Music music;
	public Button musicSoundButton;

	// Use this for initialization
	void Start () {
		music = GameObject.FindObjectOfType<Music> ();
	}

	public void PauseMusicInMenu()
	{
		music.ButtonSound ();
	}
}
