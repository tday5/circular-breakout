using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour {

	public float lifetime;
	private float timer;

	// Use this for initialization
	void Start () {
		timer = lifetime;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer <= 0) {
			Destroy (gameObject);
		} else {
			timer -= Time.deltaTime;
		}
	}
}
