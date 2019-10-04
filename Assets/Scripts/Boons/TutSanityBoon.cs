using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutSanityBoon : MonoBehaviour {

	public Transform Target;
	public float speed = 3.0f;
	public float amplitude = 0.3f;
	public float frequency = 0.3f;
	public bool reached;
	public bool active;
	Vector3 posOffset = new Vector3 ();
	Vector3 tempPos = new Vector3 ();


	void Start () {

	}


	void Update () {
		if (active == true) {
			if (transform.position != Target.position && reached == false) {

				transform.position = Vector3.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
				posOffset = transform.position;

				if (transform.position == Target.position) {
					reached = true;
				}

			} else {
				//Rotates the SanityBoon around the Y axis.
				//transform.Rotate (new Vector3 (0, 30, 0) * Time.deltaTime);

				//Makes the SanityBoon bounce up and down.
				tempPos = posOffset;
				tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;

				transform.position = tempPos;
			}
		}
	}
}
