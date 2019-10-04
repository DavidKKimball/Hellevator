using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour {

	CheckPoints CheckPoints;

	public bool active;
	public int fifteenRNG;
	public int thirtyRNG;
	public int fourtyFiveRNG;
	public int sixtyRNG;
	public int spikeBallRNG;
	public int spikeCount;
	public bool spikeBool;
	public int[] firePlumeRNG;
	public int[] trapDoorRNG;

	void Start () {

		CheckPoints = GameObject.Find("Player").GetComponent<CheckPoints>();

		//Starts all events off at 0;
		fifteenRNG = 0;
		thirtyRNG = 0;
		fourtyFiveRNG = 0;
		sixtyRNG = 0;
		spikeBallRNG = 0;
		spikeCount = 0;
		firePlumeRNG = new int[6];
		trapDoorRNG = new int[4];

		for (int i = 0; i < 4; i++) {
			trapDoorRNG[i] = 10;
		}

		for (int i = 0; i < 6; i++) {
			firePlumeRNG[i] = 20;
		}
	}

	void Update () {
		if (CheckPoints.level1 == true && active == false) {
			StartCoroutine("tenSeconds");
			StartCoroutine("fifteenSeconds");
			StartCoroutine("thirtySeconds");
			StartCoroutine("fourtyFiveSeconds");
			StartCoroutine("sixtySeconds");
			active = true;
		}
	}

//Function that spits out an random number to call an event every thirty seconds.
	IEnumerator tenSeconds () {

		while (enabled) {

			yield return new WaitForSeconds(10);

			for (int i = 0; i < 4; i++) {
				trapDoorRNG[i] = Random.Range(0, 10);
			}
		}

	}

//Function that spits out an random number to call an event every fifteen seconds.
	IEnumerator fifteenSeconds () {

		while (enabled) {

			yield return new WaitForSeconds(15);
			fifteenRNG = Random.Range(0, 4);

			//Checks how many spike balls will spawn, either 1 or 2.
			//Then checks which set of 2 will spawn if needed.
			//Spawns spike balls at a 20% chance.
			spikeCount = Random.Range(0, 3);
			spikeBool = true;
			spikeBallRNG = Random.Range(0, 10);

			//Spawns random fire plumes at a 20% chance.
			for (int i = 0; i < 6; i++) {
				firePlumeRNG[i] = Random.Range(0, 20);
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
