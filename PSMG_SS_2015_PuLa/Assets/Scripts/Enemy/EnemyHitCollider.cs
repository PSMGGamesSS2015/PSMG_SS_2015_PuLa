using UnityEngine;
using System.Collections;

public class EnemyHitCollider : MonoBehaviour {

	private UIScene1 ui1;
	private UIScene2 ui2;
	private UIScene3 ui3;
	private float healthDecrease = 0.206f;
	private float livesDecrease = 0.33339f;
	private bool pabloTriggerStay = false;
	private bool ludwigTriggerStay = false;
	private Animator anim;

	// Use this for initialization


	void Start () {
		anim = GetComponent<Animator> ();
		ui1 = GameObject.Find ("UI").GetComponent<UIScene1> ();
		ui2 = GameObject.Find ("UI").GetComponent<UIScene2> ();
		ui3 = GameObject.Find ("UI").GetComponent<UIScene3> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Projectile") {

			//transform.parent.GetComponent<EnemyUnitMovement>().getHit();
			transform.parent.GetComponent<EnemyUnitMovement>().destroy();
			collider.GetComponent<BulletScript>().destroy();
		}

		if (collider.name == "Lama" | ludwigTriggerStay) {
			if(Application.loadedLevel ==1){

				ui1.lamaGotDamaged(healthDecrease, livesDecrease);
				}
			if(Application.loadedLevel ==2){

				ui2.lamaGotDamaged(healthDecrease, livesDecrease);
				}
			if(Application.loadedLevel ==3){
				
				ui3.lamaGotDamaged(healthDecrease, livesDecrease);
			}
		}
		if (collider.name == "Puma" | pabloTriggerStay) {
			if(Application.loadedLevel ==1){
			ui1.pumaGotDamaged(healthDecrease,livesDecrease);
			}
			if(Application.loadedLevel == 2){

			ui2.pumaGotDamaged(healthDecrease, livesDecrease);
			}
			if(Application.loadedLevel == 3){
				
				ui3.pumaGotDamaged(healthDecrease, livesDecrease);
			}
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
