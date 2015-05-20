using UnityEngine;
using System.Collections;

public class SmoothThirdPersonCamera : MonoBehaviour {
	
	public Transform target;
	public float distance = 3.0f;
	public float height = 3.0f;
	public float damping = 5.0f;
	public bool smoothRotation = true;
	public bool followBehind = true;
	public float rotationDamping = 10.0f;
	private Vector3 behindTarget;
	private bool active;
	

	void Start(){
		active = true;
		transform.LookAt (target, target.up);
	}

	void Update(){
		if(active){
			doUpdate();
		}
	}

	void doUpdate()
	{	
		Vector3 wantedPosition;
		if (followBehind)
			wantedPosition = target.TransformPoint(0, height, -distance);
		else
			wantedPosition = target.TransformPoint(0, height, distance);
		
			transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

		if (smoothRotation)
		{
			Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
			//wantedRotation.eulerAngles = transform.eulerAngles;
			transform.rotation = Quaternion.Lerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
		}
		else transform.LookAt(target, target.up);
	}

	public void CameraEvent(GameObject obj){
		active = false;
		transform.position = (obj.transform.position - obj.transform.forward * 25);
		Vector3 temp = transform.position;
		temp.y += 5;
		transform.position = temp;
		transform.LookAt (obj.transform);
		StartCoroutine(Wait(5));
		showMainCam ();
	
	}

	IEnumerator Wait(float duration){
		yield return new WaitForSeconds (duration);
		active = true;
	}

	public void showMainCam(){
		LamaCamScript lamaCam = GameObject.Find ("ShootCam").GetComponent<LamaCamScript> ();
		GetComponent<Camera> ().enabled = true;
		lamaCam.disableCamera ();
	}


	
}
