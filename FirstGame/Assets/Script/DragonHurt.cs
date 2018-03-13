using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHurt : MonoBehaviour {

	public int ObjectHealth;
	public int dmg;
	public GameObject EnemyEplosion;

	// Use this for initialization
	void Start () {

	}

	void Update()
	{
		if (ObjectHealth <= 0)
		{
			Destroy (gameObject);
			Instantiate (EnemyEplosion, this.transform.position, this.transform.rotation);
		}	
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Damage") 
		{
			ObjectHealth -= dmg;
			gameObject.GetComponent<Animation> ().Play ("DragonHurt");
		}

		if (other.tag == "Projectile")
		{	
			ObjectHealth -= dmg/3;
			gameObject.GetComponent<Animation> ().Play ("DragonHurt");
		}
	}

}
