using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blow : MonoBehaviour {
	public Vector3 Force = Vector3.zero;
	private List<Collider> objects = new List<Collider>();

	void FixedUpdate()
	{
		for (int i = 0; i < objects.Count; i++) {
			Rigidbody body = objects [i].attachedRigidbody;
			body.AddForce (Force);
		}
	}
	void OnTriggerEnter(Collider other)
	{ 
		if(other.attachedRigidbody != null)
			objects.Add(other);
	}
	void OnTriggerExit(Collider other)
	{
		objects.Remove (other);
	}
}
