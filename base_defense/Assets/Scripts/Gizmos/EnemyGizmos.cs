using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGizmos : MonoBehaviour {

	private Transform targetCheckpoint;

	/// <summary>
	/// Callback to draw gizmos that are pickable and always drawn.
	/// </summary>
	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position, 0.2f);

		if (this.GetComponent<EnemyController>().nextCheckpoint != null) {
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(transform.position, 0.2f);
			targetCheckpoint = this.GetComponent<EnemyController>().nextCheckpoint.transform;
			Gizmos.DrawLine(transform.position, targetCheckpoint.position);
		}
	}
}
