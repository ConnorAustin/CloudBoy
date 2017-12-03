using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerAnim : MonoBehaviour {
    public GameObject sparkle;

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
	
    // Sent by squirtable
    void SquirtableFilled()
    {
        Shine();

        for (int i = 0; i < 20; i++)
        {
            var s = GameObject.Instantiate(sparkle);
            s.transform.position = transform.position;
            Vector3 v = Random.onUnitSphere;
            v.y = Mathf.Abs(v.y);
            s.GetComponent<Rigidbody>().AddForce(v * 200);
            s.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    void Shine()
    {
        Invoke("Shine", Random.Range(0.4f, 1.0f));

        var s = GameObject.Instantiate(sparkle);
        Vector3 v = Random.onUnitSphere;
        v.y = Mathf.Abs(v.y);
        s.transform.position = transform.position + v + Vector3.up * 0.5f;
    }

    // Update is called once per frame
    void Update () {
		float p = fill.percentFilled / fill.maxFill;

		flower.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f) * p;
		flower.transform.localPosition = new Vector3 (0.0f, 0.35f, 0.0f) * p;

		if (fill.IsFull()) {
			float r = (offset + Time.time);
			flower.transform.eulerAngles = new Vector3(Mathf.Sin (r) * 4.0f, Mathf.Sin (r) * 23.0f, Mathf.Sin (r) * 4.0f);
		}
	}
}
