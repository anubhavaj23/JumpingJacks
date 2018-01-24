using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
	float movementspeed = 10f;
	Rigidbody2D rb;
	float movement = 0f;
	public GameObject LevelChecker;
	int level;
	// Use this for initialization
	void Start () {	
		rb = GetComponent<Rigidbody2D> ();
		rb.constraints = (RigidbodyConstraints2D)RigidbodyConstraints.FreezeAll; //doubt
		Time.timeScale = 2.0f;
		Debug.Log ("constraints worked");
		Camera.main.orthographicSize = 15;

	}
	
	// Update is called once per frame
	void Update () {
		if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor) {
			movement = Input.GetAxis ("Horizontal") * movementspeed;   	
		} else if (Application.platform == RuntimePlatform.Android) {
			for (int i = 0; i < Input.touchCount; ++i)
			{
				if (Input.GetTouch (i).phase == TouchPhase.Began) {
					if(Input.GetTouch(i).position.x > Screen.width/2){
						movement = 10f;
					} 
					else if(Input.GetTouch(i).position.x <= Screen.width/2){
						movement = -10f;	
					}	
				}
				if (Input.GetTouch (i).phase == TouchPhase.Ended)
					movement = 0f;
			}

		}
	}

	void FixedUpdate(){
		Vector2 velocity = rb.velocity;
		velocity.x = movement;
		rb.velocity = velocity;
	}

	void OnCollisionEnter2D(Collision2D collision){


		int templevel = LevelChecker.GetComponent<LevelGenerator>().CheckLevel(collision.otherCollider.gameObject.transform.position.y)*-1;
		if (level < templevel) {
			level = templevel;
			GameObject.Find ("Score").GetComponent<Text> ().text = "" + level;
		}
	}



}
