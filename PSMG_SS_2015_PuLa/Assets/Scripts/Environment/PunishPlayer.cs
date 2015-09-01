using UnityEngine;
using System.Collections;

public class PunishPlayer : MonoBehaviour {
	private UIScene1 ui1;
	private UIScene2 ui2;
	private float healthDecrease = 0.206f;
	private float livesDecrease = 0.33339f;

	// Use this for initialization
	public GameObject sendBackTo;
	void Start () {
		ui1 = GameObject.Find ("UI").GetComponent<UIScene1> ();
		ui2 = GameObject.Find ("UI").GetComponent<UIScene2> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player") {
			collider.gameObject.transform.position = sendBackTo.transform.position;
		}

		if (collider.name == "Puma") {
				ui2.pumaGotDamaged(healthDecrease*5, livesDecrease);

		}
	}
}
