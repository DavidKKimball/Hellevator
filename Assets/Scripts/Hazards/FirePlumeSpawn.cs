using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlumeSpawn : MonoBehaviour {

	HazardSpawner HazardSpawner;
	ElevatorMove ElevatorMove;
	CheckPoints CheckPoints;
	EyeSpawn EyeSpawn;

	//public ParticleSystem[] plumes;
	//public ParticleSystem[] embers;
	//public ParticleSystem[] smoke;

	public GameObject[] firePlumes;

	public bool[] fires;

	void Start () {

		HazardSpawner = GameObject.Find("HazardRNG").GetComponent<HazardSpawner>();
		EyeSpawn = GameObject.Find("Enemy Spawns").GetComponent<EyeSpawn>();
		ElevatorMove = GameObject.Find("Moveable").GetComponent<ElevatorMove>();
		CheckPoints = GameObject.Find("Player").GetComponent<CheckPoints>();

		fires = new bool[6];

		for (int i = 0; i < 6; i++) {
			fires[i] = false;
			//plumes[i].Stop();
		}
	}

	void Update () {

		if (EyeSpawn.levelClear == true && CheckPoints.level2 == false || EyeSpawn.level2Clear == true && ElevatorMove.level3 == false) {

			for (int i = 0; i < 6; i++) {
				StopCoroutine("startFire");

				fires[i] = false;
				//plumes[i].Stop();
				firePlumes[i].SetActive(false);
			}

		} else if (EyeSpawn.levelClear == false) {
			//Turns fire plumes off/on and sets their bool.
			for (int i = 0; i < 6; i++) {

				if (HazardSpawner.firePlumeRNG[i] > 4 && fires[i] == true) {

					StopCoroutine("startFire");

					fires[i] = false;
					//plumes[i].Stop();
					firePlumes[i].SetActive(false);

				} else if (HazardSpawner.firePlumeRNG[i] < 5 && fires[i] == false) {

					StartCoroutine(startFire(i));

					fires[i] = true;
				}
			}
		} else if (ElevatorMove.level2 == true && ElevatorMove.level3 == false) {
		for (int i = 0; i < 6; i++) {

			if (HazardSpawner.firePlumeRNG[i] > 4 && fires[i] == true) {

				StopCoroutine("startFire");

				fires[i] = false;
				//plumes[i].Stop();
				firePlumes[i].SetActive(false);

			} else if (HazardSpawner.firePlumeRNG[i] < 5 && fires[i] == false) {

				if (i != 0) {
					StartCoroutine(startFire(i));

					fires[i] = true;
				}
			}
		}
		}
	}


	IEnumerator startFire (int fire) {
		yield return new WaitForSeconds(2);
		//plumes[fire].Play();
		firePlumes[fire].SetActive(true);
	}
}
