using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScene2 : MonoBehaviour {
	
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
	public Canvas muteIcon;
	public Canvas mainMenu;
	public Button ludwigButton;
	public Button pabloButton;
	public Button muteButton;
	public Button mainMenuButton;
	public AudioSource backgroundMusic;


	
	// Use this for initialization
	void Start () {
		
		pablo = GameObject.Find ("Puma").GetComponent<PlayerMovement> ();
		ludwig = GameObject.Find ("Lama").GetComponent<PlayerMovement> ();

		ludwigButton = GameObject.Find ("LudwigActiveIcon").GetComponent < Button >();
		pabloButton = GameObject.Find ("PabloActiveIcon").GetComponent<Button> ();
		backgroundMusic = GameObject.Find ("UI").GetComponent<AudioSource> ();
		backgroundMusic.enabled = true;

		muteButton = GameObject.Find ("Mute").GetComponent<Button> ();
		muteIcon = GameObject.Find ("Mute").GetComponent<Canvas> ();
		muteIcon.enabled = false;

		mainMenuButton = GameObject.Find ("MainMenu").GetComponent<Button> ();
		mainMenu = GameObject.Find ("MainMenu").GetComponent<Canvas> ();
		mainMenu.enabled = false;

		ludwigIcon.enabled = false;
		
		ludwigLives = ludwigIcon.transform.Find("LudwigLives").GetComponent<Image> ();
		ludwigLives.fillAmount = PlayerPrefs.GetFloat ("LudwigLives");
		ludwigLives.enabled = false;
		
		ludwigHealthBar = ludwigIcon.transform.Find("LudwigEnergyBar").GetComponent<Image> ();
		ludwigHealthBar.fillAmount = PlayerPrefs.GetFloat ("LudwigHealth");
		ludwigHealthBar.enabled = false;
		
		pabloIcon.enabled = false;
		
		pabloHealthBar = pabloIcon.transform.Find ("PabloEnergyBar").GetComponent<Image> ();
		pabloHealthBar.fillAmount = PlayerPrefs.GetFloat ("PabloHealth");
		pabloHealthBar.enabled = false;
		
		pabloLives = pabloIcon.transform.Find("PabloLives").GetComponent<Image> ();
		pabloLives.fillAmount = PlayerPrefs.GetFloat ("PabloLives");
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

	public void ludwigIconClick(){
		if (!muteIcon.enabled) {
			muteIcon.enabled = true;
		} else {
			muteIcon.enabled = false;		
		}
		if (!mainMenu.enabled) {
			mainMenu.enabled = true;
		} else {
			mainMenu.enabled = false;
		}
	}

	public void pabloIconClick(){
		if (!muteIcon.enabled) {
			muteIcon.enabled = true;
		} else {
			muteIcon.enabled = false;		
		}
		if (!mainMenu.enabled) {
			mainMenu.enabled = true;
		} else {
			mainMenu.enabled = false;
		}
	}

	public void muteButtonPress(){
		if (backgroundMusic.enabled) {

			backgroundMusic.enabled = false;
		} else {
			backgroundMusic.enabled = true;
		}
	}

	public void mainMenuButtonPress(){
		Application.LoadLevel (0);
	}
}

