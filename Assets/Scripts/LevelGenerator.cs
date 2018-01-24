using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public GameObject platformPrefab;

	int numberOfPlatforms = 200;
	float levelWidth = 5f;
	float minY = 1.5f;
	float maxY = 5f;
	int currentlevel = 0;
	float[] levels;
	// Use this for initialization
	void Start () {
		Vector3 spawnPosition = new Vector3 ();
		levels = new float[200];
		for(int i=0;i<numberOfPlatforms;i++){
			spawnPosition.y += Random.Range (minY, maxY);
			levels [i] = spawnPosition.y;
			spawnPosition.x = Random.Range(-levelWidth, levelWidth);
			Instantiate (platformPrefab, spawnPosition, Quaternion.identity); 
						//objecttobegenerated//position		//means no rotation of object
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public int CheckLevel(float input){
		return System.Array.BinarySearch (levels, input);
	}
}
