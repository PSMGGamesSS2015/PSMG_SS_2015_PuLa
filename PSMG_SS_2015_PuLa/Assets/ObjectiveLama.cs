using UnityEngine;
using System.Collections;

public class ObjectiveLama : MonoBehaviour {

	public bool active;
	// Use this for initialization
	void Start () {
		active = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Projectile") {
			active = true;	
		}
	}
}
