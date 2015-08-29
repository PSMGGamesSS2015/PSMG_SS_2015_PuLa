using UnityEngine;
using System.Collections;

public class PunishPlayer : MonoBehaviour {


	// Use this for initialization
	public GameObject sendBackTo;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player") {
			collider.gameObject.transform.position = sendBackTo.transform.position;
		}
	}
}
