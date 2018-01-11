using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The box limiting the area in which the game can be played
public class PlayBox : MonoBehaviour {

	// The gameplay manager of the game
	private GameplayManager manager;

	// Set gameplay manager
	void Awake() {
		manager = GameObject.FindWithTag ("GameplayManager").GetComponent<GameplayManager> ();
	}

	// When a ball exits the play box, destroy it and reduce the number of lives
	void OnTriggerExit2D(Collider2D col) {
		if (col.tag == "Ball") {
			manager.ReduceLives (1);
			Destroy (col.gameObject);
		}
	}
}
