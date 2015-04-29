using UnityEngine;
using System.Collections;

public class EnemyUnitMovement : MonoBehaviour {
	/**
	 * Script for the basic movement of the enemy unit.
	 * Enemy unit will rest on position ( for now, in future a patrolling feature could be added )
	 * once it spots the player ( if sphere collider triggers ) it will chase the player until either one dies
	 * Enemy can be killed by shooting ( with the lama )
	 **/
	// Use this for initialization
	private Rigidbody rBody;
	private bool isAlive;
	private bool isChasing;
	private float movePower;
	private float damageOnHit;

	void Start () {
		rBody = GetComponent<Rigidbody> ();
		isAlive = true;
		isChasing = false;
		movePower = 5f;
		damageOnHit = 1;
	}
	
	void FixedUpdate () {
		if(isAlive){
			doUpdate();
		}
	}

	void doUpdate(){

	}
}
