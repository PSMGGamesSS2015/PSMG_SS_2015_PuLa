using UnityEngine;
using System.Collections;

public class PlattformTriggerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Plattform") {
			Debug.Log ("Trigger");
			collider.GetComponent<PlattformMovementScript>().movingDirection *= -1;
		}
	}
}
