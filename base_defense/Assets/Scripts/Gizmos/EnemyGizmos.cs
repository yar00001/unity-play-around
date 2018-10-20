using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGizmos : MonoBehaviour {

	/// <summary>
	/// Callback to draw gizmos that are pickable and always drawn.
	/// </summary>
	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawCube(transform.position, new Vector2(0.5f, 0.5f));
	}
}
