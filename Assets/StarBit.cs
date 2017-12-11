using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBit : MonoBehaviour {
    public AudioClip collectSound;

    Rigidbody rb;
    bool lchase = false;
    Transform player;

	void Start () {
        player = GameObject.Find("Player").transform;

        rb = GetComponent<Rigidbody>();
        Invoke("LinearChase", 0.3f);
	}

    void LinearChase() {
        lchase = true;
        rb.velocity = Vector3.zero;
    }

    void OnTriggerEnter(Collider other)
    {
        if(lchase && other.gameObject.name == "Player")
        {
            other.GetComponent<AudioSource>().PlayOneShot(collectSound, 0.1f);
            Destroy(gameObject);
        }    
    }

    void FixedUpdate () {
        if(lchase)
        {
            var to = (player.transform.position - transform.position).normalized;
            transform.position += to * 0.3f;
        }
	}
}
