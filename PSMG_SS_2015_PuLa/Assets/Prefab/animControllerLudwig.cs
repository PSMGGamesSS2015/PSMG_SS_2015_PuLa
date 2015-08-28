using UnityEngine;
using System.Collections;

public class animControllerLudwig : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton ("Space")) {
			anim.SetBool ("walkToJump", true);
		} else {
			anim.SetBool ("walkToJump", false);

		}
		if (Input.GetButton ("x")) {
			anim.SetBool ("walkToClout", true);
		} else { 
			anim.SetBool ("walkToClout", false);	
		}
	}
}
