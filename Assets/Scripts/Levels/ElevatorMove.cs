using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorMove : MonoBehaviour {

	EyeSpawn EyeSpawn;

	public Transform target;
	public Transform target2;
	public bool incomingSwap;
	public bool levelSwap;
	public bool level2;
	public bool level3;
	public float smoothFactor = 0.5f;

	void Start () {
		EyeSpawn = GameObject.Find("Enemy Spawns").GetComponent<EyeSpawn>();
	}

	void Update () {

		if (EyeSpawn.levelClear == true && EyeSpawn.level2Clear == false) {
			incomingSwap = true;
		}

		if (EyeSpawn.level2Clear == true && level3 == false) {
			incomingSwap = true;
		}

		if (EyeSpawn.levelClear == true && EyeSpawn.level2Clear == false) {
			if (transform.position == target.position) {
				levelSwap = false;

				if (level2 == false) {
					level2 = true;
				}
			} else if (transform.position != target.position && levelSwap == true) {
				transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * smoothFactor);
			}
		} else if (EyeSpawn.levelClear == true && EyeSpawn.level2Clear == true) {
			if (transform.position == target2.position) {
				levelSwap = false;

				if (level3 == false) {
					level3 = true;
				}
			} else if (transform.position != target2.position && levelSwap == true) {
				transform.position = Vector3.Lerp(transform.position, target2.position, Time.deltaTime * smoothFactor);
			}
		}

	}

	/*IEnumerator transition () {
		incomingSwap = true;
		levelSwap = true;
	}*/

}
