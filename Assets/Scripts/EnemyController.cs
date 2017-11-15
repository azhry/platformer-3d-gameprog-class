using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float range = 1f;
	public float speed = 3f;
	public float direction = 1f;

	public char axis = 'z';

	Vector3 initialPos;

	// Use this for initialization
	void Start () {
		initialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float movement  = direction * speed * Time.deltaTime;
		float newPos;

		if (axis == 'z') {
			newPos = transform.position.z + movement;
			if (Mathf.Abs (newPos - initialPos.z) > range) {
				direction *= -1;
			} else {
				if (axis == 'z') {
					transform.Translate (new Vector3(0, 0, movement));
				} else if (axis == 'y') {
					transform.Translate (new Vector3(0, movement, 0));
				} else if (axis == 'x') {
					transform.Translate (new Vector3(movement, 0, 0));
				}
			}
		} else if (axis == 'y') {
			newPos = transform.position.y + movement;
			if (Mathf.Abs (newPos - initialPos.y) > range) {
				direction *= -1;
			} else {
				transform.Translate (new Vector3(0, movement, 0));
			}
		} else if (axis == 'x') {
			newPos = transform.position.x + movement;
			if (Mathf.Abs (newPos - initialPos.x) > range) {
				direction *= -1;
			} else {
				transform.Translate (new Vector3(movement, 0, 0));
			}
		}


	}
}
