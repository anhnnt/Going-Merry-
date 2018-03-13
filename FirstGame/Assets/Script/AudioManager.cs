using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public void ButtonSound1()
	{
		if(PlayerPrefs.GetInt("Muted" , 0) == 0)
		{
			PlayerPrefs.SetInt("Muted" ,1);
			AudioListener.volume = 1;
		}
		else
		{
			PlayerPrefs.SetInt("Muted" , 0);
			AudioListener.volume = 0;
		}
	}
}
