using UnityEngine;
using System.Collections;

public class SpearFlyingScript : MonoBehaviour {

	private Rigidbody rBody;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Shoot(Transform target){
		rBody = GetComponent<Rigidbody> ();
		transform.LookAt (target);
		Vector3 velocity = (target.position - transform.position).normalized * 10;
		rBody.velocity = velocity;
		rBody.AddForce (Vector3.up * -10);	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Finish") {
			Destroy(this.gameObject);
		}
		if (collider.tag == "Player") {
			// Damage Player start

			// Damage Player end
			Destroy (this.gameObject);
		}
	}
}
