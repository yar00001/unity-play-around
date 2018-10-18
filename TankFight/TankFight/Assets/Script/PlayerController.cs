using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;

	// Keyboard Actions
	public KeyCode left;
	public KeyCode right;
	public KeyCode jump;
	public KeyCode shoot;

	private Rigidbody2D theRB;

	// GroundCheck
	public Transform groundCheckPoint;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	bool isGrounded;

	// Use this for initialization
	void Start () {
		theRB = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {

		// Check if we are on the ground
		isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
		
		// Left/Right movement
		if (Input.GetKey(left)) {
			theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
		}
		else if (Input.GetKey(right)) {
			theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
		} else {
			theRB.velocity = new Vector2(0, theRB.velocity.y);
		}

		// Jump - only jump when on the ground
		if (Input.GetKey(jump) && isGrounded) {
			theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
		}
	}
}
