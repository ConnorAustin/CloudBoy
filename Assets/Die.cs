using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour {
    public float deathTime;

	void Start () {
        Invoke("PlzDie", deathTime);	
	}

    void PlzDie()
    {
        Destroy(gameObject);
    }
}
