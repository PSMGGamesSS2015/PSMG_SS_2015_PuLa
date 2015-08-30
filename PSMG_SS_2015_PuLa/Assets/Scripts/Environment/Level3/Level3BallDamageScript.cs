using UnityEngine;
using System.Collections;

public class Level3BallDamageScript : MonoBehaviour {

	// Use this for initialization
	private Transform playerRespawnPos;
	void Start () {
		playerRespawnPos = GameObject.Find ("PlayerRespawnPos").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player") {
			//Player Damage start
			Debug.Log ("Placeholder Damage Player");
			//Player Damage end
			collider.transform.position = playerRespawnPos.position;
		}
	}
}
