using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	// Use this for initialization
	private bool active;
	public GameObject moveTo;
	private Vector3 wantedPosition;
	private float time;
	private float timeEnd;


	void Start () {
		active = false;
		wantedPosition = moveTo.transform.position;
	
	}

	void DoUpdate(){
		transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime);

		time = Time.time;
		if (time > timeEnd) {
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
		active = true;

		time = Time.time;
		timeEnd = time + 5;
	}

	IEnumerator Wait (float duration){
		yield return new WaitForSeconds(duration);
	}
}
