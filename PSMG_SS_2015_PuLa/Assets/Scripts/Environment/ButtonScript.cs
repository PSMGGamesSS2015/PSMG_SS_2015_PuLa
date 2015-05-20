using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	private bool ready;

	public GameObject target;

	void Start () {
		ready = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player" && ready) {
			GameObject.Find("Main Camera").GetComponent<SmoothThirdPersonCamera>().CameraEvent(target);
			target.GetComponent<MoveScript>().activate();
			ready = false;

		}
	}
}
