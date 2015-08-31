using UnityEngine;
using System.Collections;

public class ColorChallengeScript : MonoBehaviour {

	public GameObject[] ColorTiles;
	public GameObject[] EventsOnFinish;
	public Material HighlightColor;
	public Material FinishColor;
	public Material ErrorColor;

	public enum TileColor { Red, Blue, Yellow, Orange, Green };

	private TileColor[] pattern;

	public  bool gameCanBePlayed = false;
	private bool isWorking = false;

	private int currentIndex = 0;
	private int currentLevelOfChallenge = 0;
	private int currentPatternLength;
	private int challengeOnePatternLength = 5;
	private int challengeTwoPatternLength = 8;

	// Time Values
	private float highlightDuration;
	private float waitBetweenHighlights;

	void Start () {
		//Init Time Values
		highlightDuration = 1f;
		waitBetweenHighlights = highlightDuration + 0.5f;

		// Init Color Pattern
		currentPatternLength = challengeOnePatternLength;
		createNewPattern (currentPatternLength);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void showPattern() {
		currentIndex = 0;
		StartCoroutine (highLightTileForShow (pattern));
	}

	IEnumerator highLightTileForShow(TileColor[] sequence) {
		foreach (TileColor currentTileIndex in sequence) {
			StartCoroutine(changeToSpecificColorAndBack(ColorTiles[(int)currentTileIndex], HighlightColor));
			yield return new WaitForSeconds(waitBetweenHighlights);
		}
	}

	IEnumerator changeToSpecificColorAndBack(GameObject tileObject, Material colorMaterial) {
		isWorking = true;
		Debug.Log (getTile (tileObject));
		Material originalColorOfTile = getTile(tileObject).GetComponent<Renderer> ().material;
		changeColorOfTile (tileObject, colorMaterial);
		yield return new WaitForSeconds (highlightDuration);
		changeColorOfTile (tileObject, originalColorOfTile); 
		isWorking = false;
	}

	IEnumerator showErrorAndStartNewPattern(){
		flashAllTilesWithColor (ErrorColor);
		yield return new WaitForSeconds (waitBetweenHighlights);
		createNewPattern (currentPatternLength);
		showPattern ();
	}

	IEnumerator challengeCompleted() {
		gameCanBePlayed = false;
		flashAllTilesWithColor (FinishColor);
		yield return new WaitForSeconds (1);
		transitionIntoNextPartOfGame();
	}

	private void flashAllTilesWithColor(Material colorMaterial) {
		foreach (GameObject tile in ColorTiles) {
			StartCoroutine(changeToSpecificColorAndBack(tile, colorMaterial));
		}
	}
	public void changeColorOfTile(GameObject tileObject, Material materialOfColor) {
		getTile(tileObject).GetComponent<Renderer> ().material = materialOfColor;
	}

	private GameObject getTile(GameObject tileObject){
		return tileObject.transform.FindChild ("Plane").gameObject;
	}

	public void wrongSequence() {
		StartCoroutine (showErrorAndStartNewPattern());
	}

	public void colorTileHit(int tileID){
		if (gameCanBePlayed) {
			if (!isWorking) {
				if (tileID == (int)pattern [currentIndex]) {
					if (currentIndex == pattern.Length - 1) {
						if(currentLevelOfChallenge == 1) {
							Debug.Log ("You beat the game");
						}
						currentPatternLength = challengeTwoPatternLength;
						createNewPattern (currentPatternLength);
						StartCoroutine (challengeCompleted ());
					} else {
						StartCoroutine (changeToSpecificColorAndBack (ColorTiles [tileID], HighlightColor));
						currentIndex ++;
					}
				} else {
					wrongSequence ();
					currentIndex = 0;
				}
			}
		}
	}

	private void createNewPattern(int sequenceLength) {
		TileColor[] pattern = new TileColor[sequenceLength];
		for (int i = 0; i < sequenceLength; i ++) {
			pattern[i] = (TileColor) Random.Range(0, ColorTiles.Length);
		}
		this.pattern = pattern;
	}

	private void transitionIntoNextPartOfGame() {
		EventsOnFinish [currentLevelOfChallenge].GetComponent<MoveScript> ().activate ();
		Transform lookFrom = EventsOnFinish [currentLevelOfChallenge].transform.Find ("LookFrom");
		Transform lookAt = EventsOnFinish[currentLevelOfChallenge].transform.Find("LookTo");
		GameObject.Find ("Main Camera").GetComponent<SmoothThirdPersonCamera> ().CameraEvent (lookFrom, lookAt, 3);
		GameObject.Find ("Lama").GetComponent<PlayerSwap> ().doSwap ();
		currentLevelOfChallenge ++;
	}

}