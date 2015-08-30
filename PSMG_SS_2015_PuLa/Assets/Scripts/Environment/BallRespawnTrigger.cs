using UnityEngine;
using System.Collections;

public class BallRespawnTrigger : MonoBehaviour {

	float waitDuration;



	// Use this for initialization
	void Start () {
		waitDuration = 2f;

	
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
		StartCoroutine(Wait(waitDuration));
	}

	void respawnPlayer(GameObject obj){

		obj.transform.parent.transform.position = transform.FindChild ("PlayerRespawnPosition").position;
	}

	IEnumerator Wait (float duration){
		yield return new WaitForSeconds(duration);
		GameObject.Find ("ChallengeBall").transform.position = transform.FindChild ("BallRespawnPosition").position;

	}
	
}
