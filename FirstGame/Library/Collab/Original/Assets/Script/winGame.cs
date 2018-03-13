using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winGame : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Destroy(GameObject);
            SceneManager.LoadScene("MainMenu");
            // Time.timeScale = 5.0f;
        }
    }

    /*  // Update is called once per frame
      public void win(bool Quit)
      {
          if (Quit)
          {
              Time.timeScale = 1;
              SceneManager.LoadScene("MainMenu");
          }
      } */
    }

