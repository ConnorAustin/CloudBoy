using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBoiAnim : MonoBehaviour {

	GameObject leftFoot;
	GameObject rightFoot;

	public float walkSpeed = 10.0f;
	public float stride = 15.0f;

	public bool walking;
    bool jumping;
    float jumpAccumlator;
	float walkAccumlator;

	void Start () {
		leftFoot = transform.Find ("LeftFoot").gameObject;
		rightFoot = transform.Find ("RightFoot").gameObject;
		walkAccumlator = 0.0f;
        jumpAccumlator = 0.0f;
    }

	public void setWalking(bool nwalking) {
		walking = nwalking;
	}

    public void Jump()
    {
        jumping = true;
        jumpAccumlator = 0;
    }

	void Update () {
        if(jumping)
        {
            leftFoot.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, Mathf.Sin(jumpAccumlator) * 50.0f));
            rightFoot.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, Mathf.Sin(jumpAccumlator) * 50.0f));
            jumpAccumlator += 9.0f *  Time.deltaTime;
            if(jumpAccumlator > Mathf.PI)
            {
                jumping = false;
            }
        }
		else if (walking) {
			walkAccumlator += Time.deltaTime;
			leftFoot.transform.localRotation = Quaternion.Euler(new Vector3 (Mathf.Sin (walkAccumlator * walkSpeed) * 10.0f, 0.0f, Mathf.Sin (walkAccumlator * walkSpeed) * stride));
			rightFoot.transform.localRotation = Quaternion.Euler(new Vector3 (-Mathf.Sin (walkAccumlator * walkSpeed) * 10.0f, 0.0f, -Mathf.Sin (walkAccumlator * walkSpeed) * stride));
		}
	}
}
