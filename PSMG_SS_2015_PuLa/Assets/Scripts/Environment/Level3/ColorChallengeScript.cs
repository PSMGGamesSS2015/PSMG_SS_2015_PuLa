using UnityEngine;
using System.Collections;

public class ColorChallengeScript : MonoBehaviour {

	// Use this for initialization
	public GameObject[] ColorTiles;
	public Material HighlightColor;
	public Material FinishColor;

	public enum TileColor { Red, Blue, Yellow, Orange, Green };

	private int currentIndex = 0;
	private TileColor[] test;

	void Start () {
		test = new TileColor[]{TileColor.Blue, TileColor.Yellow, TileColor.Red, TileColor.Orange, TileColor.Yellow, TileColor.Green};
		showPattern ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void showPattern() {
		currentIndex = 0;
		StartCoroutine (highLightTileForShow (test));
	}

	IEnumerator highLightTileForShow(TileColor[] sequence) {
		foreach (TileColor currentTileIndex in sequence) {
			StartCoroutine(changeToSpecificColorAndBack(ColorTiles[(int)currentTileIndex], HighlightColor));
			yield return new WaitForSeconds(1.1f);
		}
	}

	IEnumerator changeToSpecificColorAndBack(GameObject tileObject, Material colorMaterial) {
		Debug.Log (getTile (tileObject));
		Material originalColorOfTile = getTile(tileObject).GetComponent<Renderer> ().material;
		changeColorOfTile (tileObject, colorMaterial);
		yield return new WaitForSeconds (1);
		changeColorOfTile (tileObject, originalColorOfTile); 
	}
		
	public void changeColorOfTile(GameObject tileObject, Material materialOfColor) {
		getTile(tileObject).GetComponent<Renderer> ().material = materialOfColor;
	}

	private GameObject getTile(GameObject tileObject){
		return tileObject.transform.FindChild ("Plane").gameObject;
	}

	public void wrongSequence() {
		foreach (GameObject tile in ColorTiles) {
			StartCoroutine(changeToSpecificColorAndBack(tile, HighlightColor));
		}
	}

	public void colorTileHit(int tileID){
		if (tileID == (int)test [currentIndex]) {
			StartCoroutine (changeToSpecificColorAndBack (ColorTiles [tileID], HighlightColor));
			currentIndex ++;
		} else {
			wrongSequence();
			currentIndex = 0;
		}
	}
}