using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpray : MonoBehaviour {
    public GameObject froth;


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

        SpawnFroth().AddForce(force * 100);
    }

    void Update () {
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
