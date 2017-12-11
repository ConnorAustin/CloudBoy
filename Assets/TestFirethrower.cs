using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFirethrower : MonoBehaviour {
    public GameObject fire;
	AudioSource fireaudio;

	public bool throwinFire = false;

	// Use this for initialization
	void Start () {
		fireaudio = gameObject.GetComponent<AudioSource> ();
        Fire();

	}

    void Fire() {
        Invoke("Fire", 0.025f);
		if (throwinFire) {
			var f = GameObject.Instantiate (fire);
			f.transform.position = transform.position;
			f.GetComponent<Rigidbody> ().AddForce (transform.forward * 800);
			fireaudio.mute = false;
		} else {
			fireaudio.mute = true;
		}
    }
}
