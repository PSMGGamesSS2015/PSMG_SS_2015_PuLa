using UnityEngine;
using System.Collections;

public class SwitchSceneTriggerScript : MonoBehaviour {

	// Use this for initialization
	public int nextLevel;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player") {
			Application.LoadLevel(nextLevel);
		}
	}
}
