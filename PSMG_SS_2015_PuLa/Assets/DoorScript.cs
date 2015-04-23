using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	private ObjectiveLama lama;
	private ObjectivePuma puma;
	private Vector3 openDoor;
	// Use this for initialization
	void Start () {
		lama = GameObject.Find ("Objective_Lama").GetComponent<ObjectiveLama>();
		puma = GameObject.Find ("Objective_Puma").GetComponent<ObjectivePuma>();
		openDoor = transform.position + new Vector3 (0, -30, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (lama.active && puma.active) {
			transform.position = Vector3.Lerp(transform.position, openDoor, Time.deltaTime);
		}
	}
}
