using UnityEngine;
using System.Collections;

public class BolderTriggerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider collider){
		if (collider.tag != "Asdasds") {
			Debug.Log ("Hit");
			transform.parent.gameObject.GetComponent<BolderFallDownScript> ().isFalling = false;
		}
	}
}
