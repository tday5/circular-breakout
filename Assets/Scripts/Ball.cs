using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Represents a ball projectile in the game
public class Ball : MonoBehaviour {

	// The rigidbody2d of this ball
	private Rigidbody2D rb;

	// Set the rigidbody2d
	void Awake() {
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}

	// Set the starting speed of this ball towards the center of the scene at the given speed
	public void SetStartSpeed(float ballSpeed) {
		rb.AddForce (
			new Vector2 (-gameObject.transform.position.x, -gameObject.transform.position.y).normalized * ballSpeed);
	}

	// Increases the current speed of this ball by the given amount
	public void IncreaseSpeed(float increase) {
		rb.AddForce (rb.velocity.normalized * increase);
	}
}
