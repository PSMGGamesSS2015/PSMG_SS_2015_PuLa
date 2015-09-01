using UnityEngine;
using System.Collections;

public class GameItemsScript : MonoBehaviour {
    public bool matchesFound = false;
	public bool dynamiteFound = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool checkIfGameItemsHaveBeenFound(){
		if (PlayerPrefs.GetInt ("DynamiteFound") == 1 && PlayerPrefs.GetInt ("MatchesFound") == 1) {
			return true;
		
		} else {
			return false;
		}

	}


}
