using UnityEngine;
using System.Collections;

public class AccelerationTriggerScript : MonoBehaviour {

	// Use this for initialization
	public int direction;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay (Collider collider){
		if (collider.tag == "SpeedUpObject") {
			Rigidbody sphere = collider.GetComponent<Rigidbody>();
			sphere.AddForce ( direction * Vector3.right * 3);
		}
	}
}
