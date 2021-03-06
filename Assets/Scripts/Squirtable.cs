﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirtable : Flameable {
	public float maxFill = 100.0f;
	public float percentFilled = 0.0f;

	public bool playPop = false;

    float wetTimer;
    bool filled = false;

	public bool givepoint = false;

    void Start()
    {
        tag = "Squirtable";
    }

	public override void touchFire() {
		percentFilled = Mathf.Max (0.0f, percentFilled - 1.0f);
		filled = false;
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
                SendMessage("SquirtableFilled", SendMessageOptions.DontRequireReceiver);
				if (playPop) {
					GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Sounds/pop"), 0.4f);
				}

				if (givepoint) {
					StarTask task = transform.GetComponentInParent<StarTask> ();
					if (task != null) {
						task.addPoint ();
					}
				}
            }
        }

        wetTimer -= Time.deltaTime;
    }
}
