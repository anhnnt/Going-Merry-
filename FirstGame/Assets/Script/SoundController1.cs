using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController1 : MonoBehaviour {

	private AudioManager audioManager;
	public Button musicSoundButtonInGame;
	public Sprite musicOn;
	public Sprite musicOff;

	// Use this for initialization
	void Start() {		
		audioManager = GameObject.FindObjectOfType<AudioManager> ();
		Change();
	}

	public void PauseMusic()
	{
		audioManager.ButtonSound1 ();
		UpdateIconAndVolume ();
	}

	void Change()
	{
		if (PlayerPrefs.GetInt ("Muted", 0) == 0) {
			musicSoundButtonInGame.GetComponent<Image> ().sprite = musicOff;
		} 
		else 
		{
			musicSoundButtonInGame.GetComponent<Image> ().sprite = musicOn;
		}
	} 

	void UpdateIconAndVolume()
	{
		if (PlayerPrefs.GetInt ("Muted", 0) == 0) {
			AudioListener.volume = 1;
			musicSoundButtonInGame.GetComponent<Image> ().sprite = musicOn;
		} 
		else 
		{
			AudioListener.volume = 0;
			musicSoundButtonInGame.GetComponent<Image> ().sprite = musicOff;
		}
	}
}
