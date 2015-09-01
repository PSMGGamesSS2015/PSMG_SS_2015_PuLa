using UnityEngine;
using System.Collections;

public class Level3BallDamageScript : MonoBehaviour {

	// Use this for initialization
	private Transform playerRespawnPos;
	private float healthDecrease = 0.206f;
	private float livesDecrease = 0.33339f;
	private UIScene3 ui3;

	void Start () {
		playerRespawnPos = GameObject.Find ("PlayerRespawnPos").transform;
		ui3 = GameObject.Find ("UI").GetComponent<UIScene3> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player") {
			if (collider.name == "Puma") {
				ui3.pumaGotDamaged(healthDecrease*5, livesDecrease);
				Destroy (this.gameObject);
			}
			collider.transform.position = playerRespawnPos.position;
		}
	}
}
