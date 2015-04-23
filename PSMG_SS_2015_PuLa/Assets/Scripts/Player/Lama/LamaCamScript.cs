using UnityEngine;
using System.Collections;

public class LamaCamScript : MonoBehaviour {

	// Use this for initialization
	private Camera mainCam;
	private Camera lamaCam;
	private UIHint crosshair;
	void Start () {
		mainCam = GameObject.Find ("Main Camera").GetComponent<Camera> ();
		lamaCam = GetComponent<Camera> ();
		crosshair = GameObject.Find ("CrossHair").GetComponent<UIHint> ();

		lamaCam.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponentInParent<PlayerMovement> ().active) {
			doUpdate();
		}
	}

	void doUpdate(){
		float angle = Input.GetAxis ("Mouse Y") * 50 * -1;
		Vector3 angleV = new Vector3 (angle, 0, 0);
		transform.eulerAngles += angleV;
		if(Input.GetKeyDown(KeyCode.Q)){
			switchToFirstPerson();
		}
	}

	void switchToFirstPerson(){
		if (mainCam.enabled) {
			mainCam.enabled = false;
			lamaCam.enabled = true;
			crosshair.showText();
		} else {
			lamaCam.enabled = false;
			mainCam.enabled = true;
			crosshair.hideText();
		}
	}
}
