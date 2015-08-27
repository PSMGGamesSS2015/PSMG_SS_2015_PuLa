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
	
	void OnTriggerStay(Collider collider){
		if (collider.tag != "Player" && collider.tag != "EditorOnly") {
			player.isMidAir = false;
		}
	}
	
	void OnTriggerExit(Collider collider){
		if (collider.tag != "Player" && collider.tag != "EditorOnly") {
			player.isMidAir = true;
		}
	}
}
