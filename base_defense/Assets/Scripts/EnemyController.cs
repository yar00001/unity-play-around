using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public GameObject[] bots;
	// Starting point
	public GameObject nextCheckpoint;
	// Ending point
	public GameObject baseCheckpoint;
	// Choose the Enemy to Spawn
	GameObject toSpawn;

	// Private fields
	private float nextEnemy = 0;
	private float nextWave;
	private int released = 0;
	private int totalWaveReleased = 0;

	void pickEnemy() {
		int r = Random.Range(0, bots.Length);
		toSpawn = bots[r];
		released = 0;
		totalWaveReleased++;
		Debug.Log("New enemy is picked up! Total Wave Released: " + totalWaveReleased);
	}

	void releaseEnemies() {
		if (Time.time > nextEnemy && released < GameManager.gameManager.waveLength) {
			// create a new enemy based on the pickEnemy() result
			GameObject newEnemy = (GameObject) Instantiate(toSpawn, transform.position, Quaternion.identity);
			// move new enemy under Parent object
			newEnemy.transform.parent = this.gameObject.transform;
			EnemyScript enemyScript = newEnemy.GetComponent<EnemyScript>();
			enemyScript.nextCheckpoint = nextCheckpoint;
			enemyScript.baseCheckpoint = baseCheckpoint;

			// ToDo: enemyDelay should be read from EnemyScript
			nextEnemy = Time.time + GameManager.gameManager.maxEnemyReleaseDelay;

			released++;
		}
		if (released == GameManager.gameManager.waveLength) {
			Debug.Log("all enemies in a wave are released!");
			if (totalWaveReleased == GameManager.gameManager.totalWaveNumber) {
				Debug.Log("done with all waves");
			} else {
				nextWave = Time.time + GameManager.gameManager.waveDelay;
				pickEnemy();
			}
		}
	}

	void Start () {
		// Init

		// Select Initial Enemy Type
		pickEnemy();
	}
	
	void Update () {
		// Release the enemy
		if (Time.time > nextWave && totalWaveReleased <= GameManager.gameManager.totalWaveNumber) {
			releaseEnemies();
		}
	}
}
