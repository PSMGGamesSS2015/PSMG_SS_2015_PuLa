using UnityEngine;
using System.Collections;

public class ColorChallengeScript : MonoBehaviour {

	// Use this for initialization
	public GameObject[] ColorTiles;
	public Material HighlightColor;

	public enum TileColor { Red, Blue, Yellow, Orange, Green };
	
	void Start () {
		TileColor[] test = {TileColor.Blue, TileColor.Yellow, TileColor.Red, TileColor.Orange, TileColor.Yellow, TileColor.Green};
		StartCoroutine (highLightTileForShow (test));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator highLightTileForShow(TileColor[] sequence) {
		foreach (TileColor currentTileIndex in sequence) {
			StartCoroutine(changeColorToHighlightAndBack(ColorTiles[(int)currentTileIndex]));
			yield return new WaitForSeconds(2);
		}
	}

	IEnumerator changeColorToHighlightAndBack(GameObject tileObject) {
		Debug.Log (getTile (tileObject));
		Material originalColorOfTile = getTile(tileObject).GetComponent<Renderer> ().material;
		changeColorOfTile (tileObject, HighlightColor);
		yield return new WaitForSeconds (1);
		changeColorOfTile (tileObject, originalColorOfTile); 
	}
		
	public void changeColorOfTile(GameObject tileObject, Material materialOfColor) {
		getTile(tileObject).GetComponent<Renderer> ().material = materialOfColor;
	}

	private GameObject getTile(GameObject tileObject){
		return tileObject.transform.FindChild ("Plane").gameObject;
	}
}