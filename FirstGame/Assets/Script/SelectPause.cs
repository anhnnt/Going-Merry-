using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPause : MonoBehaviour {

	// Restart
	public void Restart()
	{
		SceneManager.LoadScene ("Level1");
		Time.timeScale = 1;
		AudioListener.pause = false;
	}

	// Back to main menu ( new game )
	public void SaveGameSettings(bool Quit)
	{
		if (Quit) {
			Time.timeScale = 1;
			SceneManager.LoadScene ("MainMenu");
			AudioListener.pause = false;
		}
	}
}