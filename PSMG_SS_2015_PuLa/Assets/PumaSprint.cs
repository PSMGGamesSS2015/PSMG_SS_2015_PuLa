using UnityEngine;
using System.Collections;

public class PumaSprint : MonoBehaviour {

	private float sprintSpeed;
	private float walkingSpeed;
	private const float MAX_STAMINA = 100;
	private float stamina;
	private float deltaStamina;
	private bool isSprintOn;
	private bool tired;
	// Use this for initialization
	void Start () {
		walkingSpeed = GetComponent<PlayerMovement> ().movePower;
		sprintSpeed = 25;
		stamina = 100;
		deltaStamina = 2;
		isSprintOn = false;
		tired = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (GetComponent<PlayerMovement> ().active) {
			doUpdate();
		}
	}

	void doUpdate(){
		if (Input.GetKey (KeyCode.LeftShift)) {
			if (stamina > 0 && !tired) {
				isSprintOn = true;
			} else {
				isSprintOn = false;
			}
		} else {
			isSprintOn = false;
		}

		if (stamina == 0) {
			tired = true;
		}
		if (stamina >  9 * MAX_STAMINA / 10) {
			tired = false;
		}

		if (isSprintOn) {
			GetComponent<PlayerMovement>().movePower = sprintSpeed;
			stamina -= deltaStamina;
		} else {
			GetComponent<PlayerMovement>().movePower = walkingSpeed;
			if(stamina < MAX_STAMINA){
				stamina += deltaStamina;
			}
		}
	}
}
