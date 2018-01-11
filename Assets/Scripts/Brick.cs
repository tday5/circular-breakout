using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An enum of the types of bricks in the game
public enum BrickType {
	YELLOW, GREEN, ORANGE, RED
}

// Represents bricks in the game
public class Brick : MonoBehaviour {

	// The point value the brick is worth
	public int value;
	// The type of this brick
	public BrickType type;
	// The particles that are created after this brick is destroyed
	public GameObject deathParticles;

	// The gameplay manager in this game
	private GameplayManager manager;

	// Set gameplay manager
	void Awake() {
		manager = GameObject.FindWithTag ("GameplayManager").GetComponent<GameplayManager> ();
	}

	// If a ball collides with this brick, add this brick's value to score and then destroy this brick,
	// and also spawn the death particles
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Ball") {
			switch (type) {
			case BrickType.ORANGE:
				manager.HitOrange ();
				break;
			case BrickType.RED:
				manager.HitRed ();
				break;
			default:
				break;
			}
			manager.AddToScore (value);
			Instantiate (deathParticles, gameObject.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}