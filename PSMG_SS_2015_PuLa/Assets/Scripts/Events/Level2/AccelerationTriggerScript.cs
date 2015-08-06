using UnityEngine;
using System.Collections;

public class AccelerationTriggerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay (Collider collider){
		if (collider.name == "ChallengeBall") {
			Rigidbody sphere = collider.GetComponent<Rigidbody>();
			sphere.AddForce (-Vector3.right * 3);
		}
	}
}
