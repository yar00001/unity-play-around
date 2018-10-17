using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour {

	[SerializeField] private GameObject cardBack;
	[SerializeField] private SceneController sceneController;

	public int ID {get; set; }
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Mouse Click CallBack
	public void OnMouseDown() {
		
		if (sceneController.CanReveal()) {
			sceneController.Reveal(this);
		}
		
		if (cardBack.activeSelf) {
			cardBack.SetActive(false);
		}
	}

	public void SetCard(int id, Sprite image) {
		this.ID = id;
		GetComponent<SpriteRenderer>().sprite = image;
	}

	// Hide a card
	public void Unreveal() {
		cardBack.SetActive(true);
	}
}
