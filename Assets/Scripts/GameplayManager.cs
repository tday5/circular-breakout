using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Manages the state of the game and the elements in it
public class GameplayManager : MonoBehaviour {

	// Number of chances a player has before they lose
	public int numChances;
	// Initial speed of the ball
	public float initialBallSpeed;
	// Level 1 of the speed, activated after it hits an orange or red
	public float speedLevel1;
	// Level 2 of the speed, activated the second time it hits a trigger
	public float speedLevel2;

	// The score of the game
	private int score;
	// The number of lives a player currently has
	private int lives;

	// The current speed of the ball in the game
	private float curBallSpeed;
	// Whether the ball has hit an orange brick yet
	private bool hitOrange;
	// Whether the ball has hit a red brick yet
	private bool hitRed;
	// Whether the game is over
	private bool gameOver;

	// The player in the game
	private PlayerController player;
	// The UI in the game
	private UIManager ui;

	// Set player and ui
	void Awake() {
		player = GameObject.FindWithTag ("Player").GetComponent<PlayerController> ();
		ui = GameObject.FindWithTag ("UI").GetComponent<UIManager> ();
	}

	// Set inital variables
	void Start() {
		lives = numChances;
		curBallSpeed = initialBallSpeed;
		hitOrange = false;
		hitRed = false;
		gameOver = false;

		ui.ChangeLives (lives);
		ui.ChangeScore (score);
	}

	// Update runs every frame
	void Update() {
		if (Input.GetButtonDown ("Quit")) {
			Application.Quit ();
		}
		if (gameOver) {
			if (Input.GetButtonDown ("Fire1")) {
				SceneManager.LoadScene (0);
			}
		} else {
			if (lives <= 0) {
				gameOver = true;
				ui.ShowEndGame (score, false);
			} else if (GameObject.FindWithTag ("Brick") == null) {
				gameOver = true;
				ui.ShowEndGame (score, true);
			} else {
				this.PlayerControl ();
			}
		}
	}

	// Controls for the player
	private void PlayerControl() {
		if (Input.GetButton ("Left")) {
			player.MoveLeft ();
		}
		if (Input.GetButton ("Right")) {
			player.MoveRight ();
		}
		if (Input.GetButtonDown ("Fire1")) {
			player.Fire (curBallSpeed);
		}
	}

	// Adds the given amount to score, and updates the ui to reflect that
	public void AddToScore(int amount) {
		score += amount;
		ui.ChangeScore (score);
	}

	// Reduces the lives by the given amount and updates the ui to reflect that
	public void ReduceLives(int amount) {
		lives -= amount;
		ui.ChangeLives (lives);
	}

	// If orange has not been hit yet, increases the speed of the ball appropriately
	public void HitOrange() {
		if (!hitOrange) {
			float previousSpeed = curBallSpeed;
			if (hitRed) {
				curBallSpeed = speedLevel2;
			} else {
				curBallSpeed = speedLevel1;
			}
			player.IncreaseBallSpeed (curBallSpeed - previousSpeed);
			hitOrange = true;
		}
	}

	// If red has not been hit yet, increases the speed of the ball appropriately
	public void HitRed() {
		if (!hitRed) {
			float previousSpeed = curBallSpeed;
			if (hitOrange) {
				curBallSpeed = speedLevel2;
			} else {
				curBallSpeed = speedLevel1;
			}
			player.IncreaseBallSpeed (curBallSpeed - previousSpeed);
			hitRed = true;
		}
	}
}