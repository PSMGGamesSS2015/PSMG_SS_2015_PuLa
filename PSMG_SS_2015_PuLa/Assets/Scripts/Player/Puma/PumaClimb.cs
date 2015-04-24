using UnityEngine;
using System.Collections;

public class PumaClimb : MonoBehaviour {

	/**
	 * Script for the climbing ability.
	 * Needs to be redone.
	 * Currently the climb is instant.
	 * This will be changed to a climb over a defined amount of time so that a proper climbing animation can be played.
	 **/

	private float triggerDistance;
	private UIHint climbHintText;
	// Use this for initialization
	void Start () {
		triggerDistance = 1.5f;
		climbHintText = GameObject.Find ("ClimbHint").GetComponent<UIHint>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (GetComponent<PlayerMovement> ().active) {
			doFixedUpdate();
		}
	}

	void doFixedUpdate(){
		RaycastHit hit;
		Ray climbRay = new Ray (transform.position, transform.forward);
		if(Physics.Raycast (climbRay, out hit, triggerDistance)){
			if(hit.collider.tag == "Climbable"){
				climbHintText.showText();
			} 
		} else {
			climbHintText.hideText();
		}
		if(Input.GetKeyDown(KeyCode.Q)){
			if(climbHintText.isEnabled()){
				doClimb(hit.collider);
			}
		}
	}

	void doClimb(Collider hit){
		Vector3 endOfClimb = transform.position;
		endOfClimb.y += hit.GetComponentInParent<MeshFilter>().mesh.bounds.size.y * hit.transform.lossyScale.y + transform.lossyScale.y;
		endOfClimb += transform.forward * 2;
		transform.position = endOfClimb;

	}
}
