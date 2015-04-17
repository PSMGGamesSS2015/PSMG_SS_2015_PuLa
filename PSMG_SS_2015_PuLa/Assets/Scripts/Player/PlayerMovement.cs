using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	private Rigidbody rigidBody;
	public float movePower;
	public float jumpPower;
	public bool active;
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		jumpPower *= 3;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (active) {
			doUpdate ();
		}
	}
	void doUpdate(){
		if(Input.GetKeyDown(KeyCode.Space)){
			Vector3 jump = new Vector3(0, jumpPower, 0);
			rigidBody.velocity = jump;
			rigidBody.AddForce ( Vector3.up * 10);

		}

		float verticalInput = Input.GetAxis ("Vertical") * movePower;
		float horizontalInput = Input.GetAxis ("Horizontal");
		
		//rigidBody.AddForce(new Vector3(horizontalInput, verticalInput, 0));
		transform.Rotate (0, horizontalInput, 0);

		Vector3 moveDirection = new Vector3(0 ,rigidBody.velocity.y,movePower*Input.GetAxis("Vertical"));
		//Transform the vector3 to local space
		moveDirection = transform.TransformDirection(moveDirection);
		//set the velocity, so you can move
		rigidBody.velocity = moveDirection;
		rigidBody.AddForce (Vector3.up *  -10);
		
	}
}
