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
	

	void Start(){
		transform.LookAt (target, target.up);
	}

	void Update()
	{	

		//transform.position = target.position + (new Vector3 (0, height, distance));

		/**
		float angle = Input.GetAxis ("Mouse Y") * 50;
		Vector3 angleV = new Vector3 (angle, 0, 0);
		transform.eulerAngles += angleV;
		/**
		behindTarget = target.position - (target.forward * distance);

		transform.position = Vector3.Lerp (transform.position, behindTarget, Time.deltaTime * damping);
		Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
		Quaternion test = Quaternion.LookRotation (angleV, Vector3.up);
		wantedRotation += test;
		transform.rotation = Quaternion.Lerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);

	
**/	
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

		/**
		rotate = Input.GetMouseButton (0);
		if(rotate){
			float verticalInput = Input.GetAxis ("Mouse X") * mouseSpeed;
			float horizontalInput = Input.GetAxis ("Mouse Y") * mouseSpeed;
			transform.RotateAround(target.position, new Vector3(horizontalInput, verticalInput, 0), mouseSpeed * Time.deltaTime);
		}
		**/
	}
	
}
