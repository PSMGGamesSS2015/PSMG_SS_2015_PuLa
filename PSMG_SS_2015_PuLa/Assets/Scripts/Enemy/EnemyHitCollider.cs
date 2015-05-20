using UnityEngine;
using System.Collections;

public class EnemyHitCollider : MonoBehaviour {

	// Use this for initialization


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Projectile") {
			transform.parent.GetComponent<EnemyUnitMovement>().destroy();
			collider.GetComponent<BulletScript>().destroy();
		}
	}
}
