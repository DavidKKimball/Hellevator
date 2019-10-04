using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelTurn : MonoBehaviour {

	void Update () {

		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
			float angle = Mathf.Atan2(-Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical"))  * Mathf.Rad2Deg;

			transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
		}
	}
}
