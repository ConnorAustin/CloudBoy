using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blow : MonoBehaviour {
	public Vector3 Force = Vector3.zero;
	private List<Collider> objects = new List<Collider>();

	void FixedUpdate()
	{
		for (int i = 0; i < objects.Count; i++) {
			print ("iterating");
			Rigidbody body = objects [i].attachedRigidbody;
			body.AddForce(Force);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		print ("Added: " + other); 
		objects.Add(other);
	}
	void OnTriggerExit(Collider other)
	{
		print ("Removed: " + other); 
		objects.Remove (other);
	}
}
