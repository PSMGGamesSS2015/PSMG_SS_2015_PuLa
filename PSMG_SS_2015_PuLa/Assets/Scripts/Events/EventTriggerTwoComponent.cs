using UnityEngine;
using System.Collections;

public class EventTriggerTwoComponent : MonoBehaviour {

	// Use this for initialization

	public delegate void OnTestEvent(string s);
	public OnTestEvent OnTest;

	void Start () {

	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
