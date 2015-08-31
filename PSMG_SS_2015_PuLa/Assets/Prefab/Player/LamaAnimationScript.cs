using UnityEngine;
using System.Collections;

public class LamaAnimationScript : MonoBehaviour {

	private int cloutCounterCheet = 0;
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

//		if (jump) {
//			Debug.Log("Sollte False sein: " + anim.GetBool ("isJumping"));
//			anim.SetBool ("isJumping", true);
//			Debug.Log("Sollte True sein: " + anim.GetBool ("isJumping"));
//			jump = false;
//		} else {
//			anim.SetBool ("isJumping", false);
//	
//		}	
		if (Input.GetKeyDown (KeyCode.X)) {
			cloutCounterCheet++;
		}
		
		if (cloutCounterCheet == 3) {
			anim.SetBool ("clout", true);
			cloutCounterCheet = 0;
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
		//jumping dindn't work right
		//anim.Play("Jumping");
	}
}
