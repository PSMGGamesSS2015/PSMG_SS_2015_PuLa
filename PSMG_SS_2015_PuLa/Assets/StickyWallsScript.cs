using UnityEngine;
using System.Collections;

public class StickyWallsScript : MonoBehaviour {

	private PlayerMovement player;
	// Use this for initialization
	void Start () {
		player = transform.parent.GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){
		player.isStuckInWall = true;
	}

	void OnTriggerExit(Collider collider){
		player.isStuckInWall = false;
	}

}
