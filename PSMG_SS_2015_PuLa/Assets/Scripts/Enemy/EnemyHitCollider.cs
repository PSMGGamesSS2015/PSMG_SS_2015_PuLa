using UnityEngine;
using System.Collections;

public class EnemyHitCollider : MonoBehaviour {

	private GameElements ui;
	private float healthDecrease = 0.206f;
	private float livesDecrease = 0.33339f;
	private bool pabloTriggerStay = false;
	private bool ludwigTriggerStay = false;

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

		if (collider.name == "Lama" | ludwigTriggerStay) {
			ui.lamaGotDamaged(healthDecrease, livesDecrease);
		}
		if (collider.name == "Puma" | pabloTriggerStay) {
			ui.pumaGotDamaged(healthDecrease, livesDecrease);

		}
	}

	void OnTriggerStay(Collider collider){
		if (collider.name == "Lama") {
			ludwigTriggerStay = true;
		}
		if (collider.name == "Puma") {
			pabloTriggerStay = true; 
			
		}
	
	
	}


}
