using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject pausePanel;

	void Start () {

	}

	void Update () {

		//Checks for input key escape for pause.
		if(Input.GetKeyDown(KeyCode.Escape)) {

			//Checks to see if the game is paused or is being paused.
			if(!pausePanel.activeInHierarchy) {
				PauseGame();
			} else {
				ContinueGame();
			}
		}
	}

	public void PauseGame () {

		//Stops the game from playing in the background.
		//Time.timeScale = 0;

		//Opens the pause menu.
		pausePanel.SetActive(true);
	}

	public void ContinueGame () {

		//Turns the gameplay back on.
		//Time.timeScale = 1;

		//Closes the pause menu.
		pausePanel.SetActive(false);
	}
}
