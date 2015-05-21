using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	private Vector3 target;
	private Rigidbody rBody;
	// Use this for initialization
	
	void Start () {
	}


	public void shoot(Vector3 target){
		rBody = GetComponent<Rigidbody> ();
		this.target = target;
		target = (target - transform.position).normalized * 50;
		rBody.velocity = target;
		rBody.AddForce (Vector3.up * -10);
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag != "Enemy") {
			Destroy (this.gameObject);
		}
	}

	public void destroy(){
		Destroy (this.gameObject);
	}

}
