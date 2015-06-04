using UnityEngine;
using System.Collections;

public class JumpTriggerScript : MonoBehaviour {
	
	// Use this for initialization
	private PlayerMovement player;
	void Start () {
		player = GetComponentInParent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerEnter(Collider collider){
		if (collider.tag != "Player") {
			player.isMidAir = false;
		}
	}
	
	void OnTriggerExit(Collider collider){
		if (collider.tag != "Player") {
			player.isMidAir = true;
		}
	}
}
