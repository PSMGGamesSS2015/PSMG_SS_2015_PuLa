using UnityEngine;
using System.Collections;

public class LamaShootScript : MonoBehaviour {



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<PlayerMovement> ().active) {
			doUpdate ();
		}
	}

	void doUpdate(){
		if(Input.GetKeyDown(KeyCode.Mouse0) && GetComponentInChildren<Camera>().enabled){
			Debug.Log ("Test");
		}
	}
}
