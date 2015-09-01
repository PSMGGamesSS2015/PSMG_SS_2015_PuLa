using UnityEngine;
using System.Collections;

public class SpearFlyingScript : MonoBehaviour {

	private Rigidbody rBody;
	private UIScene3 ui3;
	private float healthDecrease = 0.206f;
	private float livesDecrease = 0.33339f;
	// Use this for initialization
	void Start () {
		ui3 = GameObject.Find ("UI").GetComponent<UIScene3> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Shoot(Transform target){
		rBody = GetComponent<Rigidbody> ();
		transform.LookAt (target);
		Vector3 velocity = (target.position - transform.position).normalized * 10;
		rBody.velocity = velocity;
		rBody.AddForce (Vector3.up * -10);	
	}

	public void ShootWithSpeed(Vector3 target, float speed){
		rBody = GetComponent<Rigidbody> ();
		transform.LookAt (target);
		Vector3 velocity = (target - transform.position).normalized * speed;
		rBody.velocity = velocity;
		rBody.AddForce (Vector3.up * -10);	
	}

	void OnTriggerEnter(Collider collider) {

		if (collider.name == "Puma") {
			ui3.pumaGotDamaged(healthDecrease*2, livesDecrease);
			Destroy (this.gameObject);
		}
		if (collider.name == "Lama") {
			ui3.lamaGotDamaged(healthDecrease*2, livesDecrease);
			Destroy (this.gameObject);
		}
		if (collider.tag == "Plattform") {
			Destroy (this.gameObject);
		}
	}
}
