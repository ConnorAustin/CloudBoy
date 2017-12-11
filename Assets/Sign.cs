using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour {
    public string message;

	void Start () {
		
	}
	
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            Canvas.self.ShowMessage(message);
        }    
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Canvas.self.ShowMessage("");
        }
    }
}
