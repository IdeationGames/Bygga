using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headMove : MonoBehaviour
{
	public GameObject leftStop;
	public GameObject rightStop;
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
		//horizontalMove = Input.GetAxis("Horizontal") * 2;
		horizontalMove = Input.GetAxis("Horizontal") * 100;

		Vector2 currentPosition = transform.position;
		// linear function: y = mx + b; 0.28f is a trial and error result
		Vector2 moveDirection = new Vector2(horizontalMove * Time.deltaTime, -1 * 0.28f * horizontalMove * Time.deltaTime);
        //rigidBody.MovePosition(currentPosition + moveDirection);
        rigidBody.velocity = limitVelocity(moveDirection);
	}

	private Vector2 limitVelocity(Vector2 velocity)
	{
		Vector2 newVelocity = velocity;

		if (transform.position.x < this.leftStop.transform.position.x)
		{
			newVelocity.x = newVelocity.x < 0.0f ? 0.0f : newVelocity.x;
			newVelocity.y = 0.0f;
		}
		if (transform.position.x > this.rightStop.transform.position.x)
		{
			newVelocity.x = newVelocity.x > 0.0f ? 0.0f : newVelocity.x;
			newVelocity.y = 0.0f;
		}
		return newVelocity;
	}
}
