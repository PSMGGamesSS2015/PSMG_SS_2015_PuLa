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
	private int pabloLivesLeft = 3;
	private int ludwigLivesLeft = 3;


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
		if (ludwigHealthBar.fillAmount <= 0.1f) {
			ludwigLivesLeft--;
			ludwigLives.fillAmount -= livesDecrease;
			ludwigHealthBar.fillAmount = 1;
			
		}
		ludwigHealthBar.fillAmount -= damage;
		if (ludwigLivesLeft == 0) {
			ludwigHealthBar.enabled = false;
			ludwig.active = false;
		}

	}

	public void pumaGotDamaged(float damage, float livesDecrease){
		pabloHealthBar.fillAmount -= damage;
		if (pabloHealthBar.fillAmount <= 0.1f) {
			pabloLivesLeft --;
			pabloLives.fillAmount -= livesDecrease;
			pabloHealthBar.fillAmount = 1;
			
		}
		if (pabloLivesLeft == 0) {
			pabloHealthBar.enabled = false;
			pablo.active = false;
		}

	}

}