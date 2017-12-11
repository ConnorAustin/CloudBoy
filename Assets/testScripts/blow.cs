using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blow : MonoBehaviour
{
    public Vector3 Force = Vector3.zero;
    private List<Collider> objects = new List<Collider>();
    GameObject puff;
    GameObject line;

    void Start()
    {
        puff = Resources.Load<GameObject>("Prefabs/puff");
        line = Resources.Load<GameObject>("Prefabs/WindLine");
        Puff();
    }

    void Puff()
    {
        Invoke("Puff", 0.2f);
        if (enabled && Force.magnitude > 0.0f)
        {
            var p = GameObject.Instantiate(puff);
            p.transform.position = transform.position + UnityEngine.Random.insideUnitSphere;
            p.GetComponent<Rigidbody>().AddForce(Force * 15);
        }
    }

    void FixedUpdate()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            var obj = objects[i];
            if (obj != null && obj.gameObject != null)
            {
                Rigidbody body = obj.attachedRigidbody;
                body.AddForce(Force);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null && other.gameObject.layer != LayerMask.NameToLayer("Squirt"))
            objects.Add(other);
    }
    void OnTriggerExit(Collider other)
    {
        try
        {
            objects.Remove(other);
        }
        catch (Exception)
        {

        }
    }
}
