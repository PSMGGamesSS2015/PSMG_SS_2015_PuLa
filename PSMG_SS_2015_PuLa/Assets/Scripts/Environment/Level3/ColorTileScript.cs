using UnityEngine;
using System.Collections;

public class ColorTileScript : MonoBehaviour {

	// Use this for initialization

	public int tileID;

	private ColorChallengeScript colorChallenge;
	void Start () {
		colorChallenge = GetComponentInParent<ColorChallengeScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Projectile") {
			colorChallenge.colorTileHit(tileID);
		}
	}
}
