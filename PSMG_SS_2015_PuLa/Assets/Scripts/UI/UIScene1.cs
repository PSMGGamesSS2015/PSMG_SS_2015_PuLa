using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIScene1 : MonoBehaviour {

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
	public bool levelEnd = false;
	public AudioSource backgroundMusic;
	public Button unmute;
	public Button resume;
	public Button mainMenu;
	public Canvas inGameMenu;



	
	// Use this for initialization
	void Start () {
		
		pablo = GameObject.Find ("Puma").GetComponent<PlayerMovement> ();
		ludwig = GameObject.Find ("Lama").GetComponent<PlayerMovement> ();

		inGameMenu = GameObject.Find ("InGameMenu").GetComponent<Canvas>();
		inGameMenu.enabled = false;

		unmute = GameObject.Find ("Unmute").GetComponent<Button> ();
		unmute.enabled = false;
		resume = GameObject.Find ("Back").GetComponent<Button> ();
		resume.enabled = false;
		mainMenu = GameObject.Find ("MainMenu").GetComponent<Button> ();
		mainMenu.enabled = false;



		backgroundMusic = GameObject.Find ("UI").GetComponent<AudioSource> ();
		if(PlayerPrefs.GetString ("Unmute").Equals("Off")){
			backgroundMusic.enabled = false;
		}
		else{
			backgroundMusic.enabled = true;
		}

		ludwigIcon = GameObject.Find ("LudwigActiveIcon").GetComponent<Canvas> ();
		ludwigIcon.enabled = false;

		ludwigLives = ludwigIcon.transform.Find("LudwigLives").GetComponent<Image> ();
		ludwigLives.enabled = false;

		ludwigHealthBar = ludwigIcon.transform.Find("LudwigEnergyBar").GetComponent<Image> ();
		ludwigHealthBar.enabled = false;

		pabloIcon = GameObject.Find ("PabloActiveIcon").GetComponent<Canvas> ();
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
			ludwigLives.enabled = true;
			pabloIcon.enabled = false;
			pabloHealthBar.enabled = false;
			pabloLives.enabled = false;
		}	

		if (levelEnd) {
			PlayerPrefs.SetFloat("LudwigHealth", ludwigHealthBar.fillAmount);
			PlayerPrefs.SetFloat("LudwigLives", ludwigLives.fillAmount);
			PlayerPrefs.SetFloat("PabloHealth", pabloHealthBar.fillAmount);
			PlayerPrefs.SetFloat("PabloLives", pabloLives.fillAmount);
		}

		if(Input.GetKey(KeyCode.Escape)){
			unmute.enabled = true;
			resume.enabled = true;
			mainMenu.enabled = true;
			if(inGameMenu.enabled == false){
				inGameMenu.enabled = true;
				Time.timeScale = 0;
			}
			
		}

	}

	public void onUnmuteClick(){
		if (!backgroundMusic.enabled) {
			backgroundMusic.enabled = true;
		} else {
			backgroundMusic.enabled = false;
		}
	}

	public void onBackClick(){
		inGameMenu.enabled = false;
		mainMenu.enabled = false;
		unmute.enabled = false;
		resume.enabled = false;
		Time.timeScale = 1;
	}

	public void onMainMenuClick(){
		Application.LoadLevel (0);
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

	public void lamaLifeRegain(float liveRegain){

		ludwigLives.fillAmount += liveRegain;
		}

	public void pumaLifeRegain(float liveRegain){
		pabloLives.fillAmount += liveRegain;			
		}


	
}

