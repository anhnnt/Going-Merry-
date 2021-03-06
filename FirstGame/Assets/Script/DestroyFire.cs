﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFire : MonoBehaviour {
	public float aliveTime;
	public GameObject ProjectileEmission;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, aliveTime);
	}

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{	
			Destroy (gameObject);
			Instantiate (ProjectileEmission, this.transform.position, this.transform.rotation);
		}
	}

}
