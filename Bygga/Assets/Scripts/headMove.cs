using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headMove : MonoBehaviour
{
	private Rigidbody2D rigidBody;
	private float horizontalMove = 0.0f;

	// Use this for initialization
	void Start ()
	{
		rigidBody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void FixedUpdate()
	{
		horizontalMove = Input.GetAxis("Horizontal") * 2;

		Vector2 currentPosition = transform.position;
		// linear function: y = mx + b; 0.28f is a trial and error result
		Vector2 moveDirection = new Vector2(horizontalMove * Time.deltaTime, -1 * 0.28f * horizontalMove * Time.deltaTime);
		rigidBody.MovePosition(currentPosition + moveDirection);
	}
}
