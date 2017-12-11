using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFirethrower : MonoBehaviour {
    public GameObject fire;

	// Use this for initialization
	void Start () {
        Fire();
	}

    void Fire() {
        Invoke("Fire", 0.1f);
        var f = GameObject.Instantiate(fire);
        f.transform.position = transform.position;
        f.GetComponent<Rigidbody>().AddForce(transform.forward * 200);
    }
}
