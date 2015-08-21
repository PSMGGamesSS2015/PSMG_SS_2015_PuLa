using UnityEngine;
using System.Collections;

public class Persistence : MonoBehaviour {

	private GameElements ui;
	private GameObject persistenceObject;
	private float pabloLives;
	private float ludwigLives;
	private float pabloHealth;
	private float ludwigHealth;
	private int levelCount;

	// Use this for initialization
	void Start () {
		persistenceObject = GameObject.Find ("Persistence"); 
		ui = GameObject.Find ("UI").GetComponent<GameElements> ();
		levelCount = Application.loadedLevel;
		Debug.Log ("ölkajdölfkaölsdfksakfjöasjdfksdökfjkaökfdj" + "LevelCount" + levelCount);
		if (levelCount == 1) {
			ludwigLives = 1;
		}
	
	}

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
	
	}
	// Update is called once per frame
	void Update () {
	    ludwigLives = ui.getLudwigLives();
		pabloHealth = ui.getPabloHealth();
		pabloLives = ui.getPabloHealth();
		pabloLives = ui.getPabloLives ();

	}

	public float setLudwigLives(){
		Debug.Log ("lakjöflkjaöljdflksaöldkfjölkasjdflkja" + "LUDWIGLIVES" + ludwigLives);
		return ludwigLives;
	}
}
