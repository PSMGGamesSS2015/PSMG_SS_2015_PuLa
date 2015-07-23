using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartScreenScript : MonoBehaviour {

	public Button start;
	public Button settings;
	public Button lIcon;
	public Button pIcon;

	// Use this for initialization
	void Start () {
		start = start.GetComponent<Button> ();
		settings = settings.GetComponent<Button> ();
		lIcon = lIcon.GetComponent<Button> ();
		pIcon = pIcon.GetComponent<Button> ();
	}

	public void startPress(){
		Application.LoadLevel (1);

	}
	public void settingsPress(){
	}

	public void ludwigStartMenuPress(){
	}

	public void pabloStartMenuPress(){
	}
}
