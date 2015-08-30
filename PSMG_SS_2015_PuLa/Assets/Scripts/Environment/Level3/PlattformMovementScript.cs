using UnityEngine;
using System.Collections;

public class PlattformMovementScript : MonoBehaviour {

	// Use this for initialization
	public int movingDirection = 1;
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += Vector3.forward * (movingDirection) * 0.05f;
	}
}
