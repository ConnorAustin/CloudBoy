using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heightlimiter : MonoBehaviour {
	// Update is called once per frame
	public float originalz, originaly, originalx;

	void Start() {
		originalx = transform.position.x;
		originaly = transform.position.y;
		originalz = transform.position.z;
	}

	void FixedUpdate () {
		if(transform.position.y > originaly) {
			transform.position = new Vector3(originalx, originaly, originalz);
		}
	}
}
