using UnityEngine;
using System.Collections;

public class ObjectivePuma : MonoBehaviour {

	public bool active;
	// Use this for initialization
	void Start () {
		active = false;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = new Ray (transform.position, transform.up);
		if (Physics.Raycast (ray, out hit, 10)) {
			if(hit.collider.tag == "Player"){
				active = true;
			}
		}
	}
}
