using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScroll : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (transform.position.y < 1000)
			transform.Translate (0, 1, 0);
		else
			SceneManager.LoadScene ("Main Menu");
	}
}
