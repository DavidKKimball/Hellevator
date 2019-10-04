using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EyeSpawn : MonoBehaviour {

	NPCSpawner NPCSpawner;
	ElevatorMove ElevatorMove;
	CheckPoints CheckPoints;

	public GameObject eyesPrefab;
	private GameObject[] wave1;
	private GameObject[] wave2;
	private GameObject[] wave3;
	private GameObject[] wave4;
	private GameObject[] wave5;
	private GameObject[] wave6;
	private GameObject[] wave7;
	private GameObject[] wave8;
	private GameObject[] wave9;
	private GameObject[] wave10;
	private GameObject[] wave11;
	private GameObject[] wave12;
	private GameObject[] wave13;
	private GameObject[] wave14;
	private GameObject[] wave15;
	private GameObject[] wave16;
	private GameObject[] wave17;
	private GameObject[] wave18;
	private GameObject[] enemyCount;
	private GameObject[] enemyCount2;
	public Transform[] spawnPoints;

	public GameObject dial1;
	public GameObject dial2;
	public GameObject dial3;
	public GameObject dial4;
	public GameObject dial5;
	public GameObject dial6;
	public GameObject dial7;
	public GameObject dial8;
	public GameObject dial9;
	public GameObject dial10;
	public GameObject dial11;
	public GameObject dial12;
	public GameObject dial13;
	public GameObject dial14;
	public GameObject dial15;
	public GameObject dial16;
	public GameObject dial17;
	public GameObject dial18;
	public GameObject dial19;

	public bool wave1Done;
	public bool wave2Done;
	public bool wave3Done;
	public bool wave4Done;
	public bool wave5Done;
	public bool wave6Done;
	public bool wave7Done;
	public bool wave8Done;
	public bool wave9Done;
	public bool wave10Done;

	public bool levelClear;
	public bool level2Clear;

	public int[] wave1Count;
	public int[] wave2Count;
	public int[] wave3Count;
	public int[] wave4Count;
	public int[] wave5Count;
	public int[] wave6Count;
	public int[] wave7Count;
	public int[] wave8Count;
	public int[] wave9Count;
	public int[] wave10Count;
	public int[] wave11Count;
	public int[] wave12Count;
	public int[] wave13Count;
	public int[] wave14Count;
	public int[] wave15Count;
	public int[] wave16Count;
	public int[] wave17Count;
	public int[] wave18Count;

	public bool wave1Finished;
	public bool wave2Finished;
	public bool wave3Finished;
	public bool wave4Finished;
	public bool wave5Finished;
	public bool wave6Finished;
	public bool wave7Finished;
	public bool wave8Finished;
	public bool wave9Finished;
	public bool wave10Finished;
	public bool wave11Finished;
	public bool wave12Finished;
	public bool wave13Finished;
	public bool wave14Finished;
	public bool wave15Finished;
	public bool wave16Finished;
	public bool wave17Finished;
	public bool wave18Finished;

	public int[] eyeCount;
	public int[] secondEyeCount;
 	public bool[] eyes;
	public bool[] eyesFinished;
	public bool[] secondEyesFinished;

	public float dialMove = 10f;



	void Start () {
		NPCSpawner = GameObject.Find("NPCRNG").GetComponent<NPCSpawner>();
		ElevatorMove = GameObject.Find("Moveable").GetComponent<ElevatorMove>();
		CheckPoints = GameObject.Find("Player").GetComponent<CheckPoints>();


		eyesPrefab.tag = "Enemy";

		wave1 = new GameObject[3];
		wave2 = new GameObject[3];
		wave3 = new GameObject[3];
		wave4 = new GameObject[3];
		wave5 = new GameObject[3];
		wave6 = new GameObject[3];
		wave7 = new GameObject[3];
		wave8 = new GameObject[5];
		wave9 = new GameObject[5];

		wave10 = new GameObject[3];
		wave11 = new GameObject[3];
		wave12 = new GameObject[3];
		wave13 = new GameObject[3];
		wave14 = new GameObject[3];
		wave15 = new GameObject[5];
		wave16 = new GameObject[5];
		wave17 = new GameObject[5];
		wave18 = new GameObject[5];

		enemyCount = new GameObject[6];
		enemyCount2 = new GameObject[6];

		wave1Count = new int[3];
		wave2Count = new int[3];
		wave3Count = new int[3];
		wave4Count = new int[3];
		wave5Count = new int[3];
		wave6Count = new int[3];
		wave7Count = new int[3];
		wave8Count = new int[5];
		wave9Count = new int[5];

		wave10Count = new int[3];
		wave11Count = new int[3];
		wave12Count = new int[3];
		wave13Count = new int[3];
		wave14Count = new int[3];
		wave15Count = new int[5];
		wave16Count = new int[5];
		wave17Count = new int[5];
		wave18Count = new int[5];

		eyeCount = new int[6];
		secondEyeCount = new int[6];
		eyes = new bool[6];
		eyesFinished = new bool[6];
		secondEyesFinished = new bool[6];

		for (int i = 0; i < 6; i++) {
			eyeCount[i] = 0;
			eyes[i] = false;
			eyesFinished[i] = false;
			secondEyesFinished[i] = false;
		}
	}


	void Update () {

		if(wave9Finished == true && levelClear == false) {
			levelClear = true;
			Debug.Log("Level 1 Clear!");
			//SceneManager.LoadScene("WinScreen 1");
		}

		if(wave18Finished == true && level2Clear == false) {
			level2Clear = true;
			Debug.Log("Level 2 Clear!");
			//SceneManager.LoadScene("WinScreen 1");
		}

		for (int i = 0; i < 3; i++) {
			if (CheckPoints.level1 == true && CheckPoints.level2 == false && wave1Count[i] < 1 && wave1Finished == false) {
				int whichDoor = Random.Range(0, 6);
				wave1[i] = Instantiate (eyesPrefab, spawnPoints[whichDoor].position, spawnPoints[whichDoor].rotation);
				wave1Count[i]++;
			} else if (CheckPoints.level1 == true && CheckPoints.level2 == false && wave2Count[i] < 1 && wave1Finished == true) {
				int whichDoor = Random.Range(0, 6);
				wave2[i] = Instantiate (eyesPrefab, spawnPoints[whichDoor].position, spawnPoints[whichDoor].rotation);
				wave2Count[i]++;
			} else if (CheckPoints.level1 == true && CheckPoints.level2 == false && wave3Count[i] < 1 && wave2Finished == true) {
				int whichDoor = Random.Range(0, 6);
				wave3[i] = Instantiate (eyesPrefab, spawnPoints[whichDoor].position, spawnPoints[whichDoor].rotation);
				wave3Count[i]++;
			} else if (CheckPoints.level1 == true && CheckPoints.level2 == false && wave4Count[i] < 1 && wave3Finished == true) {
				int whichDoor = Random.Range(0, 6);
				wave4[i] = Instantiate (eyesPrefab, spawnPoints[whichDoor].position, spawnPoints[whichDoor].rotation);
				wave4Count[i]++;
			} else if (CheckPoints.level1 == true && CheckPoints.level2 == false && wave5Count[i] < 1 && wave4Finished == true) {
				int whichDoor = Random.Range(0, 6);
				wave5[i] = Instantiate (eyesPrefab, spawnPoints[whichDoor].position, spawnPoints[whichDoor].rotation);
				wave5Count[i]++;
			} else if (CheckPoints.level1 == true && CheckPoints.level2 == false && wave6Count[i] < 1 && wave5Finished == true) {
				int whichDoor = Random.Range(0, 6);
				wave6[i] = Instantiate (eyesPrefab, spawnPoints[whichDoor].position, spawnPoints[whichDoor].rotation);
				wave6Count[i]++;
			} else if (CheckPoints.level1 == true && CheckPoints.level2 == false && wave7Count[i] < 1 && wave6Finished == true) {
				int whichDoor = Random.Range(0, 6);
				wave7[i] = Instantiate (eyesPrefab, spawnPoints[whichDoor].position, spawnPoints[whichDoor].rotation);
				wave7Count[i]++;
			} else if (CheckPoints.level2 == true && wave10Count[i] < 1 && wave9Finished == true) {
				int whichDoor = Random.Range(0, 6);
				wave10[i] = Instantiate (eyesPrefab, spawnPoints[whichDoor].position, spawnPoints[whichDoor].rotation);
				wave10Count[i]++;
			} else if (CheckPoints.level2 == true && wave11Count[i] < 1 && wave10Finished == true) {
				int whichDoor = Random.Range(0, 6);
				wave11[i] = Instantiate (eyesPrefab, spawnPoints[whichDoor].position, spawnPoints[whichDoor].rotation);
				wave11Count[i]++;
			} else if (CheckPoints.level2 == true && wave12Count[i] < 1 && wave11Finished == true) {
				int whichDoor = Random.Range(0, 6);
				wave12[i] = Instantiate (eyesPrefab, spawnPoints[whichDoor].position, spawnPoints[whichDoor].rotation);
				wave12Count[i]++;
			} else if (CheckPoints.level2 == true && wave13Count[i] < 1 && wave12Finished == true) {
				int whichDoor = Random.Range(0, 6);
				wave13[i] = Instantiate (eyesPrefab, spawnPoints[whichDoor].position, spawnPoints[whichDoor].rotation);
				wave13Count[i]++;
			} else if (CheckPoints.level2 == true && wave14Count[i] < 1 && wave13Finished == true) {
				int whichDoor = Random.Range(0, 6);
				wave14[i] = Instantiate (eyesPrefab, spawnPoints[whichDoor].position, spawnPoints[whichDoor].rotation);
				wave14Count[i]++;
			}
		}

		for (int i = 0; i < 5; i++) {
			if (CheckPoints.level1 == true && CheckPoints.level2 == false && wave8Count[i] < 1 && wave7Finished == true) {
				int whichDoor = Random.Range(0, 6);
				wave8[i] = Instantiate (eyesPrefab, spawnPoints[whichDoor].position, spawnPoints[whichDoor].rotation);
				wave8Count[i]++;
			} else if (CheckPoints.level1 == true && CheckPoints.level2 == false && wave9Count[i] < 1 && wave8Finished == true) {
				int whichDoor = Random.Range(0, 6);
				wave9[i] = Instantiate (eyesPrefab, spawnPoints[whichDoor].position, spawnPoints[whichDoor].rotation);
				wave9Count[i]++;
			} else if (CheckPoints.level2 == true && wave15Count[i] < 1 && wave14Finished == true) {
				int whichDoor = Random.Range(0, 6);
				wave15[i] = Instantiate (eyesPrefab, spawnPoints[whichDoor].position, spawnPoints[whichDoor].rotation);
				wave15Count[i]++;
			} else if (CheckPoints.level2 == true && wave16Count[i] < 1 && wave15Finished == true) {
				int whichDoor = Random.Range(0, 6);
				wave16[i] = Instantiate (eyesPrefab, spawnPoints[whichDoor].position, spawnPoints[whichDoor].rotation);
				wave16Count[i]++;
			} else if (CheckPoints.level2 == true && wave17Count[i] < 1 && wave16Finished == true) {
				int whichDoor = Random.Range(0, 6);
				wave17[i] = Instantiate (eyesPrefab, spawnPoints[whichDoor].position, spawnPoints[whichDoor].rotation);
				wave17Count[i]++;
			} else if (CheckPoints.level2 == true && wave18Count[i] < 1 && wave17Finished == true) {
				int whichDoor = Random.Range(0, 6);
				wave18[i] = Instantiate (eyesPrefab, spawnPoints[whichDoor].position, spawnPoints[whichDoor].rotation);
				wave18Count[i]++;
			}
		}

		//LEVEL 1 WAVES.

		if (wave1Count[0] == 1 && wave1Count[1] == 1 && wave1Count[2] == 1) {
			if (wave1[0].activeInHierarchy == false && wave1[1].activeInHierarchy == false && wave1[2].activeInHierarchy == false) {
				wave1Finished = true;
			}
		}

		if (wave2Count[0] == 1 && wave2Count[1] == 1 && wave2Count[2] == 1) {
			if (wave2[0].activeInHierarchy == false && wave2[1].activeInHierarchy == false && wave2[2].activeInHierarchy == false) {
				wave2Finished = true;
			}
		}

		if (wave3Count[0] == 1 && wave3Count[1] == 1 && wave3Count[2] == 1) {
			if (wave3[0].activeInHierarchy == false && wave3[1].activeInHierarchy == false && wave3[2].activeInHierarchy == false) {
				wave3Finished = true;
			}
		}

		if (wave4Count[0] == 1 && wave4Count[1] == 1 && wave4Count[2] == 1) {
			if (wave4[0].activeInHierarchy == false && wave4[1].activeInHierarchy == false && wave4[2].activeInHierarchy == false) {
				wave4Finished = true;
			}
		}

		if (wave5Count[0] == 1 && wave5Count[1] == 1 && wave5Count[2] == 1) {
			if (wave5[0].activeInHierarchy == false && wave5[1].activeInHierarchy == false && wave5[2].activeInHierarchy == false) {
				wave5Finished = true;
			}
		}

		if (wave6Count[0] == 1 && wave6Count[1] == 1 && wave6Count[2] == 1) {
			if (wave6[0].activeInHierarchy == false && wave6[1].activeInHierarchy == false && wave6[2].activeInHierarchy == false) {
				wave6Finished = true;
			}
		}

		if (wave7Count[0] == 1 && wave7Count[1] == 1 && wave7Count[2] == 1) {
			if (wave7[0].activeInHierarchy == false && wave7[1].activeInHierarchy == false && wave7[2].activeInHierarchy == false) {
				wave7Finished = true;
			}
		}

		if (wave8Count[0] == 1 && wave8Count[1] == 1 && wave8Count[2] == 1 && wave8Count[3] == 1 && wave8Count[4] == 1) {
			if (wave8[0].activeInHierarchy == false && wave8[1].activeInHierarchy == false && wave8[2].activeInHierarchy == false
				 && wave8[3].activeInHierarchy == false && wave8[4].activeInHierarchy == false) {
				wave8Finished = true;
			}
		}

		if (wave9Count[0] == 1 && wave9Count[1] == 1 && wave9Count[2] == 1 && wave9Count[3] == 1 && wave9Count[4] == 1) {
			if (wave9[0].activeInHierarchy == false && wave9[1].activeInHierarchy == false && wave9[2].activeInHierarchy == false
				 && wave9[3].activeInHierarchy == false && wave9[4].activeInHierarchy == false) {
				wave9Finished = true;
			}
		}

		//LEVEL 2 WAVES.

		if (wave10Count[0] == 1 && wave10Count[1] == 1 && wave10Count[2] == 1) {
			if (wave10[0].activeInHierarchy == false && wave10[1].activeInHierarchy == false && wave10[2].activeInHierarchy == false) {
				wave10Finished = true;
			}
		}

		if (wave11Count[0] == 1 && wave11Count[1] == 1 && wave11Count[2] == 1) {
			if (wave11[0].activeInHierarchy == false && wave11[1].activeInHierarchy == false && wave11[2].activeInHierarchy == false) {
				wave11Finished = true;
			}
		}

		if (wave12Count[0] == 1 && wave12Count[1] == 1 && wave12Count[2] == 1) {
			if (wave12[0].activeInHierarchy == false && wave12[1].activeInHierarchy == false && wave12[2].activeInHierarchy == false) {
				wave12Finished = true;
			}
		}

		if (wave13Count[0] == 1 && wave13Count[1] == 1 && wave13Count[2] == 1) {
			if (wave13[0].activeInHierarchy == false && wave13[1].activeInHierarchy == false && wave13[2].activeInHierarchy == false) {
				wave13Finished = true;
			}
		}

		if (wave14Count[0] == 1 && wave14Count[1] == 1 && wave14Count[2] == 1) {
			if (wave14[0].activeInHierarchy == false && wave14[1].activeInHierarchy == false && wave14[2].activeInHierarchy == false) {
				wave14Finished = true;
			}
		}

		if (wave15Count[0] == 1 && wave15Count[1] == 1 && wave15Count[2] == 1 && wave15Count[3] == 1 && wave15Count[4] == 1) {
			if (wave15[0].activeInHierarchy == false && wave15[1].activeInHierarchy == false && wave15[2].activeInHierarchy == false
				 && wave15[3].activeInHierarchy == false && wave15[4].activeInHierarchy == false) {
				wave15Finished = true;
			}
		}

		if (wave16Count[0] == 1 && wave16Count[1] == 1 && wave16Count[2] == 1 && wave16Count[3] == 1 && wave16Count[4] == 1) {
			if (wave16[0].activeInHierarchy == false && wave16[1].activeInHierarchy == false && wave16[2].activeInHierarchy == false
				 && wave16[3].activeInHierarchy == false && wave16[4].activeInHierarchy == false) {
				wave16Finished = true;
			}
		}

		if (wave17Count[0] == 1 && wave17Count[1] == 1 && wave17Count[2] == 1 && wave17Count[3] == 1 && wave17Count[4] == 1) {
			if (wave17[0].activeInHierarchy == false && wave17[1].activeInHierarchy == false && wave17[2].activeInHierarchy == false
				 && wave17[3].activeInHierarchy == false && wave17[4].activeInHierarchy == false) {
				wave17Finished = true;
			}
		}

		if (wave18Count[0] == 1 && wave18Count[1] == 1 && wave18Count[2] == 1 && wave18Count[3] == 1 && wave18Count[4] == 1) {
			if (wave18[0].activeInHierarchy == false && wave18[1].activeInHierarchy == false && wave18[2].activeInHierarchy == false
				 && wave18[3].activeInHierarchy == false && wave18[4].activeInHierarchy == false) {
				wave18Finished = true;
			}
		}

		if (wave1Finished == true && wave2Finished == false) {
			dial1.SetActive(false);
			dial2.SetActive(true);
		} else if (wave2Finished == true && wave3Finished == false) {
			dial2.SetActive(false);
			dial3.SetActive(true);
		} else if (wave3Finished == true && wave4Finished == false) {
			dial3.SetActive(false);
			dial4.SetActive(true);
		} else if (wave4Finished == true && wave5Finished == false) {
			dial4.SetActive(false);
			dial5.SetActive(true);
		} else if (wave5Finished == true && wave6Finished == false) {
			dial5.SetActive(false);
			dial6.SetActive(true);
		} else if (wave6Finished == true && wave7Finished == false) {
			dial6.SetActive(false);
			dial7.SetActive(true);
		} else if (wave7Finished == true && wave8Finished == false) {
			dial7.SetActive(false);
			dial8.SetActive(true);
		} else if (wave8Finished == true && wave9Finished == false) {
			dial8.SetActive(false);
			dial9.SetActive(true);
		} else if (wave9Finished == true && wave10Finished == false) {
			dial9.SetActive(false);
			dial10.SetActive(true);
		} else if (wave10Finished == true && wave11Finished == false) {
			dial10.SetActive(false);
			dial11.SetActive(true);
		} else if (wave11Finished == true && wave12Finished == false) {
			dial11.SetActive(false);
			dial12.SetActive(true);
		} else if (wave12Finished == true && wave13Finished == false) {
			dial12.SetActive(false);
			dial13.SetActive(true);
		} else if (wave13Finished == true && wave14Finished == false) {
			dial13.SetActive(false);
			dial14.SetActive(true);
		} else if (wave14Finished == true && wave15Finished == false) {
			dial14.SetActive(false);
			dial15.SetActive(true);
		} else if (wave15Finished == true && wave16Finished == false) {
			dial15.SetActive(false);
			dial16.SetActive(true);
		} else if (wave16Finished == true && wave17Finished == false) {
			dial16.SetActive(false);
			dial17.SetActive(true);
		} else if (wave17Finished == true && wave18Finished == false) {
			dial17.SetActive(false);
			dial18.SetActive(true);
		} else if (wave18Finished == true) {
			dial18.SetActive(false);
			dial19.SetActive(true);
		}

		/*for (int i = 0; i < 6; i++) {

			if (CheckPoints.level2 == false) {

				if (NPCSpawner.eyesRNG[i] < 12 && NPCSpawner.eyeCanSpawn[i] == true && NPCSpawner.eyeSpawned[i] == 1 && eyes[i] == false && eyeCount[i] < 1) {

					NPCSpawner.eyeCanSpawn[i] = false;

					//enemyCount[i] = Instantiate (eyesPrefab, spawnPoints[i].position, spawnPoints[i].rotation);
					eyeCount[i]++;
				}

				if (eyeCount[i] == 1) {
					if (enemyCount[i].activeInHierarchy == false) {
						eyesFinished[i] = true;
					}
				}
			}
			if (CheckPoints.level2 == true) {
				if (NPCSpawner.eyesRNG[i] < 12 && NPCSpawner.eyeCanSpawn[i] == true && NPCSpawner.eyeSpawned[i] == 1 && eyes[i] == false && secondEyeCount[i] < 1) {

					if (i != 0) {
						NPCSpawner.eyeCanSpawn[i] = false;

						enemyCount2[i] = Instantiate (eyesPrefab, spawnPoints[i].position, spawnPoints[i].rotation);
						secondEyeCount[i]++;
					}
				}

				if (secondEyeCount[i] == 1) {
					if (enemyCount2[i].activeInHierarchy == false) {
						secondEyesFinished[i] = true;
					}
				}
			}
		}*/

	}
}
