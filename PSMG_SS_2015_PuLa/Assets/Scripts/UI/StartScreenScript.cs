using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartScreenScript : MonoBehaviour {

	public Button start;
	public Button settings;
	public Button lIcon;
	public Button pIcon;
	public Canvas ludwigDescription;
	public Canvas pabloDescription;
	public Button quit;
	public Canvas quitMenu;


	// Use this for initialization
	void Start () {
		start = start.GetComponent<Button> ();
		settings = settings.GetComponent<Button> ();
		lIcon = lIcon.GetComponent<Button> ();
		pIcon = pIcon.GetComponent<Button> ();
		quit = quit.GetComponent<Button> ();
		quitMenu.GetComponent<Canvas> ();
		quitMenu.enabled = false;
		ludwigDescription = ludwigDescription.GetComponent<Canvas> ();
		ludwigDescription.enabled = false;
		pabloDescription = pabloDescription.GetComponent<Canvas> ();
		pabloDescription.enabled = false;


	}

	public void startPress(){
		Application.LoadLevel (1);

	}

	public void settingsPress(){

	}

	public void ludwigStartMenuPress(){
		if (!ludwigDescription.enabled) {
			ludwigDescription.enabled = true;
			}
		else {
			ludwigDescription.enabled = false;
			}

	}

	public void pabloStartMenuPress(){
		if (!pabloDescription.enabled) {
			pabloDescription.enabled = true;
		}
		else {
			pabloDescription.enabled = false;
		}
		
	}

	public void quitMenuPress(){
		if (!quitMenu.enabled) {
			quitMenu.enabled = true;
		} else {
			quitMenu.enabled = false;
		}
	}
	
	
	public void optionsYesClick(){
		Application.Quit ();
	}

	public void optionsNoClick(){
		quitMenu.enabled = false;

	}



}
