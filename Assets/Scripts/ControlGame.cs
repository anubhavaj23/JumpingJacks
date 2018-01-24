using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlGame : MonoBehaviour {

	GameObject aObject;
	Button aButton;
	public GameObject Doodler;
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		aObject = GameObject.Find ("Button");
		aButton = aObject.GetComponentInChildren<Button> ();
		rb = Doodler.GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Myfunction(){
		string nameOfButton = aButton.GetComponentInChildren<Text> ().text;
		if (nameOfButton.Trim().Equals ("Play")) {
			aButton.gameObject.SetActive (false);
			aButton.GetComponentInChildren<Text> ().text = "Restart";
			//(GameObject.Find ("Score")).SetActive (true);
			StartDoodle ();
		} else if (nameOfButton.Equals ("Restart")) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}

	void StartDoodle(){
		rb.constraints = (RigidbodyConstraints2D)RigidbodyConstraints.None;
		rb.freezeRotation = true;
		Debug.Log ("start doodle method called");
	}


}
