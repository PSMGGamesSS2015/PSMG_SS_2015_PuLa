using UnityEngine;
using System.Collections;

public class BolderFallDownScript : MonoBehaviour {

	private bool isFalling = false;
	public float waitAtStartTime;
	public GameObject moveDown;
	public GameObject moveUp;
	// Use this for initialization
	void Start () {
		StartCoroutine (WaitAtStart (waitAtStartTime));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isFalling) {
			transform.position = Vector3.Lerp (this.transform.position, moveDown.transform.position, Time.deltaTime * 20f);
			if (transform.position.y <= moveDown.transform.position.y + 0.05) {
				StartCoroutine (Wait (1f));

			}
		} else {
			transform.position = Vector3.Lerp (this.transform.position, moveUp.transform.position, Time.deltaTime * 2f);
			if (transform.position.y >= moveUp.transform.position.y - 0.05) {
				isFalling = true;
			}
		}
	}


	IEnumerator Wait (float duration){
		yield return new WaitForSeconds(duration);
		isFalling = false;
	}

	IEnumerator WaitAtStart(float waitAtStartTime) {
		yield return new WaitForSeconds (waitAtStartTime);
		isFalling = true;
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag != "Player") {
			Debug.Log("trigger");
			StartCoroutine(Wait(2f));
		}
	}
}
