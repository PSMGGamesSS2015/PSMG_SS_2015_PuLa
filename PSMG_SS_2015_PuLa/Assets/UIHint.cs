using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIHint : MonoBehaviour {

	private bool show;
	private Text text;
	// Use this for initialization
	void Start () {
		show = false;
		text = gameObject.GetComponent<Text> ();
		text.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (show) {
			text.enabled = true;
		} else {
			text.enabled = false;
		}
		
	}
	
	public void showText(){
		show = true;
	}
	
	public void hideText(){
		show = false;
	}
	public bool isEnabled(){
		return show;
	}
}
