﻿using UnityEngine;
using System.Collections;

public class PumaMovement : MonoBehaviour {

	// Use this for initialization

	private float triggerDistance;
	private UIHint climbHintText;
	private float sprintSpeed;
	private float walkingSpeed;
	private float slowSpeed;
	private const float MAX_STAMINA = 150;
	private float stamina;
	private float staminaDrain;
	private float staminaGain;
	private bool isSprintOn;
	private float rayOriginYAxisOffset = 2f;
	public bool tired;
	private Animator anim;
	private float startTime;
	private float journeyLength;
	private bool isClimbing;
	private Transform startMarker;
	private Vector3 endMarker;
	void Start () {
		triggerDistance = 3f;
		climbHintText = GameObject.Find ("ClimbHint").GetComponent<UIHint>();
		walkingSpeed = GetComponent<PlayerMovement> ().movePower;
		slowSpeed = 2;
		sprintSpeed = 25;
		stamina = 150;
		staminaDrain = 2;
		staminaGain = 0.5f;
		isSprintOn = false;
		tired = false;
		isClimbing = false;
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (GetComponent<PlayerMovement> ().active) {
			doFixedUpdate();
		}
	}


	// Update is called once per frame
	void doFixedUpdate () {
		RaycastHit hit;
		//
		Vector3 rayOrigin = transform.position;
		rayOrigin.y += rayOriginYAxisOffset;
		Ray climbRay = new Ray (rayOrigin, transform.forward);
		if (Physics.Raycast (climbRay, out hit, triggerDistance)) {
			if (hit.collider.tag == "Climbable") {
				climbHintText.showText ();
			} 
		} else {
			climbHintText.hideText ();
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			Debug.Log ("Q");
			if (climbHintText.isEnabled ()) {
				Debug.Log ("climb");
				StartCoroutine(startClimb(hit.collider));
			} else {
				anim.SetBool ("ClimbBool", false);
			}
		}
		if (Input.GetKey (KeyCode.LeftShift)) {
			if (stamina > 0 && !tired) {
				isSprintOn = true;
			} else {
				isSprintOn = false;
			}
		} else {
			isSprintOn = false;
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			if (climbHintText.isEnabled ()) {
				anim.SetBool ("ClimbBool", true);
			}
		} else {
			anim.SetBool ("ClimbBool", false);
		}
		if (Input.GetKey (KeyCode.R)) {
			anim.SetBool ("Crowling", true);
		} else {
			anim.SetBool ("Crowling", false);
		}
		if (stamina == 0) {
			tired = true;
		}
		if (stamina > 9 * MAX_STAMINA / 10) {
			tired = false;
		}
		if (tired) {
			GetComponent<PlayerMovement> ().movePower = slowSpeed;
		} else {
			GetComponent<PlayerMovement> ().movePower = walkingSpeed;
		}

		if (isClimbing) {
			doClimb ();
		} else {
			anim.SetBool ("ClimbBool", false);
		}
		
		if (isSprintOn) {
			GetComponent<PlayerMovement>().movePower = sprintSpeed;
			stamina -= staminaDrain;
		} else {
			
			if(stamina < MAX_STAMINA){
				stamina += staminaGain;
			}
		}

	}

	IEnumerator startClimb(Collider hit){
		anim.SetBool ("ClimbBool", true);
		Vector3 endOfClimb = transform.position;
		endOfClimb.y += hit.GetComponentInParent<MeshFilter>().mesh.bounds.size.y * hit.transform.lossyScale.y + transform.lossyScale.y;
		startTime = Time.time;
		journeyLength = Vector3.Distance(transform.position, endOfClimb);
		startMarker = transform;
		endMarker = endOfClimb;
//		yield return new WaitForSeconds (1);
		isClimbing = true;
		yield return new WaitForSeconds (2);
		endOfClimb += transform.forward * 2;
		isClimbing = false;
		anim.SetBool ("ClimbBool", false);
		transform.position = endOfClimb;
//		transform.position = Vector3.Lerp (transform.position, endOfClimb, 2f);
//		yield return new WaitForSeconds(2);
//		transform.position = endOfClimb;
//		anim.SetBool ("ClimbBool", false);



//		transform.position = endOfClimb;
		
	}

	void doClimb() {
		float distCovered = (Time.time - startTime) * 2f;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(startMarker.position, endMarker, fracJourney);
	}
}
