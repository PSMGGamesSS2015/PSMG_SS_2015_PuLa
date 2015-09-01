using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {

	// Use this for initialization
	private enum BossAttackMode { Melee, Ranged, Insane};
	private enum BossAttackSpeed {Melee = 15, Ranged = 80, Insane = 1};
	private enum BossProjectileSpeed {Melee = 10, Ranged = 30, Insane = 100};

	private BossAttackMode mode;
	private BossAttackSpeed attackSpeed;
	private BossProjectileSpeed prSpeed;

	private Animator anim;
	private Rigidbody rBody;
	private ParticleSystem insaneParticleSystem;
	private ParticleSystem hitableParticleSystem;

	private Transform player;

	private float movePower = 3f;

	private int hitPoints;
	private bool hitable;
	private bool attackReady;

	void Start () {
		anim = GetComponent<Animator> ();
		rBody = GetComponent<Rigidbody> ();
		insaneParticleSystem = transform.Find ("InsaneVisualizer").gameObject.GetComponent<ParticleSystem> ();
		hitableParticleSystem = transform.Find ("hitableVisualizer").gameObject.GetComponent<ParticleSystem> ();


		mode = BossAttackMode.Ranged;
		hitPoints = 30;
		hitable = true;
		attackReady = true;
		insaneParticleSystem.Stop ();
		hitableParticleSystem.Stop ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (mode == BossAttackMode.Melee) {
			insaneParticleSystem.Stop ();
			moveTowardsPlayer();
			attackSpeed = BossAttackSpeed.Melee;
			prSpeed = BossProjectileSpeed.Melee;
		} else if (mode == BossAttackMode.Ranged) {
			insaneParticleSystem.Stop ();
			attackSpeed = BossAttackSpeed.Ranged;
			prSpeed = BossProjectileSpeed.Ranged;
		} else if (mode == BossAttackMode.Insane) {
			insaneParticleSystem.Simulate();
			attackSpeed = BossAttackSpeed.Insane;
			prSpeed = BossProjectileSpeed.Insane;
		}
	}

	void activate(){
		mode = BossAttackMode.Melee;
		startAttacking ();
	}

	void startAttacking() {
		while (attackReady) {
			StartCoroutine(attack (attackSpeed));
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (hitable) {
			if (collider.tag == "Projectile" && collider.tag.Contains ("Bullet")) {
				hitPoints --;
				StartCoroutine(recoverFromHit());
			}
		}
	}

	void moveTowardsPlayer() {
		transform.LookAt (player);
		transform.eulerAngles += new Vector3 (0, 180, 0);
		transform.position += -transform.forward * movePower * Time.deltaTime;
	}

	IEnumerator recoverFromHit() {
		hitable = false;
		hitableParticleSystem.Simulate ();
		yield return new WaitForSeconds (2f);
		hitableParticleSystem.Stop ();
		hitable = true;
	}

	IEnumerator attack(float attackSpeed) {
		attackReady = false;

		//Spawn Projectile

		yield return new WaitForSeconds (attackSpeed/10);
		attackReady = true;
	}
}
