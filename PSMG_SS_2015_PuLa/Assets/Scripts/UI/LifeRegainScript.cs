﻿using UnityEngine;
using System.Collections;

public class LifeRegainScript : MonoBehaviour {

	private UIScene1 ui1;
	private UIScene2 ui2;
	private GameObject heart;
	private float livesFillAmount = 0.35f;




	// Use this for initialization
	void Start () {
		ui1 = GameObject.Find ("UI").GetComponent<UIScene1> ();
		ui2 = GameObject.Find ("UI").GetComponent<UIScene2> ();
		heart = GameObject.Find ("heart");

	}

	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){
		if (collider.name == "Lama") {

			if (Application.loadedLevel == 1) {
			
				ui1.lamaLifeRegain (livesFillAmount);
			}
			if (Application.loadedLevel == 2) {
				
				ui2.lamaLifeRegain (livesFillAmount);
			}
			Destroy(heart);
		}

		if (collider.name == "Puma") {
			if (Application.loadedLevel == 1) {
				ui1.pumaLifeRegain (livesFillAmount);
			}
			if (Application.loadedLevel == 2) {
				ui2.pumaLifeRegain (livesFillAmount);
			}
			Destroy(heart);
		}

	}
}