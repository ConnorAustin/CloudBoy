using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    public Color startingColor;
    public Color endingColor;
    new Light light;
    SpriteRenderer sr;
    float lifetime;

	void Start () {
        light = GetComponent<Light>();
        sr = GetComponent<SpriteRenderer>();
        Rotate();
    }

    void Rotate() {
        Invoke("Rotate", 0.05f);

        transform.LookAt(Camera.main.transform.position);
        transform.Rotate(Vector3.forward, Random.Range(0, 360.0f));
    }

	void Update () {
        if (lifetime < 1.0f)
        {
            lifetime += Time.deltaTime * 0.5f;
            if (lifetime >= 1.0f)
            {
                sr.enabled = false;
            }

            var newColor = Color.Lerp(startingColor, endingColor, lifetime);
            sr.color = newColor;
            light.color = Color.Lerp(startingColor, endingColor, lifetime + Random.Range(-0.1f, 0.1f));
        }
	}
}
