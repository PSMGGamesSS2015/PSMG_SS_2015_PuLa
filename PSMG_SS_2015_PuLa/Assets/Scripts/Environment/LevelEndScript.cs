using UnityEngine;
using System.Collections;

public class LevelEndScript : MonoBehaviour {

	private bool play;
	private SmoothThirdPersonCamera cam;
	private Rigidbody lama;
	private Rigidbody puma;
	public GameObject spotCamera;
	public GameObject spotPuma;
	public GameObject spotLama;
	private Transform posCamera;
	private Transform posPuma;
	private Transform posLama;
	// Use this for initialization
	void Start () {
		play = false;
		lama = GameObject.Find ("Lama").GetComponent<Rigidbody> ();
		puma = GameObject.Find ("Puma").GetComponent<Rigidbody> ();
		cam = GameObject.Find ("Main Camera").GetComponent<SmoothThirdPersonCamera> ();
		posCamera = spotCamera.transform;
		posLama = spotLama.transform;
		posPuma = spotPuma.transform;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (play) {
			doUpdate ();
		}
	}

	void doUpdate(){

	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player" && !play) {
			play = true;
			positionForEndScene();
		}
	}

	void positionForEndScene(){
		lama.transform.position = posLama.position;
		puma.transform.position = posPuma.position;
		cam.transform.position = posCamera.position;

	}

}
