using UnityEngine;
using System.Collections;

public class PumaClimb : MonoBehaviour {

	private float triggerDistance;
	private UIHint climbHintText;
	private float climbspeed;
	// Use this for initialization
	void Start () {
		triggerDistance = 1;
		climbspeed = 20;
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
		Debug.Log (hit);
		Debug.Log (hit.GetComponentInParent<MeshFilter>().mesh.bounds.extents.y);
		Vector3 endOfClimb = transform.position;
		Debug.Log (endOfClimb.y);
		endOfClimb.y += hit.GetComponentInParent<MeshFilter>().mesh.bounds.size.y * hit.transform.lossyScale.y + transform.lossyScale.y;
		endOfClimb += transform.forward * 2;
		transform.position = endOfClimb;

	}
}
