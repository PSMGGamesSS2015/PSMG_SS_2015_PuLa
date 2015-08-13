using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameElements : MonoBehaviour {

	public Canvas ludwigIcon;
	public Canvas pabloIcon;
	private PlayerMovement pablo;
	private PlayerMovement ludwig;
	public Image ludwigHealthBar;
	public Image pabloHealthBar;
	public Image pabloLives;
	public Image ludwigLives;


	// Use this for initialization
	void Start () {
		
		pablo = GameObject.Find ("Puma").GetComponent<PlayerMovement> ();
		ludwig = GameObject.Find ("Lama").GetComponent<PlayerMovement> ();

		ludwigIcon = ludwigIcon.GetComponent<Canvas> ();
		ludwigIcon.enabled = false;

		ludwigLives = ludwigLives.GetComponent<Image> ();
		ludwigLives.enabled = false;

		ludwigHealthBar = ludwigHealthBar.GetComponent<Image> ();
		ludwigHealthBar.enabled = false;

		pabloHealthBar = pabloHealthBar.GetComponent<Image> ();
		pabloHealthBar.enabled = false;

		pabloIcon = pabloIcon.GetComponent<Canvas> ();
		pabloIcon.enabled = false;

		pabloLives = pabloLives.GetComponent<Image> ();
		pabloLives.enabled = false;

	
	



	}

	void OnGUI() {
	}
	
	// Update is called once per frame
	void Update () {
		if (pablo.active) {
			pabloIcon.enabled = true;
			pabloHealthBar.enabled = true;
			pabloLives.enabled = true;
			ludwigIcon.enabled = false;
			ludwigHealthBar.enabled = false;
			ludwigLives.enabled = false;
		}



		if (ludwig.active) {
			ludwigIcon.enabled = true;
			ludwigHealthBar.enabled = true;
			ludwigLives.enabled = true;
			pabloIcon.enabled = false;
			pabloHealthBar.enabled = false;
			pabloLives.enabled = false;
		}	
	}

	public void lamaGotDamaged(float damage, float livesDecrease) {
		if (ludwigHealthBar.fillAmount <= 0.09f) {
			ludwigLives.fillAmount = ludwigLives.fillAmount+1/livesDecrease;
			ludwigHealthBar.fillAmount = 1;
			
		}
		ludwigHealthBar.fillAmount -= damage;
	}

	public void pumaGotDamaged(float damage, float livesDecrease){
		pabloHealthBar.fillAmount -= damage;
		if (pabloHealthBar.fillAmount <= 0.09f) {
			pabloLives.fillAmount = pabloLives.fillAmount+1/livesDecrease;
			pabloHealthBar.fillAmount = 1;
			
		}
	}

}