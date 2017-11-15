using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public int score = 0;

	public int currentLevel = 1;
	public int highestLevel = 2;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	public void IncreaseScore(int amount) {
		score += amount;

		Debug.Log ("New Score: " + score.ToString());
	}

	public void Reset() {
		score = 0;
		currentLevel = 1;
		Debug.Log ("Reset");
		SceneManager.LoadScene ("Level" + currentLevel);
	}

	public void IncreaseLevel() {
		if (currentLevel == highestLevel) {
			SceneManager.LoadScene ("GameOver");
			return;
			//currentLevel = 1;
		} else if (currentLevel < highestLevel) {
			currentLevel++;
		}

		SceneManager.LoadScene ("Level" + currentLevel);

	}
}
