using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			SceneManager.LoadScene("MainMenu");
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
