using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

	public Text scoreLabel;

	// Use this for initialization
	void Start () {
		
	}
	
	public void Refresh () {
		scoreLabel.text = "Score: " + GameManager.instance.score;	
	}
}
