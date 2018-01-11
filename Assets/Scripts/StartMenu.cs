using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Manages the start menu in the game
public class StartMenu : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			SceneManager.LoadScene (1);
		} else if (Input.GetButtonDown ("Quit")) {
			Application.Quit ();
		} else if (Input.GetKeyDown ("t")) {
			SceneManager.LoadScene ("TestScene");
		}
	}
}
