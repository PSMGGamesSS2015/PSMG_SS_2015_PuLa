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
	private Transform posLook;
	// Use this for initialization
	void Start () {
		play = false;
		lama = GameObject.Find ("Lama").GetComponent<Rigidbody> ();
		puma = GameObject.Find ("Puma").GetComponent<Rigidbody> ();
		cam = GameObject.Find ("Main Camera").GetComponent<SmoothThirdPersonCamera> ();
		posCamera = spotCamera.transform;
		posLama = spotLama.transform;
		posPuma = spotPuma.transform;
		posLook = transform.Find ("LookAt");

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (play) {
			doUpdate ();
		}
	}
	

	void doUpdate(){

		Vector3 moveDirection = this.transform.position - posLook.position;
		moveDirection = transform.TransformDirection (-moveDirection/20);
		puma.velocity = moveDirection;
		lama.velocity = moveDirection;
		puma.AddForce (Vector3.up * -10);
		lama.AddForce (Vector3.up * -10);
	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player" && !play) {
			collider.GetComponent<PlayerMovement>().active = false;
			play = true;
			positionForEndScene();
		}
	}

	void positionForEndScene(){
		lama.transform.position = posLama.position;
		lama.transform.LookAt(posLook);
		puma.transform.position = posPuma.position;
		puma.transform.LookAt(posLook);
		posCamera.LookAt (posLook);
		cam.target = posCamera;


	}

}
