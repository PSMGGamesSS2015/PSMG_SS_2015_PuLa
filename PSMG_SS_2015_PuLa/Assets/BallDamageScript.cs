using UnityEngine;
using System.Collections;

public class BallDamageScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider collider){
		if (collider.transform.parent.tag == "Player") {
			Debug.Log (collider);
			Debug.Log (GameObject.Find ("PlayerRespawnPosition"));
			collider.transform.parent.position = GameObject.Find ("PlayerRespawnPosition").transform.position;
			transform.parent.transform.position = GameObject.Find ("BallRespawnPosition").transform.position;
		}
	}
}
