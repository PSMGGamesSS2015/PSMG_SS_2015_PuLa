using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {

	// Use this for initialization
	private enum BossAttackMode { Melee, Ranged, Insane};

	private float AttackSpeedMelee = 1.5f;
	private float AttackSpeedRanged = 0.75f;
	private float AttackSpeedInsane = 0.1f;

	private float prSpeedMelee = 10f;
	private float prSpeedRanged = 30f;
	private float prSpeedInsane = 100f;
	
	private BossAttackMode mode;
	private float attackSpeed;
	private float prSpeed;

	private Animator anim;
	private Rigidbody rBody;
	public ParticleSystem insaneParticleSystem;
	public ParticleSystem hitableParticleSystem;

	private Transform player;

	private float movePower = 3f;

	private int hitPoints;
	private bool hitable;
	private bool attackReady;
	private bool isAlive;

	public GameObject projectile;
	public Transform projectileOrigin;

	void Start () {
		anim = GetComponent<Animator> ();
		rBody = GetComponent<Rigidbody> ();
		player = GameObject.Find ("Lama").transform;


		mode = BossAttackMode.Ranged;
		hitPoints = 30;
		hitable = true;
		attackReady = true;
		isAlive = true;
		insaneParticleSystem.Play ();
		hitableParticleSystem.Stop ();
		activate ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isAlive) {
			if (mode == BossAttackMode.Melee) {
				insaneParticleSystem.Stop ();
				moveTowardsPlayer ();
				attackSpeed = AttackSpeedMelee;
				prSpeed = prSpeedMelee;
				anim.SetBool ("isRaging", false);
			} else if (mode == BossAttackMode.Ranged) {
				insaneParticleSystem.Stop ();
				attackSpeed = AttackSpeedRanged;
				prSpeed = prSpeedRanged;
				anim.SetBool ("isRaging", false);
				transform.LookAt(player);
				transform.eulerAngles += new Vector3(0, 180, 0);
			} else if (mode == BossAttackMode.Insane) {
				insaneParticleSystem.Play ();
				attackSpeed = AttackSpeedInsane;
				prSpeed = prSpeedInsane;
				anim.SetBool ("isRaging", true);
			}
		}
	}

	void activate(){
		mode = BossAttackMode.Melee;
		attackSpeed = AttackSpeedMelee;
		prSpeed = prSpeedMelee;
		startAttacking ();
	}

	void startAttacking() {
	 	StartCoroutine(attack ());
	}

	void OnTriggerEnter(Collider collider) {
		if (hitable) {
			if (collider.tag == "Projectile" && collider.name.Contains ("Bullet")) {
				hitPoints --;
				StartCoroutine(recoverFromHit());
				if(hitPoints % 10 == 0) {
					hitable = false;
					StartCoroutine(TransitionIntoInsaneMode());
				} else if (hitPoints % 5 == 0) {
					mode = BossAttackMode.Ranged;
				}
				if(hitPoints == 0) {
					isAlive = false;
					hitable = false;
				}
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
		hitableParticleSystem.Play ();
		yield return new WaitForSeconds (2f);
		hitableParticleSystem.Stop ();
		hitable = true;
	}

	IEnumerator attack() {
		while (isAlive) {
			GameObject spear1 = (GameObject)Instantiate (projectile, projectileOrigin.position, Quaternion.identity);
			Vector3 temp = player.position;
			temp.y += 2;
			spear1.GetComponent<SpearFlyingScript> ().ShootWithSpeed (temp, prSpeed);
			yield return new WaitForSeconds (attackSpeed);

		}
	}

	IEnumerator calmDown() {
		yield return new WaitForSeconds (5);
		mode = BossAttackMode.Melee;
	}

	IEnumerator TransitionIntoInsaneMode() {
		insaneParticleSystem.Play ();
		yield return new WaitForSeconds(2);
		mode = BossAttackMode.Insane;
		hitable = true;
		StartCoroutine (calmDown ());
	}
}
