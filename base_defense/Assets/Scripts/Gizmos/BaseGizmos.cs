using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGizmos : MonoBehaviour {

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawCube(transform.position, new Vector2(0.5f, 0.5f));
	}
}
