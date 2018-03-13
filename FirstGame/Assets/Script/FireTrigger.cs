using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrigger : MonoBehaviour {

	public DragonAI dragonAI;

	// Use this for initialization
	void Start () {
		dragonAI = gameObject.GetComponentInParent<DragonAI> ();
	}
	
	// Update is called once per frame
	void OnTriggerStay2D (Collider2D other) {
		if (other.tag == "Player") {
			dragonAI.Attack (true);
		}
	}
}
