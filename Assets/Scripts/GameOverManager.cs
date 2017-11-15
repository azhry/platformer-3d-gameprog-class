using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

	public Text score;

	// Use this for initialization
	void Start () {
		Debug.Log ("Score: " + GameManager.instance.score);
		score.text = "Your score: " + GameManager.instance.score;
	}
	
	public void Restart() {
		Debug.Log ("Reset");
		GameManager.instance.Reset ();
	}
}
