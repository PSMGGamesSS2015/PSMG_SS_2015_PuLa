using UnityEngine;
using System.Collections;

public class BolderFallDownScript : MonoBehaviour {

	public bool isFalling = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isFalling) {
			transform.position = Vector3.Lerp(this.transform.position, GameObject.Find ("BolderHitZone").transform.position, Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider collider){
		isFalling = false;
	}
}
