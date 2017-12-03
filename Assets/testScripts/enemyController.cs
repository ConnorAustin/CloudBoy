using UnityEngine;

public class enemyController : MonoBehaviour
{
	public Transform target;
	public float speed;
	public Transform point1;
	public Transform point2;
	public Transform point3;
	public Transform player;
	public float reactionDist = 10;

	void FixedUpdate()
	{
		float step = speed * Time.deltaTime;
		player = GameObject.FindGameObjectWithTag ("Player").transform;

		float dist = Vector3.Distance(player.position, transform.position);

		if (target == point1) {
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
			if(transform.position == target.position) { target = point2; }

		} else if (target == point2) {
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
			if (transform.position == target.position) { target = point3; }
		} else if (target == point3) {
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
			if (transform.position == target.position) { target = point1; }
		} else {
			target = point1;
		}
		if (dist < reactionDist) {
			target = player;
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
		}

		if(Vector3.Distance(transform.position, target.position) > 2) {
			transform.LookAt(target);
		}
	}
}