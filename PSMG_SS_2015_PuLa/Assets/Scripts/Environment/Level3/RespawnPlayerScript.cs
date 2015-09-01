using UnityEngine;
using System.Collections;

public class RespawnPlayerScript : MonoBehaviour {

	// Use this for initialization
	private Transform spawnAt;
	private float healthDecrease = 0.206f;
	private float livesDecrease = 0.33339f;
	private UIScene3 ui3;

	void Start () {
		spawnAt = transform.Find ("RespawnPositionPuma");
		ui3 = GameObject.Find ("UI").GetComponent<UIScene3> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player") {
			if (collider.name == "Puma") {
				ui3.pumaGotDamaged(healthDecrease*5, livesDecrease);

			}
			collider.transform.position = spawnAt.position;
		}
	}
}
