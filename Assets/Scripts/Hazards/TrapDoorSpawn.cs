using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorSpawn : MonoBehaviour {

	HazardSpawner HazardSpawner;
	ElevatorMove ElevatorMove;

	public GameObject[] sawBlades;
	public GameObject[] lavaPits;
	public GameObject[] pitFalls;

	public int trapSurprise;
	public bool[] trapDoors;

	void Start () {

		HazardSpawner = GameObject.Find("HazardRNG").GetComponent<HazardSpawner>();
		ElevatorMove = GameObject.Find("Moveable").GetComponent<ElevatorMove>();

		trapSurprise = 0;
		trapDoors = new bool[4];

		for (int i = 0; i < 4; i++) {
			trapDoors[i] = false;
		}
	}

	void Update () {

		if (ElevatorMove.level3 == false) {
			for (int i = 0; i < 4; i++) {

				if (HazardSpawner.trapDoorRNG[i] > 3 && trapDoors[i] == true) {

					StopCoroutine("startLava");
					StopCoroutine("startSaw");

					trapDoors[i] = false;
					sawBlades[i].GetComponent<Animation>().Play("SawBladeGoDown");

					StartCoroutine(endSaw(i));
					StartCoroutine(endLava(i));

				} else if (HazardSpawner.trapDoorRNG[i] < 4 && trapDoors[i] == false) {

					trapSurprise = Random.Range(0, 2);

					if (trapSurprise == 0) {

						StartCoroutine(startLava(i));

					} else if (trapSurprise == 1) {

						StartCoroutine(startSaw(i));

					} /*else if (trapSurprise == 2) {
						//Pitfalls
					}*/

					trapDoors[i] = true;
				}
			}
		}

	}

	IEnumerator startLava (int lava) {
		lavaPits[lava].SetActive(true);
		yield break;
	}

	IEnumerator startSaw (int saw) {
		yield return new WaitForSeconds(0.8f);

		sawBlades[saw].SetActive(true);
	}

	IEnumerator endLava (int lava) {
		yield return new WaitForSeconds(2);

		lavaPits[lava].SetActive(false);
	}

	IEnumerator endSaw (int saw) {
		yield return new WaitForSeconds(2);

		sawBlades[saw].SetActive(false);

	}
}
