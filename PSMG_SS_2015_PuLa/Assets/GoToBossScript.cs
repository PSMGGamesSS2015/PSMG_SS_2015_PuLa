using UnityEngine;
using System.Collections;

public class GoToBossScript : MonoBehaviour {

	// Use this for initialization
	public Transform spawnPos;
	public GameObject boss;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.name == "Lama") {
			collider.transform.position = spawnPos.position;
			boss.GetComponent<BossScript>().activate();
		}
		if (collider.name == "Puma") {
			collider.GetComponent<PlayerSwap>().doSwap();
			GameObject.Find("Lama").transform.position = spawnPos.position;
			boss.GetComponent<BossScript>().activate();
		}
	}
}
