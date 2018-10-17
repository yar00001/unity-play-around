using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour
{

    [SerializeField] GameObject targetObj;
    [SerializeField] string targetMessage;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.blue;
        }
    }

    void OnMouseExit()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.white;
        }
    }

	void OnMouseDown() {
		transform.localScale = new Vector3(0.55f,0.55f,0);
	}

	void OnMouseUp() {
		transform.localScale = new Vector3(0.5f,0.5f,0);

		// Send message to a target GameObject
		if (targetObj != null) {
			targetObj.SendMessage(targetMessage);
		}
	}
}
