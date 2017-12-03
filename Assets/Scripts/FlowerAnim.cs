using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerAnim : MonoBehaviour {

	GameObject flower;
	GameObject mound;

	Squirtable fill;

	float offset;

	void Start () {
		fill = GetComponent<Squirtable> ();

		flower = transform.Find ("Flower").gameObject;
		mound = transform.Find ("DirtMound").gameObject;

		flower.transform.localScale = new Vector3 (0.0f, 0.0f, 0.0f);

		offset = Random.Range (0, 1000)/1000.0f;
	}
	
	// Update is called once per frame
	void Update () {
		float p = fill.percentFilled / fill.maxFill;

		flower.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f) * p;
		flower.transform.localPosition = new Vector3 (0.0f, 0.35f, 0.0f) * p;

		if (p > 0.85f) {
			float r = (offset + Time.time);
			flower.transform.eulerAngles = new Vector3(Mathf.Sin (r) * 4.0f, Mathf.Sin (r) * 23.0f, Mathf.Sin (r) * 4.0f);
		}
		
	}
}
