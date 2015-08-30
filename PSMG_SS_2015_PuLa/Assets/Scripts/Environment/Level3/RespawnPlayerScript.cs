using UnityEngine;
using System.Collections;

public class RespawnPlayerScript : MonoBehaviour {

	// Use this for initialization
	private Transform spawnAt;
	void Start () {
		spawnAt = transform.Find ("RespawnPositionPuma");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player") {
			// Damage Player start

			// Damage Player end 
			collider.transform.position = spawnAt.position;
		}
	}
}
