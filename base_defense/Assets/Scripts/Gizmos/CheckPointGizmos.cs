using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointGizmos : MonoBehaviour {

/// <summary>
	/// Callback to draw gizmos that are pickable and always drawn.
	/// </summary>
	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(transform.position, 0.2f);
	}
}
