using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartScreenScript : MonoBehaviour {

	public Button start;
	public Button settings;
	public Button lIcon;
	public Button pIcon;
	public Button ludwigForward;
	public Button ludwigBackward;
	public Button pabloForward;
	public Button pabloBackward;
	public Canvas ludwigDescription;
	public Canvas ludwigControl;
	public Canvas pabloDescription;
	public Canvas pabloControl;
	public Button quit;
	public Canvas quitMenu;
	public Canvas settingsMenu;
	public AudioSource buttonClick;
	public AudioSource buttonHover;
	public AudioSource backgroundMusic;


	// Use this for initialization
	void Start () {
		start = start.GetComponent<Button> ();
		settings = settings.GetComponent<Button> ();
		settingsMenu = settingsMenu.GetComponent<Canvas> ();
		lIcon = lIcon.GetComponent<Button> ();
		pIcon = pIcon.GetComponent<Button> ();
		pabloForward = pabloForward.GetComponent<Button> ();
		pabloBackward = pabloBackward.GetComponent<Button> ();
		ludwigForward = ludwigForward.GetComponent<Button> ();
		ludwigBackward = ludwigBackward.GetComponent<Button> ();
		quit = quit.GetComponent<Button> ();
		quitMenu.GetComponent<Canvas> ();
		quitMenu.enabled = false;
		settingsMenu = settingsMenu.GetComponent<Canvas> ();
		settingsMenu.enabled = false;
		ludwigDescription = ludwigDescription.GetComponent<Canvas> ();
		ludwigDescription.enabled = false;
		pabloDescription = pabloDescription.GetComponent<Canvas> ();
		pabloDescription.enabled = false;
		ludwigControl = ludwigControl.GetComponent<Canvas> ();
		ludwigControl.enabled = false;
		pabloControl = pabloControl.GetComponent<Canvas> ();
		pabloControl.enabled = false;


	}

	public void startPress(){
		buttonClick.Play ();
		Application.LoadLevel (1);

	}

	public void settingsPress(){
		buttonClick.Play ();
		if (!settingsMenu.enabled) {
			buttonClick.Play ();
			settingsMenu.enabled = true;
		} else {
			buttonClick.Play ();
			settingsMenu.enabled = false;
		}
	}

	public void ludwigStartMenuPress(){
		if (!ludwigDescription.enabled) {
			buttonClick.Play ();
			ludwigDescription.enabled = true;
			}
		else {
			buttonClick.Play ();
			ludwigDescription.enabled = false;
			}

	}

	public void pabloStartMenuPress(){
		if (!pabloDescription.enabled) {
			buttonClick.Play ();
			pabloDescription.enabled = true;
		}
		else {
			buttonClick.Play ();
			pabloDescription.enabled = false;
		}
		
	}

	public void quitMenuPress(){
		if (!quitMenu.enabled) {
			buttonClick.Play ();
			quitMenu.enabled = true;
		} else {
			buttonClick.Play ();
			quitMenu.enabled = false;
		}
	}
	
	
	public void optionsYesClick(){
		buttonClick.Play ();
		Application.Quit ();
	}

	public void optionsNoClick(){
		buttonClick.Play ();
		quitMenu.enabled = false;

	}

	public void optionsUnmuteClick(){
		backgroundMusic.enabled = false;
		buttonClick.enabled = false;
		buttonHover.enabled = false;
		PlayerPrefs.SetString ("Unmute", "Off");
	}

	public void optionsMuteClick(){
		backgroundMusic.enabled = true;
		buttonClick.enabled = true;
		buttonHover.enabled = true;		
	}

	public void onPointerEnter(){
		buttonHover.Play ();
	
	}

	public void onPabloForwardClick(){
		pabloControl.enabled = true;
		pabloDescription.enabled = false;
		buttonClick.Play();
	}

	public void onPabloBackwardClick(){
		pabloControl.enabled = false;
		pabloDescription.enabled = true;
		buttonClick.Play ();

	}

	public void onLudwigForwardClick(){
		ludwigControl.enabled = true;
		ludwigDescription.enabled = false;
		buttonClick.Play();
	}
	
	public void onLudwigBackwardClick(){
		ludwigControl.enabled = false;
		ludwigDescription.enabled = true;
		buttonClick.Play ();
		
	}
	                   


}
