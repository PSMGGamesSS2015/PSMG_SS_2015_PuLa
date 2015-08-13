using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {


	private	float liveDecrease = -3f;
	private float healthDecrease = 0.2f;
	private float currentHealth = 1f;
	private GameElements ui;


	// Use this for initialization
	void Start () {
		ui = GameObject.Find ("UI").GetComponent<GameElements> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	/*void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Enemy" && !collider.isTrigger) {
			if ( gameObject.name == "Lama") {
				Debug.Log (gameObject.name + " got Damaged");
				ui.lamaGotDamaged(healthDecrease);
				if (ui.ludwigHealthBar.fillAmount <= 0.09f) {
					ui.ludwigLives.fillAmount = ui.ludwigLives.fillAmount+1/liveDecrease;
					ui.ludwigHealthBar.fillAmount = 1;
					
				}

			} else {
				ui.pabloHealthBar.fillAmount = ui.pabloHealthBar.fillAmount-healthDecrease;
				if (ui.pabloHealthBar.fillAmount <= 0.09f) {
					ui.pabloLives.fillAmount = ui.pabloLives.fillAmount+1/liveDecrease;
					ui.pabloHealthBar.fillAmount = 1;
					
				}
			}
		}
	}*/


	

}
