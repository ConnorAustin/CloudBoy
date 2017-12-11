using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour {
    public GameObject sparkle;
    Vector3 normalSize;
    Squirtable squirtable;
    float sizeToScale;
    BoxCollider box;
	CapsuleCollider cap;
    bool full = false;

	void Start () {
        normalSize = transform.localScale;
        squirtable = transform.parent.GetComponent<Squirtable>();
        box = transform.parent.GetComponent<BoxCollider>();
		cap = transform.parent.GetComponent<CapsuleCollider> ();
        transform.parent.gameObject.layer = LayerMask.NameToLayer("Default");

        var player = GameObject.Find("Player").GetComponent<CapsuleCollider>();
        Physics.IgnoreCollision(box, player);
		Physics.IgnoreCollision(cap, player);
	}

    void Shine()
    {
        Invoke("Shine", Random.Range(0.4f, 1.0f));

        var s = GameObject.Instantiate(sparkle);
        Vector3 v = Random.onUnitSphere;
        v.y = Mathf.Abs(v.y);
        s.transform.position = transform.position + v + Vector3.up * 0.5f;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(Vector3.one * 0.2f, normalSize, squirtable.percentFilled / squirtable.maxFill);

        if(squirtable.IsFull() && !full)
        {
            full = true;
            Shine();
            var player = GameObject.Find("Player").GetComponent<CapsuleCollider>();
            Physics.IgnoreCollision(box, player, false);
			Physics.IgnoreCollision(cap, player, false);
            transform.parent.gameObject.layer = LayerMask.NameToLayer("Ground");
        }
    }
}
