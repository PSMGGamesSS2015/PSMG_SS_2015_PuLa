using UnityEngine;
using System.Collections;

public class MovingPlatformScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player") {
			collider.transform.parent = this.transform;
		}
	}

	void OnTriggerExit(Collider collider) {
		if (collider.tag == "Player") {
			collider.transform.parent = null;
		}
	}
}
