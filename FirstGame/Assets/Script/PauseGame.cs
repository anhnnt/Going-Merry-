using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

	public Transform canvas;
	public Transform Player;
	// public Transform Music;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Pause ();
		}
	}
	public void Pause()
	{
		if (canvas.gameObject.activeInHierarchy == false) {
			canvas.gameObject.SetActive (true);
			Time.timeScale = 0;
			Player.GetComponent<PlayerController> ().enabled = false;
			AudioListener.pause = true;
		} else {
			canvas.gameObject.SetActive (false);
			Time.timeScale = 1;
			Player.GetComponent<PlayerController> ().enabled = true;
			AudioListener.pause = false;
		}
	}

}
