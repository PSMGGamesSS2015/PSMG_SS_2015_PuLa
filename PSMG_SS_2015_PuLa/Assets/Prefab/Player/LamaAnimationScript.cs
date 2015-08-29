using UnityEngine;
using System.Collections;

public class animControllerLudwig : MonoBehaviour {

	private Animator anim;
	private PlayerMovement player;
	private PumaMovement sprint;

	// Use this for initialization
	void Start () {

		player = GetComponent<PlayerMovement> ();
		sprint = GetComponent<PumaMovement> ();
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space)) {
			anim.SetBool ("isJumping", true);
		} else {
			anim.SetBool ("isJumping", false);

		}
		if (Input.GetKeyDown(KeyCode.X)) {
			anim.SetBool ("clout", true);
		} else { 
			anim.SetBool ("clout", false);	
		}
		if (player.active) {
			float movement = Mathf.Abs (Input.GetAxis ("Vertical")) + Mathf.Abs (Input.GetAxis ("Horizontal"));
			anim.SetFloat ("Speed", movement);
			/**
			if(movement == 0){
				anim.Play("Idle");
			}**/
		}
	}
	public void JumpAnimationLama(){
		anim.Play ("Jumping");
	}
}
