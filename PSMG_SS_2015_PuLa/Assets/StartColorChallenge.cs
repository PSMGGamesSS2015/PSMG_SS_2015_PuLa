using UnityEngine;
using System.Collections;

public class StartColorChallenge : MonoBehaviour {

	// Use this for initialization
	public GameObject colorChallengeGameObject;
	public float lookAtDuration;

	private Transform moveCameraTo;
	private Transform letCameraLookAt;
	private SmoothThirdPersonCamera mainCamera;

	private bool isReady = true;
	void Start () {
		mainCamera = GameObject.Find ("Main Camera").GetComponent<SmoothThirdPersonCamera> ();
		moveCameraTo = colorChallengeGameObject.transform.Find ("CameraPosition").transform;
		letCameraLookAt = colorChallengeGameObject.transform.Find ("CameraLookAtPos").transform;


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider) {
		if (isReady) {
			if (collider.tag == "Player") {
				collider.GetComponent<PlayerSwap>().doSwap();
				startChallenge ();
				isReady = false;
			} 
		}
	}

	private void startChallenge() {
		ColorChallengeScript script = colorChallengeGameObject.GetComponent<ColorChallengeScript> ();
		script.showPattern ();
		script.gameCanBePlayed = true;
		mainCamera.CameraEvent (moveCameraTo, letCameraLookAt, lookAtDuration);

	}
}
