using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    const float waterFill = 20;
    const float respawnTime = 10.0f;
    bool dead = false;

    void Start()
    {

    }

    void Respawn()
    {
        dead = false;
        GetComponent<MeshRenderer>().enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (dead)
            return;
        var o = other.gameObject;
        if (o.name == "Player")
        {
            o.GetComponent<Player>().AddWater(waterFill);
            GetComponent<MeshRenderer>().enabled = false;
            Invoke("Respawn", respawnTime);
            dead = true;
            GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Sounds/pop"), 0.4f);
            var squirt = Resources.Load<GameObject>("Prefabs/squirt");
            
            for (int i = 0; i < 20; i++) {
                var s = GameObject.Instantiate(squirt);
                s.transform.position = transform.position;
                var force = Random.onUnitSphere;
                force.y = Mathf.Abs(force.y);
                s.GetComponent<Rigidbody>().AddForce(force * 200);
            }
        }
    }

    void Update()
    {

    }
}
