using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpray : MonoBehaviour {
    public GameObject froth;
    public Color from;
    public Color to;
    public float colorSpeed;
    float colorLerp = 0;
    SpriteRenderer sr;

    Rigidbody SpawnFroth()
    {
        var f = GameObject.Instantiate(froth);
        f.transform.position = transform.position;
        var rigid = f.GetComponent<Rigidbody>();

        return rigid;
    }

	void Start () {
        float angle = Random.Range(0, 360);
        var force = Vector3.right * Mathf.Cos(angle) + Vector3.up * Mathf.Sin(angle);
        sr = GetComponent<SpriteRenderer>();
        SpawnFroth().AddForce(force * 100);
    }

    void Update () {
        colorLerp += Time.deltaTime * colorSpeed;
        Color c = Color.Lerp(from, to, colorLerp);
        c.a = sr.color.a;
        sr.color = c;
	}

    void OnDestroy()
    {
        SpawnFroth();
        float angle = Random.Range(0, 360);

        var force = Vector3.right * Mathf.Cos(angle) + Vector3.forward * Mathf.Sin(angle);
        force *= 50;

        force.y = Random.Range(190, 200);

        SpawnFroth().AddForce(force);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Squirtable")
        {
            collision.gameObject.GetComponent<Squirtable>().Wet();
        }
        Destroy(gameObject);
    }
}
