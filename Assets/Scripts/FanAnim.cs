using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanAnim : MonoBehaviour {

	GameObject blades;
	public float accel = 0.1f;
	public float friction = 0.9f;
	public float maxVel = 8.0f;

	public Vector3 rotDir = new Vector3 (1.0f, 0.0f, 0.0f);

	public bool blowing = false;

	float vel;

	void Start () {
		blades = transform.Find ("Blade").gameObject;
		vel = 0.0f;
	}

	void Update () {
		if (blowing) {
			vel += accel;
			if (vel > maxVel) {
				vel = maxVel;
			}

		} else {
			if (vel > 0.0f) {
				vel *= friction;
				if (vel <= 0.2f) {
					vel = 0.0f;
				}
			}
		}

		if (vel > 0.0f) {
			Vector3 rot = blades.transform.eulerAngles;
			rot  += rotDir*vel;
			blades.transform.eulerAngles = rot;


			//TODO: add particles and sounds

		}

	}

}
