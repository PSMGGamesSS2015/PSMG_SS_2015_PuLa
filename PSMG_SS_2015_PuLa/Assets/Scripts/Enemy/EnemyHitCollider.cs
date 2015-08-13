using UnityEngine;
using System.Collections;

public class EnemyHitCollider : MonoBehaviour {

	private GameElements ui;
	private float healthDecrease = 0.1f;
	private float livesDecrease = 3f;

	// Use this for initialization


	void Start () {
		ui = GameObject.Find ("UI").GetComponent<GameElements> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Projectile") {
			transform.parent.GetComponent<EnemyUnitMovement>().destroy();
			collider.GetComponent<BulletScript>().destroy();
		}

		if (collider.name == "Lama") {
			ui.lamaGotDamaged(healthDecrease, livesDecrease);
		}
		if (collider.name == "Puma") {
			ui.pumaGotDamaged(healthDecrease, livesDecrease);

		}
	}
}
