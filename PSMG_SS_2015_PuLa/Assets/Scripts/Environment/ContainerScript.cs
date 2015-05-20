using UnityEngine;
using System.Collections;

public class ContainerScript : MonoBehaviour {

	// Use this for initialization
	public GameObject spawnObject;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Projectile") {
			if(spawnObject != null){
				GameObject spawn = (GameObject) Instantiate(spawnObject, this.transform.position, Quaternion.identity);
			}
			Destroy(this.gameObject);
		}
	}
}
