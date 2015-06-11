﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	/**
	 * General Player Movement Script
	 * WASD Controlls to move forward, backwards and to strafe left and right
	 * Using the Mouse the Player can rotate the X axis
	 * By pressing Space the player can jump
	 * Jumping is combined with a RayCast to prevent midair jumps.
	 */

	public float movePower;
	public float jumpPower;
	public bool active;

	private float rotatePower = 8f;
	private float rotateState = 0;

	private Rigidbody rigidBody;
	private float jumpTrigger;
	private bool rotate;
	private float rotPower;

	private float oldVelocityX;
	private float oldVelocityZ;
	private bool isMidAir;

	private bool movementOption;
	public enum States{idle, walk, jump};
	private States state;
	private Camera lamaCam;

	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		jumpTrigger = 3;
		jumpPower *= 3;
		rotPower = 30;
		oldVelocityX = 0;
		oldVelocityZ = 0;
		movementOption = false;
		state = States.idle;
		lamaCam = GameObject.Find ("ShootCam").GetComponent<Camera> ();

	}


	
	// Update is called once per frame
	void FixedUpdate () {
		if (active) {
			doUpdate ();
		}
	}
	void doUpdate(){

		if(Input.GetKeyDown(KeyCode.Alpha1)){
			if(movementOption){
				movementOption = false;
			} else {
				movementOption = true;
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			movementOption = true;
		}

		//Jumping. Checks before if unit is grounded to disable mid-air jumps
			RaycastHit hit;
			Ray jumpRay = new Ray (transform.position, -transform.up);
			if (Physics.Raycast (jumpRay, out hit, jumpTrigger)) {
				isMidAir = false;
			} else {
				isMidAir = true;
			}
		if (Input.GetKey (KeyCode.Space) && !isMidAir) {
			Vector3 jump = new Vector3 (oldVelocityX, jumpPower, oldVelocityZ);
			rigidBody.velocity = jump;
			state = States.jump;
		}
			float verticalInput = Input.GetAxis ("Vertical") * movePower;
			rotateState = 0;
		if (Input.GetKey (KeyCode.A))
			rotateState = -1;
		if (Input.GetKey (KeyCode.D))
			rotateState = 1;
		if (lamaCam.enabled) {
			rotateState = 0;
		}
		if (!lamaCam.enabled) {
			transform.RotateAround (transform.position, new Vector3 (0, rotatePower * rotateState, 0), 150 * Time.deltaTime);
		}
		if (movementOption && isMidAir) {
			verticalInput = oldVelocityZ;
		}
			Vector3 moveDirection = new Vector3 (rotatePower * rotateState, rigidBody.velocity.y, verticalInput);
			
			oldVelocityZ = verticalInput;
			//Transform the vector3 to local space
			moveDirection = transform.TransformDirection (moveDirection);
			//set the velocity, so you can move
			rigidBody.velocity = moveDirection;
		if (rigidBody.velocity != new Vector3 (0, 0, 0)) {
			state = States.walk;
		}
			rigidBody.AddForce (Vector3.up * -10);
	}

	public States getState(){
		return state;
	}
}
