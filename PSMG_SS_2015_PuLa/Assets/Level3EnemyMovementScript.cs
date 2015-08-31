using UnityEngine;
using System.Collections;

public class Level3EnemyMovementScript : MonoBehaviour {

	// Use this for initialization

	public Transform playerTarget;
	public Transform runTo;
	private Transform target;

	private bool isAlive = true;

	private float movePower = 2.5f;

	private Rigidbody rBody;
	private Animator anim;
	void Start () {
		rBody = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isAlive && target != null) {
			anim.SetBool ("isWalking", true);
			transform.LookAt (target);
			transform.eulerAngles += new Vector3 (0, 180, 0);
			transform.position += -transform.forward * movePower * Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.name == "OutOfRoomTrigger") {
			target = playerTarget;
		}
		if (collider.tag == "Projectile") {
			if(isAlive) {
				isAlive = false;
				anim.SetBool("isDead", true);
				Vector3 pos = transform.position;
				pos.y += 0.3f;
				transform.position = pos;
				rBody.isKinematic = true;
			}
		}
	}

	public void activate() {
		target = runTo;
	}
}
