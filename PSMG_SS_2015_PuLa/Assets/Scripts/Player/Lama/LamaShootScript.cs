using UnityEngine;
using System.Collections;

public class LamaShootScript : MonoBehaviour {

	/**
	 * Shooting script active while in FPS mode when controlling lama.
	 * Bullets needs to be changed to an actual model.
	 * For now, Bullets ignore gravity.
	 * A bullet needs to be placed somewhere on the map and linked to this script;
	 **/

	// Use this for initialization
	private Camera lamaCam;
	public GameObject bullet;
	void Start () {
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
