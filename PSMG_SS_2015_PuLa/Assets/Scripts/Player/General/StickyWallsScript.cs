using UnityEngine;
using System.Collections;

public class StickyWallsScript : MonoBehaviour {

	private PlayerMovement player;
	private float triggerDistance;
	private float rayYAxisOffset = 1f;
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
		// rayOrigin is the current position of the player but with an increased value to the y-Axis
		// Otherwise the raycast will trigger for the tiles on the ground which will result in bad movement on tiles
		Vector3 rayOrigin = transform.position;
		rayOrigin.y += rayYAxisOffset;
		Ray checkForWallsRay = new Ray (rayOrigin, transform.forward);
		if (Physics.Raycast (checkForWallsRay, out hit, triggerDistance)) {
			return true;
		}
		return false;
	}
}
