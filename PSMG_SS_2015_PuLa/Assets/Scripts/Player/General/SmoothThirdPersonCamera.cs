using UnityEngine;
using System.Collections;

public class SmoothThirdPersonCamera : MonoBehaviour {
	
	public Transform target;
	public Transform pointTo;
	public float distance = 5.0f;
	public float height = 3.0f;
	public float damping = 5.0f;
	public bool smoothRotation = true;
	public bool followBehind = true;
	public float rotationDamping = 10.0f;
	private Vector3 behindTarget;
	private bool active;

	//Camera Collision
	private bool isColliding;
	private float distanceChangeOffset = 0.15f;


	//public float distance = 5.0f;
	public float xSpeed = 5f;
	public float ySpeed = 5f;
	
	public float yMinLimit = -20f;
	public float yMaxLimit = 80f;
	
	public float distanceMin = .5f;
	public float distanceMax = 15f;
	
	public float smoothTime = 2f;
	
	float rotationYAxis = 0.0f;
	float rotationXAxis = 0.0f;
	
	float velocityX = 0.0f;
	float velocityY = 0.0f;

	Camera thisCam;

	void Start(){
		active = true;
		pointTo = target.transform.Find ("PointTo");
		isColliding = false;
		focusOnTarget ();
		thisCam = gameObject.GetComponent<Camera> ();

		
		Vector3 angles = transform.eulerAngles;
		rotationYAxis = angles.y;
		rotationXAxis = angles.x;

	}

	void FixedUpdate(){
		if(active){
			doUpdate1();
		}
	}

	void doUpdate1(){
		//transform.RotateAround (target.position, target.up, Input.GetAxis ("Mouse X"));

		if (Input.GetMouseButton (1)) {
			velocityX += xSpeed * Input.GetAxis ("Mouse X") * distance * 0.004f;
			velocityY += ySpeed * Input.GetAxis ("Mouse Y") * 0.004f;
		
			rotationYAxis += velocityX;
			rotationXAxis -= velocityY;
		
			rotationXAxis = ClampAngle (rotationXAxis, yMinLimit, yMaxLimit);
		
			Quaternion fromRotation = Quaternion.Euler (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
			Quaternion toRotation = Quaternion.Euler (rotationXAxis, rotationYAxis, 0);
			Quaternion rotation = toRotation;

			distance = Mathf.Clamp (distance - Input.GetAxis ("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
		
			RaycastHit hit;
			if (Physics.Linecast (target.position, transform.position, out hit)) {
				distance -= hit.distance;
			}
			Vector3 negDistance = new Vector3 (0.0f, 0.0f, -distance);
			Vector3 position = rotation * negDistance + target.position;
		
			transform.rotation = rotation;
			transform.position = position;
		
			velocityX = Mathf.Lerp (velocityX, 0, Time.deltaTime * smoothTime);
			velocityY = Mathf.Lerp (velocityY, 0, Time.deltaTime * smoothTime);
		} else {
			doUpdate();
		}

		/**
		Vector3 wantedPosition;
		wantedPosition = target.TransformPoint (0, height, distance);
		transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);
		**/
	}

	void focusOnTarget(){
		transform.position = target.TransformPoint (0, height, -distance);
	}

	void doUpdate()
	{	
		Vector3 wantedPosition;
		if (followBehind) {
			wantedPosition = target.TransformPoint (0, height, -distance);
		} else {
			wantedPosition = target.TransformPoint (0, height, distance);
		}
			transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

		if (smoothRotation)
		{	
			Vector3 target1 = target.position;
			// Since puma is a little bit shorter we have to adjust the camera a bit so the player can see more of the level
			if(target.name == "Puma"){
				target1 += new Vector3(0, 1, 0);
			} 
			if(target.name == "Lama"){
				target1 += new Vector3(0, 2, 0);
			}
			Quaternion wantedRotation = Quaternion.LookRotation(target1 - transform.position, target.up);
			//wantedRotation.eulerAngles = transform.eulerAngles;
			transform.rotation = Quaternion.Lerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
		}
		else transform.LookAt(target, target.up);
		distance = Mathf.Clamp (distance - Input.GetAxis ("Mouse ScrollWheel") * 5, distanceMin, distanceMax);


			// Changing distance of camera 
			if (isColliding) {
				distance -= distanceChangeOffset;
			} else {

			}
		if(thisCam.enabled) {
			// Camerac Collision Detection using Raycast
			if (CheckCollisionWithScreenCorners ()) {
				isColliding = true;
			} else {
				isColliding = false;
			}
		}
	}

	public void CameraEvent(GameObject obj, float waitDuration){
		active = false;
		target.GetComponent<PlayerMovement> ().active = false;
		transform.position = (obj.transform.position - obj.transform.forward * 25);
		Vector3 temp = transform.position;
		temp.y += 5;
		transform.position = temp;
		transform.LookAt (obj.transform);
		StartCoroutine(Wait(waitDuration));
		showMainCam ();
	
	}

	IEnumerator Wait(float duration){
		yield return new WaitForSeconds (duration);
		active = true;
		target.GetComponent<PlayerMovement> ().active = true;
	}

	public void showMainCam(){
		LamaCamScript lamaCam = GameObject.Find ("ShootCam").GetComponent<LamaCamScript> ();
		GetComponent<Camera> ().enabled = true;
		lamaCam.disableCamera ();
	} 

	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}

	void OnTriggerEnter(Collider collider) {
		isColliding = true;
	}

	void OnTriggerExit(Collider collider) {
		isColliding = false;
	}

	private bool CheckCollisionWithScreenCorners() {
		RaycastHit hit;
		float distanceFromCameraPointToPlayer;
		Vector3 cameraCorner;
//		Debug.DrawLine (Camera.main.ScreenToWorldPoint (new Vector3 (0, 0, Camera.main.nearClipPlane)), pointTo.position);
		cameraCorner = Camera.main.ScreenToWorldPoint (new Vector3 (0, 0, Camera.main.nearClipPlane));
		Ray checkForWallsRay = new Ray (cameraCorner, (pointTo.position - cameraCorner).normalized);
		Debug.DrawRay (checkForWallsRay.origin, checkForWallsRay.direction);
		Debug.Log (checkForWallsRay.origin + ", " + pointTo.position);
		distanceFromCameraPointToPlayer = distanceBetweenTwoVectors (cameraCorner, pointTo.position);
		if (Physics.Raycast (checkForWallsRay, out hit, Vector3.Distance(cameraCorner, pointTo.position))) {
			Debug.Log (hit.collider.name);
			if(hit.collider.tag != "Player" && hit.collider.name != "Terrain"){
	
				return true;
			}
		}
		cameraCorner = Camera.main.ScreenToWorldPoint (new Vector3 (Camera.main.pixelWidth, 0, Camera.main.nearClipPlane));
		checkForWallsRay = new Ray (cameraCorner, (pointTo.position - cameraCorner).normalized);		
		distanceFromCameraPointToPlayer = distanceBetweenTwoVectors (checkForWallsRay.origin, pointTo.position);
		if (Physics.Raycast (checkForWallsRay, out hit, Vector3.Distance(cameraCorner, pointTo.position))) {
			if(hit.collider.tag != "Player" && hit.collider.name != "Terrain"){
				Debug.Log (hit.collider.tag);
				return true;
			}		
		}
		cameraCorner = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, Camera.main.nearClipPlane));
		checkForWallsRay = new Ray (cameraCorner, (pointTo.position - cameraCorner).normalized);		
		distanceFromCameraPointToPlayer = distanceBetweenTwoVectors (checkForWallsRay.origin, pointTo.position);
		if (Physics.Raycast (checkForWallsRay, out hit, Vector3.Distance(cameraCorner, pointTo.position))) {
			if(hit.collider.tag != "Player" && hit.collider.name != "Terrain"){
				Debug.Log (hit.collider.tag);
				return true;
			}		
		}
		cameraCorner = Camera.main.ScreenToWorldPoint (new Vector3 (Camera.main.pixelWidth, Camera.main.pixelHeight, Camera.main.nearClipPlane));
		checkForWallsRay = new Ray (cameraCorner, (pointTo.position - cameraCorner).normalized);
		distanceFromCameraPointToPlayer = distanceBetweenTwoVectors (checkForWallsRay.origin, pointTo.position);
		if (Physics.Raycast (checkForWallsRay, out hit, Vector3.Distance(cameraCorner, pointTo.position))) {
			if(hit.collider.tag != "Player" && hit.collider.name != "Terrain"){
				Debug.Log (hit.collider.tag);
				return true;
			}
		}
		return false;
	}

	private float distanceBetweenTwoVectors(Vector3 from, Vector3 to) {
		return Mathf.Sqrt (Mathf.Pow ((from.x - to.x), 2) + Mathf.Pow ((from.y - to.y), 2) + Mathf.Pow ((from.z - to.z), 2));
	}
}
