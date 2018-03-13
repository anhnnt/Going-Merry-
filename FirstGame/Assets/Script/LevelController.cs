using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Script for MainMenu
public class LevelController : MonoBehaviour {
	// bool Mute;
	public Transform mainMenu, optionsMenu;
	public void PlayGame()
	{
		SceneManager.LoadScene ("Level1");
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void OptionsMenu(bool clicked)
	{
		if (clicked == true) {
			optionsMenu.gameObject.SetActive (clicked);
			mainMenu.gameObject.SetActive (false);
		} else {
			optionsMenu.gameObject.SetActive (clicked);
			mainMenu.gameObject.SetActive (true);
		}
	}

	/* public void MuteSound (){

		Mute = !Mute;
		AudioListener.volume =  Mute ? 0 : 1; 
	} */

}
