using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDeath : MonoBehaviour {

	GameObject aObject;
	Button aButton;
	public GameObject Doodler;
	Rigidbody2D rb;
	public Sprite image1;

	void Start (){
		aObject = GameObject.Find ("Button");
		aButton = aObject.GetComponentInChildren<Button> ();
		rb = Doodler.GetComponent<Rigidbody2D> ();
	}

	void Update(){
		
		float size = Camera.main.orthographicSize;
		float lowerbound = Camera.main.gameObject.transform.position.y - size;
		//Debug.Log (transform.position.y + "       " + lowerbound);
		if (transform.position.y < lowerbound) {
			//Debug.Log ("should die");
			if (!aButton.IsActive ()) {
				rb.constraints = (RigidbodyConstraints2D)RigidbodyConstraints.FreezeAll;
				aButton.image.sprite = image1;
				aButton.gameObject.SetActive (true);
				//GameObject.Find ("Score").gameObject.SetActive (false);
			}
		}
	}

}
