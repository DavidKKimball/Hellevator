using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour {

	CheckPoints CheckPoints;

		public bool active;
		public int fifteenRNG;
		public int thirtyRNG;
		public int fourtyFiveRNG;
		public int sixtyRNG;
		public int[] eyesRNG;
		public int[] eyeSpawned;

		public bool[] eyeCanSpawn;

		void Start () {

			CheckPoints = GameObject.Find("Player").GetComponent<CheckPoints>();

			//Starts all events off at 0;
			fifteenRNG = 0;
			thirtyRNG = 0;
			fourtyFiveRNG = 0;
			sixtyRNG = 0;
			eyesRNG = new int[6];
			eyeSpawned = new int[6];

			eyeCanSpawn = new bool[6];

			for (int i = 0; i < 6; i++) {
				eyeCanSpawn[i] = false;
				eyesRNG[i] = 2;
				eyeSpawned[i] = 0;
			}
		}

		void Update () {
			if (CheckPoints.level1 == true && active == false) {
				StartCoroutine("fifteenSeconds");
				StartCoroutine("thirtySeconds");
				StartCoroutine("fourtyFiveSeconds");
				StartCoroutine("sixtySeconds");
				active = true;
			}
		}

	//Function that spits out an random number to call an event every fifteen seconds.
		IEnumerator fifteenSeconds () {

			while (enabled) {

				yield return new WaitForSeconds(5);
				fifteenRNG = Random.Range(0, 4);

				//Spawns eyes at a random door at a 30% chance.
				for (int i = 0; i < 6; i++) {
					eyeCanSpawn[i] = true;
					eyesRNG[i] = Random.Range(0, 20);
					eyeSpawned[i] = Random.Range(0, 2);
				}
			}

		}

	//Function that spits out an random number to call an event every thirty seconds.
		IEnumerator thirtySeconds () {

			while (enabled) {

				yield return new WaitForSeconds(30);
				thirtyRNG = Random.Range(0, 4);

			}

		}

	//Function that spits out an random number to call an event every fourty-five seconds.
		IEnumerator fourtyFiveSeconds () {

			while (enabled) {

				yield return new WaitForSeconds(45);
				fourtyFiveRNG = Random.Range(0, 4);
			}

		}

	//Function that spits out an random number to call an event every sixty seconds.
		IEnumerator sixtySeconds () {

			while (enabled) {

				yield return new WaitForSeconds(60);
				sixtyRNG = Random.Range(0, 4);
			}

		}
}
