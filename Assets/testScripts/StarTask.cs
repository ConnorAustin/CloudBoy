using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTask : MonoBehaviour {

	public GameObject starPrefab;

	public int pointsNeeded = 1;
	int points = 0;

	// Use this for initialization
	void Start () {
		
	}

	public void addPoint() {
		points++;
		if (points == pointsNeeded) {
			GameObject star = GameObject.Instantiate (starPrefab);
			star.transform.position = transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
