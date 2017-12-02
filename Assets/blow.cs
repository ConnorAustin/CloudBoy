using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blow : MonoBehaviour {
	public float thrust = 40;
	public Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}
	void FixedUpdate() {
		rb.AddForce(transform.forward * thrust);
	}
}
