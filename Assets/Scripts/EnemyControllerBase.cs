using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerBase : MonoBehaviour {

	GroundMover mover;

	public GameObject patrol;
	public float detectPlayerRange = 10;
	protected bool chasing = false;
    protected bool dead;

	int patrolIndex;
	GameObject nextPoint;
    Squirtable squirtable;
	GameObject player;

	void Start () {
		controllerInit ();
	}

	public void controllerInit() {
		mover = GetComponent<GroundMover>();
		findNearestPatrolPoint ();
		player = GameObject.FindWithTag ("Player");
	}

	void findNearestPatrolPoint() {
		int count = patrol.transform.childCount;

		float bestDist = 1000000;
		int bestInd = -1;

		for (int i = 0; i < count; i++) {
			float d = Vector3.Distance(transform.position, patrol.transform.GetChild(i).position);
			if (d < bestDist) {
				bestDist = d;
				bestInd = i;
			}
		}

		if (bestInd != -1) {
			patrolIndex = bestInd;
			nextPoint = patrol.transform.GetChild (patrolIndex).gameObject;
		}
	}

    protected virtual void Die() {
        dead = true;
        GameObject spark = Resources.Load<GameObject>("Prefabs/spark");
        for (int i = 0; i < 5; i++)
        {
            GameObject s = GameObject.Instantiate(spark);
            s.transform.position = transform.position;
        }
        DeathSmoke();

        mover.Move(Vector3.zero);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    void DeathSmoke() {
        Invoke("DeathSmoke", 0.3f);
        GameObject smoke = Resources.Load<GameObject>("Prefabs/smoke");
        var s = GameObject.Instantiate(smoke);
        s.transform.position = transform.position;
    }

    // Called by squirtable
    void SquirtableFilled() {
        Die();
    }

    void FixedUpdate () {
        if (dead)
        {
            return;
        }

		float playerDist = Vector3.Distance (transform.position, player.transform.position);
		if (playerDist < detectPlayerRange) {
			chasing = true; //TODO: make an exclamation mark appear above their head

			Vector3 diff = player.transform.position - transform.position;
			diff.y = 0;

			mover.Move (diff);
		}
		else if (nextPoint != null) {
			if (chasing) {
				chasing = false;
				findNearestPatrolPoint ();
			}

			Vector3 diff = nextPoint.transform.position - transform.position;
			diff.y = 0;

			float distToPatrol = Vector3.Distance (transform.position, nextPoint.transform.position);

			mover.Move (diff);

			if (distToPatrol < 1f) {
				patrolIndex++;
				patrolIndex %= patrol.transform.childCount;
				nextPoint = patrol.transform.GetChild (patrolIndex).gameObject;

			}

		}

		EnemyUpdate ();

	}

	public virtual void EnemyUpdate() {

	}
}
