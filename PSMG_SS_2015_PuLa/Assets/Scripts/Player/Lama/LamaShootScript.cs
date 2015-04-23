using UnityEngine;
using System.Collections;

public class LamaShootScript : MonoBehaviour {



	// Use this for initialization
	private Camera lamaCam;
	private GameObject bullet;
	void Start () {
		bullet = GameObject.Find ("Bullet");
		lamaCam = GetComponentInChildren<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<PlayerMovement> ().active) {
			doUpdate ();
		}
	}

	void doUpdate(){
		if(Input.GetKeyDown(KeyCode.Mouse0) && lamaCam.enabled){
			RaycastHit hit;
			Ray ray = lamaCam.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
			if(Physics.Raycast (ray, out hit, 10000)){
				Vector3 target = lamaCam.transform.position + lamaCam.transform.forward;
				GameObject bullet1 = (GameObject) Instantiate(bullet, target, Quaternion.identity);
				bullet1.GetComponent<BulletScript>().shoot (hit.point);
			}
		}
	}
}
