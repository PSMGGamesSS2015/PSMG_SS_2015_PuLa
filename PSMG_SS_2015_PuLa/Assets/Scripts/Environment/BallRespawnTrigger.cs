using UnityEngine;
using System.Collections;

public class BallRespawnTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){
		if (collider.transform.parent.tag == "Player") {
			respawnPlayer (collider.gameObject);
		} else {
			respawnBall (collider.gameObject);
		}
	}

	void respawnBall(GameObject obj){
		Debug.Log (obj);
		Debug.Log (obj.transform.parent);
		GameObject.Find ("ChallengeBall").transform.position = transform.FindChild ("BallRespawnPosition").position;
	}

	void respawnPlayer(GameObject obj){
		obj.transform.parent.transform.position = transform.FindChild ("PlayerRespawnPosition").position;
	}
}
