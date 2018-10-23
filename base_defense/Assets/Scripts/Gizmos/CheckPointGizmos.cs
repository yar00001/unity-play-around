using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointGizmos : MonoBehaviour {

	private Transform targetCheckpoint;

	/// <summary>
	/// Callback to draw gizmos that are pickable and always drawn.
	/// </summary>
	void OnDrawGizmos()
	{
		// Connect the checkpoints with a line
		if (this.GetComponent<CheckPointController>().nextCheckpoint) {
			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere(transform.position, 0.2f);
			targetCheckpoint = this.GetComponent<CheckPointController>().nextCheckpoint.transform;
			Gizmos.DrawLine(transform.position, targetCheckpoint.position);
		} else {
			Gizmos.color = Color.green;
			Gizmos.DrawSphere(transform.position, 0.2f);
		}
	}
}
