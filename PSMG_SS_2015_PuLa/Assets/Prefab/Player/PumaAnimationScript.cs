using UnityEngine;
using System.Collections;

public class PumaAnimationScript: MonoBehaviour {

	// Use this for initialization
	private Animator anim;
	private PlayerMovement player;
	private PumaSprint sprint;

	void Start () {
		player = GetComponent<PlayerMovement> ();
		sprint = GetComponent<PumaSprint> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.active) {
			anim.SetBool("Tired", sprint.tired);
			float movement = Mathf.Abs (Input.GetAxis ("Vertical")) + Mathf.Abs (Input.GetAxis ("Horizontal"));
			anim.SetFloat ("Speed", movement);
			Debug.Log (movement);
			/**
			if(movement == 0){
				anim.Play("Idle");
			}**/
		}
	}

	public void JumpAnimation(){
		anim.Play ("Jumping");
	}
}
