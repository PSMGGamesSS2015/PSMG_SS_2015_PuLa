using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	private bool ready;

	public GameObject target;

	void Start () {
		ready = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player" && ready) {
			Debug.Log ("moving");
			Vector3 temp = target.transform.position;
			temp.z = 72.2f;
			target.transform.position = temp;
			ready = false;
		}
	}
}
