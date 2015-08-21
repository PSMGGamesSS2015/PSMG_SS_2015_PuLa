using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameElements : MonoBehaviour {

	public Canvas ludwigIcon;
	public Canvas pabloIcon;
	private PlayerMovement pablo;
	private PlayerMovement ludwig;
	Image ludwigHealthBar;
	Image pabloHealthBar;
	Image pabloLives;
	Image ludwigLives;
	private int pabloLivesLeft = 3;
	private int ludwigLivesLeft = 3;
	private Persistence p;
	float ludwigLive;	

	// Use this for initialization
	void Start () {
		pablo = GameObject.Find ("Puma").GetComponent<PlayerMovement> ();
		ludwig = GameObject.Find ("Lama").GetComponent<PlayerMovement> ();
		p = GameObject.Find ("Persistence").GetComponent<Persistence> ();

		ludwigIcon.enabled = false;

		ludwigLives = ludwigIcon.transform.Find("LudwigLives").GetComponent<Image> ();
		ludwigLive = p.setLudwigLives ();

		Debug.Log ("lkajöldkfölasjdflksaökf" + "ludwigLivesFillAmount     " + ludwigLives.fillAmount);
		ludwigLives.enabled = false;

		ludwigHealthBar = ludwigIcon.transform.Find("LudwigEnergyBar").GetComponent<Image> ();
		ludwigHealthBar.enabled = false;

		pabloIcon.enabled = false;

		pabloHealthBar = pabloIcon.transform.Find ("PabloEnergyBar").GetComponent<Image> ();
		pabloHealthBar.enabled = false;

	
		pabloLives = pabloIcon.transform.Find("PabloLives").GetComponent<Image> ();
		pabloLives.enabled = false;
			
	}


	
	// Update is called once per frame
	void Update () {
		if (pablo.active) {
			pabloIcon.enabled = true;
			pabloLives.enabled = true;
			pabloHealthBar.enabled = true;
			ludwigIcon.enabled = false;
			ludwigHealthBar.enabled = false;
			ludwigLives.enabled = false;
		}



		if (ludwig.active) {
			ludwigIcon.enabled = true;
			ludwigHealthBar.enabled = true;
			//ludwigLives.fillAmount = p.setLudwigLives ();
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
		PlayerPrefs.SetFloat ("ludwigLivesLeft", ludwigLives.fillAmount);
		PlayerPrefs.SetFloat ("ludwigHealthBar", ludwigHealthBar.fillAmount);
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

	public float getLudwigLives(){
		return ludwigLives.fillAmount;
	}

	public float getLudwigHealth(){
		return ludwigHealthBar.fillAmount;
	}

	public float getPabloLives(){
		return pabloLives.fillAmount;
	}


	public float getPabloHealth(){
		return pabloHealthBar.fillAmount;
	}











}