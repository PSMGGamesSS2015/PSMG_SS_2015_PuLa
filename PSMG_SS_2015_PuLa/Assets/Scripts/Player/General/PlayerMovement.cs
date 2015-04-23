using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization

	public float movePower;
	public float jumpPower;
	public bool active;

	private Rigidbody rigidBody;
	private float jumpTrigger;
	private bool rotate;
	private float rotPower;

	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		jumpTrigger = 3;
		jumpPower *= 3;
		rotPower = 20;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (active) {
			doUpdate ();
		}
	}
	void doUpdate(){
		//Jumping. Checks before if on ground to disable mid-air jumps
		if(Input.GetKeyDown(KeyCode.Space)){
			RaycastHit hit;
			Ray jumpRay = new Ray (transform.position, -transform.up);
			if(Physics.Raycast (jumpRay, out hit, jumpTrigger)){
				Vector3 jump = new Vector3(0, jumpPower, 0);
				rigidBody.velocity = jump;
				rigidBody.AddForce ( Vector3.up * 10);
			}
		}

			float horizontalRot = Input.GetAxis ("Mouse X") * rotPower;
			transform.RotateAround(transform.position, new Vector3(0, horizontalRot, 0), 150*Time.deltaTime);
		float verticalInput = Input.GetAxis ("Vertical") * movePower;
		float horizontalInput = Input.GetAxis ("Horizontal") * movePower;
		
		//rigidBody.AddForce(new Vector3(horizontalInput, verticalInput, 0));
		//transform.Rotate (0, horizontalInput, 0);

		Vector3 moveDirection = new Vector3(horizontalInput ,rigidBody.velocity.y, verticalInput);
		//Transform the vector3 to local space
		moveDirection = transform.TransformDirection(moveDirection);
		//set the velocity, so you can move
		rigidBody.velocity = moveDirection;
		rigidBody.AddForce (Vector3.up *  -10);
		
	}
}
