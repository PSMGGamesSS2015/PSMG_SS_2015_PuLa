using UnityEngine;
using System.Collections;

public class LamaCamScript : MonoBehaviour {

	/**
	 * Script which controlls the camera attached to the lama.
	 * This camera is used for the FPS mode.
	 * Currently working fine, however camera needs to move a bit more smoothly.
	 **/

	// Use this for initialization
	private Camera mainCam;
	private Camera lamaCam;
	private UIHint crosshair;
	private PlayerMovement lama;
	void Start () {
		lama = GetComponentInParent<PlayerMovement> ();
		mainCam = GameObject.Find ("Main Camera").GetComponent<Camera> ();
		lamaCam = GetComponent<Camera> ();
		crosshair = GameObject.Find ("CrossHair").GetComponent<UIHint> ();

		lamaCam.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (lama.active) {
			doUpdate();
		}
	}

	void doUpdate(){

		if(Input.GetKeyDown(KeyCode.Q)){
			switchToFirstPerson();
		}
		if (lamaCam.enabled) {
			float angle = Input.GetAxis ("Mouse Y") * 2 * -1;
			float rot = Input.GetAxis ("Mouse X") * 2;
			Vector3 angleV = new Vector3 (angle, 0, 0);
			lama.transform.Rotate (new Vector3 (0, rot, 0));
			transform.eulerAngles += angleV;
		}

	}

	void switchToFirstPerson(){
		if (mainCam.enabled) {
			mainCam.enabled = false;
			lamaCam.enabled = true;
			centerCamera();
			crosshair.showText();
		} else {
			lamaCam.enabled = false;
			mainCam.enabled = true;
			crosshair.hideText();
		}
	}

	void centerCamera(){
		Transform repositionCam = transform.parent.Find ("LookAt").transform;
		transform.LookAt (repositionCam);
	}

	public void disableCamera(){
		lamaCam.enabled = false;
		crosshair.hideText ();
	}
}
