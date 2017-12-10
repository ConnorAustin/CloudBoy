using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBoiAnim : MonoBehaviour {
	GameObject leftFoot;
	GameObject rightFoot;
    GameObject cloudPoint;
    public GameObject cloudPuff;

    public float walkSpeed = 10.0f;
	public float stride = 15.0f;

	public bool walking;
    bool jumping;
    bool hovering;
    float jumpAccumlator;
	float walkAccumlator;
    FanAnim hat;
    float hatMaxVel;

    void Start () {
        hat = GetComponentInChildren<FanAnim>();
        hatMaxVel = hat.maxVel;
        leftFoot = transform.Find ("LeftFoot").gameObject;
		rightFoot = transform.Find ("RightFoot").gameObject;
        walkAccumlator = 0.0f;
        jumpAccumlator = 0.0f;
        Puff();
    }

	public void setWalking(bool nwalking) {
		walking = nwalking;
	}

    public void Jump()
    {
        leftFoot.SetActive(true);
        rightFoot.SetActive(true);
        jumping = true;
        jumpAccumlator = 0;
    }

    public void Land()
    {
        NoHover();
        jumping = false;
        leftFoot.transform.localRotation = Quaternion.Euler(new Vector3(Mathf.Sin(walkAccumlator * walkSpeed) * 10.0f, 0.0f, Mathf.Sin(walkAccumlator * walkSpeed) * stride));
        rightFoot.transform.localRotation = Quaternion.Euler(new Vector3(-Mathf.Sin(walkAccumlator * walkSpeed) * 10.0f, 0.0f, -Mathf.Sin(walkAccumlator * walkSpeed) * stride));
    }

    public void Hover() {
        hovering = true;
        hat.maxVel = 5.0f * hatMaxVel;
        leftFoot.SetActive(false);
        rightFoot.SetActive(false);
    }

    public void NoHover() {
        hovering = false;
        hat.maxVel = hatMaxVel;
        leftFoot.SetActive(true);
        rightFoot.SetActive(true);
    }

    void Puff() {
        Invoke("Puff", 0.2f);
        if(hovering)
        {
            var puff = GameObject.Instantiate(cloudPuff);
            puff.transform.position = transform.position + Random.insideUnitSphere * 0.5f;
        }
    }

	void Update () {
        if(jumping)
        {
            leftFoot.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, Mathf.Sin(jumpAccumlator) * 50.0f));
            rightFoot.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, Mathf.Sin(jumpAccumlator) * 50.0f));
            
            jumpAccumlator += 9.0f *  Time.deltaTime;
            jumpAccumlator = Mathf.Min(jumpAccumlator, Mathf.PI / 2.0f);
        }
		else if (walking) {
			walkAccumlator += Time.deltaTime;
			leftFoot.transform.localRotation = Quaternion.Euler(new Vector3 (Mathf.Sin (walkAccumlator * walkSpeed) * 10.0f, 0.0f, Mathf.Sin (walkAccumlator * walkSpeed) * stride));
			rightFoot.transform.localRotation = Quaternion.Euler(new Vector3 (-Mathf.Sin (walkAccumlator * walkSpeed) * 10.0f, 0.0f, -Mathf.Sin (walkAccumlator * walkSpeed) * stride));
		}
	}
}
