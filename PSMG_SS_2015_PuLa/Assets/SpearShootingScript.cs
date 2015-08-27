using UnityEngine;
using System.Collections;

public class SpearShootingScript : MonoBehaviour {
	
	// Use this for initialization
	public GameObject spearObject;
	private Transform flyTo;
	private Transform flyOrigin;
	void Start () {
		flyTo = transform.Find ("FlyTo").transform;
		flyOrigin = transform.Find ("FlyOrigin").transform;
		StartCoroutine (WaitAndShoot ());

	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

	void Shoot() {
		StartCoroutine (WaitAndShoot ());
	}

	IEnumerator WaitAndShoot() {
		SpawnSpear ();
		yield return new WaitForSeconds(Random.Range(1,5));
		Shoot ();
	}

	private void SpawnSpear() {
		GameObject spear1 = (GameObject) Instantiate(spearObject, flyOrigin.position, Quaternion.identity);
		spear1.GetComponent<SpearFlyingScript>().Shoot (flyTo);
	}
}
