using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBoiAnim : MonoBehaviour {

	GameObject leftFoot;
	GameObject rightFoot;

	public float walkSpeed = 10.0f;
	public float stride = 15.0f;

	public bool walking;
	float walkAccumlator;

	void Start () {
		leftFoot = transform.Find ("LeftFoot").gameObject;
		rightFoot = transform.Find ("RightFoot").gameObject;
		walkAccumlator = 0.0f;

	}

	public void setWalking(bool nwalking) {
		walking = nwalking;
	}

	void Update () {
		if (walking) {
			walkAccumlator += Time.deltaTime;
            Quaternion localLeft = leftFoot.transform.localRotation;
			leftFoot.transform.localRotation = Quaternion.Euler(new Vector3 (Mathf.Sin (walkAccumlator * walkSpeed) * 10.0f, 0.0f, Mathf.Sin (walkAccumlator * walkSpeed) * stride));
			rightFoot.transform.localRotation = Quaternion.Euler(new Vector3 (-Mathf.Sin (walkAccumlator * walkSpeed) * 10.0f, 0.0f, -Mathf.Sin (walkAccumlator * walkSpeed) * stride));
		}
	}
}
