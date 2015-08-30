using UnityEngine;
using System.Collections;

public class ColorTileWhiteScript : MonoBehaviour {

	// Use this for initialization
	private ColorChallengeScript colorChallenge;
	void Start () {
		colorChallenge = GetComponentInParent<ColorChallengeScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Projectile") {
			colorChallenge.showPattern();
		}
	}
}
