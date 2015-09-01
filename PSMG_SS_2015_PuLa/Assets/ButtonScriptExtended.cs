using UnityEngine;
using System.Collections;

public class ButtonScriptExtended : MonoBehaviour {

	private bool ready;
	
	public GameObject target;
	public Transform cameraPos;
	public Transform cameraLookAt;

	public float CameraLookDuration;
	
	void Start () {
		ready = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player" && ready) {
			GameObject.Find("Main Camera").GetComponent<SmoothThirdPersonCamera>().CameraEvent(cameraPos, cameraLookAt, CameraLookDuration);
			target.GetComponent<MoveScript>().activate();
			ready = false;
			
		}
	}
}
