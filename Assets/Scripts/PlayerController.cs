using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float walkSpeed = 8f;
	public float jumpSpeed = 7f;

	public HUDManager hud;

	Rigidbody rb;
	Collider coll;

	bool jumped = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		hud.Refresh ();
	}
	
	// Update is called once per frame
	void Update () {
		WalkHandler ();
		JumpHandler ();
	}

	void WalkHandler() {
		rb.velocity = new Vector3 (0f, rb.velocity.y, 0f);

		float dist 	= walkSpeed * Time.deltaTime;
		float hAxis = Input.GetAxis ("Horizontal");
		float vAxis = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (hAxis * dist, 0f, vAxis * dist);
		Vector3 currPos = transform.position;
		Vector3 newPos = currPos + movement;

		rb.MovePosition (newPos);
	}

	void JumpHandler() {
		float jAxis = Input.GetAxis ("Jump");

		if (jAxis > 0) {
			if (!jumped) {
				jumped = true;
				Vector3 jumpVector = new Vector3 (0f, jumpSpeed, 0f);
				rb.velocity = rb.velocity + jumpVector;
			}
		} else {
			jumped = false;
		}
	}

	void OnTriggerEnter(Collider collider) {
		Debug.Log ("Player collides with " + collider.gameObject.tag + "!");

		if (collider.gameObject.tag == "Coin") {
			GameManager.instance.IncreaseScore (1);
			hud.Refresh ();
			Destroy (collider.gameObject);
		} else if (collider.gameObject.tag == "Enemy") {
			Debug.Log ("Game over");
			SceneManager.LoadScene ("GameOver");
		} else if (collider.gameObject.tag == "Goal") {
			Debug.Log ("Goal!");
			GameManager.instance.IncreaseLevel ();
		}
	}
}
