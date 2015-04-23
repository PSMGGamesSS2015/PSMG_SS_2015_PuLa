using UnityEngine;
using System.Collections;

public class PumaSprint : MonoBehaviour {

	private float sprintSpeed;
	private float walkingSpeed;
	private float slowSpeed;
	private const float MAX_STAMINA = 150;
	private float stamina;
	private float staminaDrain;
	private float staminaGain;
	private bool isSprintOn;
	private bool tired;
	// Use this for initialization
	void Start () {
		walkingSpeed = GetComponent<PlayerMovement> ().movePower;
		slowSpeed = 2;
		sprintSpeed = 25;
		stamina = 150;
		staminaDrain = 2;
		staminaGain = 0.5f;
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
		if (stamina > 9 * MAX_STAMINA / 10) {
			tired = false;
		}
		if (tired) {
			GetComponent<PlayerMovement> ().movePower = slowSpeed;
		} else {
			GetComponent<PlayerMovement>().movePower = walkingSpeed;
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
}
