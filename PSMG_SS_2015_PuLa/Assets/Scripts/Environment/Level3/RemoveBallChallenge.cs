using UnityEngine;
using System.Collections;

public class RemoveBallChallenge : MonoBehaviour {

	// Use this for initialization
	public GameObject ballChallenge;
	public GameObject colorChallengeTrigger;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player") {
			Debug.Log ("Placeholder Gameobject taken");
			Destroy(ballChallenge.gameObject);
			Destroy (this.gameObject);
			colorChallengeTrigger.GetComponent<StartColorChallenge>().enabled = true;
		}
	} 
}
