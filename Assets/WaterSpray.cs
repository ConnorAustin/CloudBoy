using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpray : MonoBehaviour {
	void Start () {
		
	}
	
	void Update () {
        transform.LookAt(Camera.main.transform.position);
	}

    void OnDestroy()
    {
           
    }
}
