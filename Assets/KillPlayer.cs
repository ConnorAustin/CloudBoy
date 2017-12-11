using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            other.GetComponent<Player>().AddWater(-420);
        }
    }
}
