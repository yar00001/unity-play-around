using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Individual Enemy Settings (HP, Power etc.)
 */
public class EnemyScript : MonoBehaviour {

	private Vector3 lastPosition;
	[HideInInspector]public GameObject nextCheckpoint;
	[HideInInspector]public GameObject baseCheckpoint;

	// Public Attributes
	public float speed;

	void moveToPosition() {
		float step = speed * Time.deltaTime;

		transform.position = Vector2.MoveTowards(transform.position, 
			nextCheckpoint.transform.position, 
			step);

		// when we get to the end of the path
		if (transform.position == baseCheckpoint.transform.position) {
			// nextCheckpoint = null;
			hit();
		}
		// when we get to the checkpoint, pick the next one
		else if (transform.position == nextCheckpoint.transform.position) {

			nextCheckpoint = nextCheckpoint.GetComponent<CheckPointController>().nextCheckpoint;
		}
	}

	void hit() {
		// damage the base
		GameManager.gameManager.damageBase(1);
		// Removing the Object this script is in (prefab object)
		// If you use Destory(this), only the script is removed but the object
		// remains at the scene: https://answers.unity.com/questions/1129475/this-vs-gameobject.html
		Destroy(gameObject);
	}

	void Start () {
		lastPosition = gameObject.transform.position;
	}
	
	void Update () {
		if (nextCheckpoint != null) {
			moveToPosition();
		}
	}
}
