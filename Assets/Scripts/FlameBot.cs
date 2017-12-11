using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBot : EnemyControllerBase {

	TestFirethrower firethrower;

	void Start () {
        controllerInit ();
		firethrower = transform.Find ("flamethrower").GetComponent<TestFirethrower> ();
	}

    protected override void Die()
    {
		firethrower.throwinFire = false;
		firethrower.enabled = false;
        base.Die();
    }

    public override void EnemyUpdate() {
        if (dead)
        {
            return;
        }

        if (chasing) {
			firethrower.throwinFire = true;
		} else {
			firethrower.throwinFire = false;
		}
	}
}
