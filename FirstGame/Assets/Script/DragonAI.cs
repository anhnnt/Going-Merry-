using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAI : MonoBehaviour {

	public float shootInterval;
	public float bulletSpeed = 10;
	public float bulletTimer;

	public GameObject bullet;
	public Transform target;
	public Transform shootPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Attack (bool attacking) {
		bulletTimer += Time.deltaTime;

		if (bulletTimer >= shootInterval) {
			Vector2 direction = target.transform.position - transform.position;
			direction.Normalize ();
			if (attacking) {
			
				GameObject bulletClone;
				bulletClone = Instantiate (bullet, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;

				bulletTimer = 0;
			}
		}
	}
}
