using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Vector3 fd = Random.onUnitSphere;
        fd.y = Mathf.Abs(fd.y);
        GetComponent<Rigidbody>().AddForce(fd * 200);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
