using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanBot : EnemyControllerBase {
	FanAnim fanAnim;
	blow blower;
	public float force;
	public float upforce;

	void Start () {
        controllerInit ();
		fanAnim = transform.Find ("FanBot").GetComponent<FanAnim> ();
		blower = GetComponent<blow> ();
	}

    protected override void Die()
    {
        base.Die();
        GetComponentInChildren<FanAnim>().enabled = false;
        GetComponentInChildren<blow>().enabled = false;
    }

    public override void EnemyUpdate() {
        if (dead)
        {
            return;
        }

        if (chasing) {
			fanAnim.blowing = true;
			blower.Force = transform.forward * force + Vector3.up * upforce;
		} else {
			fanAnim.blowing = false;
			blower.Force = Vector3.zero;
		}
	}
}
