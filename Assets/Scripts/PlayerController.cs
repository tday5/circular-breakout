using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls the player object in the game
public class PlayerController : MonoBehaviour {

	// Speed of the player
	public float playerSpeed;
	// The prefab of the ball
	public Ball ballPrefab;

	// The instance of the ball in the game
	private Ball ballInstance;

	// Moves the player object left
	public void MoveLeft() {
		gameObject.transform.RotateAround (Vector2.zero, new Vector3 (0, 0, -1), playerSpeed * Time.deltaTime);
	}

	// Moves the player object right
	public void MoveRight() {
		gameObject.transform.RotateAround (Vector2.zero, new Vector3 (0, 0, 1), playerSpeed * Time.deltaTime);
	}

	// Fires a brick towards the center of the game from the player object's position using the given speed
	// for the ball
	public void Fire(float ballSpeed) {
		if (ballInstance == null) {

			float total = Math.Abs (gameObject.transform.position.x) + Math.Abs (gameObject.transform.position.y);
			float slX = -gameObject.transform.position.x / total;
			float slY = -gameObject.transform.position.y / total;

			ballInstance = Instantiate (ballPrefab,
				new Vector2 (gameObject.transform.position.x + slX, gameObject.transform.position.y + slY),
				Quaternion.identity);
			ballInstance.SetStartSpeed (ballSpeed);
		}
	}

	// Increases the speed of the current ball instance by the given amount
	public void IncreaseBallSpeed(float increase) {
		if (ballInstance != null) {
			ballInstance.IncreaseSpeed (increase);
		}
	}
}
