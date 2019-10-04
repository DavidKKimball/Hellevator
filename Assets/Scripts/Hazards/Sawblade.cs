using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawblade : MonoBehaviour {

	public float RPM = 150.0f;

	void Update () {

		//Causes Sawblade to rotate.
		transform.Rotate(0f, 6.0f * RPM * Time.deltaTime, 0f);

	}
}
