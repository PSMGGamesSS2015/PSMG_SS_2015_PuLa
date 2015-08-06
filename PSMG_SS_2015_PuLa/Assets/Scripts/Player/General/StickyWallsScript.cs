using UnityEngine;
using System.Collections;

public class StickyWallsScript : MonoBehaviour {

	private PlayerMovement player;
	private float triggerDistance;
	// Use this for initialization
	void Start () {
		triggerDistance = 2f;
		player = GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		player.isStuckInWall = checkIfStuckInWall ();
	}

	private bool checkIfStuckInWall() {
		RaycastHit hit;
		Ray checkForWallsRay = new Ray (transform.position, transform.forward);
		if (Physics.Raycast (checkForWallsRay, out hit, triggerDistance)) {
			return true;
		}
		return false;
	}
}
