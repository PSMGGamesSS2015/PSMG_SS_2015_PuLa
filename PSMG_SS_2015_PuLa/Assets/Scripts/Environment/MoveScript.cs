using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	// Use this for initialization
	private bool active;
	public GameObject moveTo;
	private Vector3 wantedPosition;

	void Start () {
		active = false;
		wantedPosition = moveTo.transform.position;
	}

	void DoUpdate(){
		Debug.Log ("movingNow");
		transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime);
		if (transform.position == wantedPosition) {
			active = false;
		}
	}

	// Update is called once per frame
	void Update () {
		if (active) {
			DoUpdate ();
		}
	}

	public void activate(){
		Debug.Log ("TEST");
		active = true;

	}

	IEnumerator Wait (float duration){
		yield return new WaitForSeconds(duration);
	}
}
