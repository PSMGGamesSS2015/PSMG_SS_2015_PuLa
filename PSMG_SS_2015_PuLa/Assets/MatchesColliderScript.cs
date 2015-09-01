using UnityEngine;
using System.Collections;

public class MatchesColliderScript : MonoBehaviour {

	GameItemsScript gameItems;
	GameObject matches;
	// Use this for initialization
	void Start () {
		gameItems = GameObject.Find ("Matches").GetComponent<GameItemsScript> ();
		matches = GameObject.Find ("Matches");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider collider){
		if (collider.name == "Lama" | collider.name == "Puma") {
			gameItems.matchesFound = true;
			Destroy(matches);
		}
	}
}
