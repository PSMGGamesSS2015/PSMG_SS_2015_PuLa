using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	// Use this for initialization
	private Animator anim;
	private PlayerMovement movement;
	private enum States{idle, walk, jump};

	void Start () {
		anim = GetComponent<Animator> ();
		movement = GameObject.Find ("Lama").GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (movement.active) {
			doUpdate();
		}
	}

	void doUpdate(){
		
		float move = Input.GetAxis ("Vertical") + Input.GetAxis ("Horizontal");
		if (move < 0) {
			move *= -1;
		}
		anim.SetFloat ("Speed", move);

	}
}
