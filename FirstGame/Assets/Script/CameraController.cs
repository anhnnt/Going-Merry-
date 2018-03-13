using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject target;
	public float followAhead;
		
	private Vector3 targetPosition;

	public float smoothing;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		targetPosition = new Vector3 (target.transform.position.x, transform.position.y, transform.position.z);

		if (target.transform.localScale.x > 0f) {
			targetPosition = new Vector3 (targetPosition.x + followAhead, targetPosition.y, targetPosition.z);
		} else {
			targetPosition = new Vector3 (targetPosition.x - followAhead, targetPosition.y, targetPosition.z);

		}

		//transform.position = targetPosition; 

		transform.position = Vector3.Lerp ( transform.position, targetPosition, smoothing * Time.deltaTime);

		if (target.transform.localPosition.x > 326f && target.transform.localPosition.x < 350f) {
			transform.position = new Vector3 (340.04f, 2.4f, -10f);
		}

		if (target.transform.localPosition.x > 350f) {
			targetPosition = new Vector3 (target.transform.position.x, transform.position.y, transform.position.z);

			if (target.transform.localScale.x > 0f) {
				targetPosition = new Vector3 (targetPosition.x + followAhead, targetPosition.y, targetPosition.z);
			} else {
				targetPosition = new Vector3 (targetPosition.x - followAhead, targetPosition.y, targetPosition.z);

			}
		}
	}
}
