using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityBoon : MonoBehaviour {

	public float amplitude = 0.3f;
	public float frequency = 0.3f;
	Vector3 posOffset = new Vector3 ();
	Vector3 tempPos = new Vector3 ();

	void Start () {

		//Records the starting position of the SanityBoon.
		posOffset = transform.position;
	}

	void Update () {

		//Rotates the SanityBoon around the Y axis.
		transform.Rotate (new Vector3 (0, 30, 0) * Time.deltaTime);

		//Makes the SanityBoon bounce up and down.
		tempPos = posOffset;
        tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
	}
}
