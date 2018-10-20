using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public GameObject[] bots;
	// Starting point
	public GameObject nextCheckpoint;
	// Choose the Enemy to Spawn
	GameObject toSpawn;

	void pickEnemy() {
		toSpawn = bots[0];	// hardcode the first enemy for testing
	}

	void releaseEnemies() {
		// create a new enemy based on the pickEnemy() result
		GameObject newEnemy = (GameObject) Instantiate(toSpawn, transform.position, Quaternion.identity);
		// move new enemy under Parent object
		newEnemy.transform.parent = this.gameObject.transform;
		EnemyScript enemyScript = newEnemy.GetComponent<EnemyScript>();
		enemyScript.nextCheckpoint = nextCheckpoint;
	}

	void Start () {
		// Select Enemy
		pickEnemy();

		// Release the only one enemy
		releaseEnemies();
	}
	
	void Update () {
		// No update since we are creating only one enemy
	}
}
