using UnityEngine;
using System.Collections;

public class PlayerSwap : MonoBehaviour {

	/**
	 * Key Script for the Game. 
	 * By pressing E the player can swap between the two playable characters
	 **/

	private GameObject otherCharacter;
	private static bool swapIsReady;
	// Use this for initialization
	void Start () {
		swapIsReady = true;
		otherCharacter = getOtherCharacter ();
	}

	private GameObject getOtherCharacter()
	{	
		string nameOfCharacter;
		if (gameObject.name == "Puma") {
			nameOfCharacter = "Lama";
		} else {
			nameOfCharacter = "Puma";
		}
		return GameObject.Find(nameOfCharacter);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (swapIsReady) {
			if (gameObject.GetComponent<PlayerMovement> ().active) {
				if (Input.GetKeyDown (KeyCode.Tab)) {
					doSwap ();
				}
			}
		} 
	}

	public void doSwap()
	{	
		Debug.Log ("Swapping to " + otherCharacter.name);
		GameObject camera = GameObject.FindGameObjectWithTag ("MainCamera");
		gameObject.GetComponent<PlayerMovement> ().active = false;	
		camera.GetComponent<SmoothThirdPersonCamera> ().target = otherCharacter.transform;
		camera.GetComponent<SmoothThirdPersonCamera> ().pointTo = otherCharacter.transform.Find ("PointTo");
		otherCharacter.GetComponent<PlayerMovement> ().active = true;
		swapIsReady = false;
		camera.GetComponent<SmoothThirdPersonCamera> ().showMainCam ();
		StartCoroutine (cooldown ());
	}

	private IEnumerator cooldown(){

		yield return new WaitForSeconds(1f);
		swapIsReady = true;
	}
}
