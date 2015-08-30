using UnityEngine;
using System.Collections;

public class RespawnChallengeBalls : MonoBehaviour {

	// Use this for initialization
	private Transform respawnPos1;
	private Transform respawnPos2;
	void Start () {
		respawnPos1 = transform.Find ("RespawnPos1");
		respawnPos2 = transform.Find ("RespawnPos2");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "SpeedUpObject") {
			if(collider.name == "ChallengeBall 1") {
				collider.transform.position = respawnPos1.position;
			} else {
				collider.transform.position = respawnPos2.position;
			}
			collider.GetComponent<Rigidbody>().velocity = new Vector3 (0, 0, 0);
		}
	}
}
