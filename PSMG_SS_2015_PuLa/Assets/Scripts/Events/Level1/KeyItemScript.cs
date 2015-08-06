using UnityEngine;
using System.Collections;

public class KeyItemScript : MonoBehaviour {

	// Use this for initialization
	private float rotatePower;

	void Start () {
		rotatePower = 150f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate(Vector3.up * Time.deltaTime * rotatePower);
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player") {
			Destroy(this.gameObject);
		}
	}
}
