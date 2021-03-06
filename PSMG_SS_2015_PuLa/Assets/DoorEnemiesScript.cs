﻿using UnityEngine;
using System.Collections;

public class DoorEnemiesScript : MonoBehaviour {

	// Use this for initialization
	public GameObject door1;
	public GameObject door2;
	public Transform lookFrom;
	public Transform lookTo;

	public GameObject[] enemies;

	private bool isReady = true;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (isReady) {
			if (collider.tag == "Player") {
				door1.GetComponent<MoveScript> ().activate ();
				door2.GetComponent<MoveScript> ().activate ();
				GameObject.Find ("Main Camera").GetComponent<SmoothThirdPersonCamera> ().CameraEvent (lookFrom, lookTo, 2);
				collider.gameObject.GetComponent<PlayerSwap> ().doSwap ();
				isReady = false;
				activateEnemies();
			}
		}
	}

	private void activateEnemies() {
		foreach (GameObject enemy in enemies) {
			enemy.GetComponent<Level3EnemyMovementScript>().activate();
		}
	}
}
