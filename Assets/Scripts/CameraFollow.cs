using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	float smoothspeed = .3f;
	private Vector3 currentVelocity;
	//GameObject aObject;
	public Transform aButton;
	// Use this for initialization
/*	void Start () {
		target = GetComponent<Transform> ("Doodler");
	}
*/
	// Update is called once per frame
	void LateUpdate () {
		if (target.position.y > transform.position.y) {
			Vector3 newPos = new Vector3 (transform.position.x, target.position.y, transform.position.z);
			//transform.position = Vector3.Lerp (transform.position, newPos, smoothspeed);
			//transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currentVelocity, smoothspeed * Time.deltaTime);
			transform.position = newPos;
		}
	}
}	
