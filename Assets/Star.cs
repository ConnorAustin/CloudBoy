using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {
    public GameObject sparkle;
    public AudioClip collectSound;

    GameObject starBit;

	void Start () {
        starBit = Resources.Load<GameObject>("Prefabs/StarBit");	
	}
	
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            other.GetComponent<AudioSource>().PlayOneShot(collectSound);

            for(int i = 0; i < 10; i++)
            {
                var s = GameObject.Instantiate(sparkle);
                s.transform.position = transform.position + Random.insideUnitSphere;
            }

            var p = other.gameObject.GetComponent<Player>();
            p.AddStar();
            
            Destroy(gameObject);

            for(int i = 0; i < 8; i++)
            {
                float angle = i * 360.0f / 8;
                var dir = new Vector3(Mathf.Cos(angle), 0.1f, Mathf.Sin(angle));
                var sb = GameObject.Instantiate(starBit);
                sb.transform.position = transform.position;
                sb.GetComponent<Rigidbody>().AddForce(dir * 700);
            }
        }    
    }
}
