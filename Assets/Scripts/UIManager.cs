using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Manages the UI in the game
public class UIManager : MonoBehaviour {

	// The text that shows score
	public Text score;
	// The text that shows lives
	public Text lives;
	// The text that shows up at the end of the game
	public Text endGame;

	// Initialize variables
	void Start() {
		endGame.enabled = false;
	}

	// Changes the score to the given amount
	public void ChangeScore(int amount) {
		score.text = "Score: " + amount;
	}

	// Changes the lives to the given amount
	public void ChangeLives(int amount) {
		lives.text = "Lives: " + amount;
	}

	// Tells the end game to display, using the given amount and whether or not the game was won
	public void ShowEndGame(int amount, bool won) {
		if (won) {
			endGame.text = "You Won!\nScore: " + amount;
		} else {
			endGame.text = "Game Over!\nScore: " + amount;
		}
		endGame.enabled = true;
	}
}