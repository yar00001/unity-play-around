using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Manages Player HP and Enemy power.
 * ** Static Implementation **
 */
public class GameManager : MonoBehaviour {
	// Enemy options
	public int totalWaveNumber = 20;
	public int avgWaveLength = 15;
	// Player options
	public int playerMaxHP = 20;
	// Managing pause/play
	private float normalTimeScale = 1;

	// Static instance of GameManager
	public static GameManager gameManager;

	public void damageBase(int damage) {
		playerMaxHP -= damage;
		if (playerMaxHP <= 0) {
			Time.timeScale = 0;		// pause the game
		}

		Debug.Log("updatd base HP: " + playerMaxHP);
	}

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// This makes gameManager static.
	/// </summary>
	void Awake()
	{
		if (gameManager != null) {
			GameManager.Destroy(gameManager);
		} else {
			gameManager = this;
		}

		DontDestroyOnLoad(this);
	}

	void Start () {
		Time.timeScale = normalTimeScale;
	}
}
