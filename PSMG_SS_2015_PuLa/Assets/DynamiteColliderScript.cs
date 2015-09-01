using UnityEngine;
using System.Collections;

public class DynamiteColliderScript : MonoBehaviour {

	GameItemsScript gameItems;
	GameObject dynamite;
	// Use this for initialization
	void Start () {
		gameItems = GameObject.Find ("dynamite").GetComponent<GameItemsScript> ();
		dynamite = GameObject.Find ("dynamite");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider collider){
		if (collider.name == "Lama" | collider.name == "Puma") {
			gameItems.dynamiteFound = true;
			Destroy(dynamite);
		}
	}
}
