using UnityEngine;
using System.Collections;

public class BallRespawnTrigger : MonoBehaviour {

	float waitDuration;

	private float healthDecrease = 0.206f;
	private float livesDecrease = 0.33339f;
	private UIScene2 ui2;

	// Use this for initialization
	void Start () {
		waitDuration = 2f;
		ui2 = GameObject.Find ("UI").GetComponent<UIScene2> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player") {
			ui2.pumaGotDamaged(healthDecrease*5, livesDecrease);
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
