using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour {
	void Start () {
		
	}
	
	void Update () {
        transform.position += Vector3.up * Time.deltaTime * 2.0f;
	}
}
