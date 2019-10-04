using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp : MonoBehaviour {

	public float amplitude = 0.3f;
	public float frequency = 0.3f;
	
	Vector3 posOffset = new Vector3 ();
	Vector3 tempPos = new Vector3 ();

	void Start () {

		//Records the starting position of the Imp.
		posOffset = transform.position;
	}

	void Update () {

		//Makes the Imp bounce up and down.
		tempPos = posOffset;
		tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;

		transform.position = tempPos;
	}
}
