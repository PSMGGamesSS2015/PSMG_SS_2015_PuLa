﻿using UnityEngine;
using System.Collections;

public class PlayerSwap : MonoBehaviour {

	private GameObject otherCharacter;
	private static bool swapIsReady;
	// Use this for initialization
	void Start () {
		swapIsReady = true;
		otherCharacter = getOtherCharacter ();
	}

	private GameObject getOtherCharacter()
	{	
		string nameOfCharacter;
		if (gameObject.name == "Puma") {
			nameOfCharacter = "Lama";
		} else {
			nameOfCharacter = "Puma";
		}
		return GameObject.Find(nameOfCharacter);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (swapIsReady) {
			if (gameObject.GetComponent<PlayerMovement> ().active) {
				if (Input.GetKeyDown (KeyCode.E)) {
					doSwap ();
				}
			}
		} else {
			swapIsReady = true;
		}
	}

	private void doSwap()
	{	
		GameObject camera = GameObject.FindGameObjectWithTag ("MainCamera");
		gameObject.GetComponent<PlayerMovement> ().active = false;	
		camera.GetComponent<SmoothThirdPersonCamera> ().target = otherCharacter.transform;
		otherCharacter.GetComponent<PlayerMovement> ().active = true;
		swapIsReady = false;
	}
}
