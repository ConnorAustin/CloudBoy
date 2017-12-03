using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirtable : MonoBehaviour {
	public float maxFill = 100.0f;
	public float percentFilled = 0.0f;

    float wetTimer;
    bool filled = false;

    void Start()
    {
        tag = "Squirtable";
    }

    public void Wet()
    {
        wetTimer = 1.0f;
    }

    public bool IsFull()
    {
        return filled;
    }

    void Update()
    {
        if(wetTimer > 0)
        {
            percentFilled = Mathf.Min(maxFill, 30 * Time.deltaTime + percentFilled);
            if(!filled && maxFill - percentFilled < 0.01f)
            {
                filled = true;
                percentFilled = maxFill;
                SendMessage("SquirtableFilled");
            }
        }

        wetTimer -= Time.deltaTime;
    }
}
