using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnim : MonoBehaviour {

	GameObject one;
	GameObject two;

	float offset;

	// Use this for initialization
	void Start () {
		offset = Random.Range (0, 1000)/1000.0f;
		one = transform.Find ("One").gameObject;
		two = transform.Find ("Two").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		float r = (offset + Time.time)*0.1f;
		one.transform.eulerAngles = new Vector3 (Mathf.Sin(r)*360.0f, Mathf.Sin(r)*360.0f, Mathf.Sin(r)*360.0f);
		two.transform.eulerAngles = new Vector3 (Mathf.Cos(r)*360.0f, Mathf.Cos(r)*360.0f, Mathf.Cos(r)*360.0f);
	}
}
