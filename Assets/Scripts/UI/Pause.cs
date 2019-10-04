using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

	public Text pause;

	public bool paused;

	public Image pauseBG;
	public Button resume;
	public Button controls;
	public Button menu;
	public Button quit;
	public Button closeController;

	public GameObject controlImage;


	// Use this for initialization
	void Start () {
		//start with pause menu inactive
		paused = false;
		pause.text = "";
		pauseBG.gameObject.SetActive(false);
		resume.gameObject.SetActive (false);
		//controls.gameObject.SetActive (false);
		menu.gameObject.SetActive (false);
		quit.gameObject.SetActive (false);
		closeController.gameObject.SetActive (false);
		controlImage.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		//pausing and unpausing game
		if (Input.GetKeyDown (KeyCode.P) || Input.GetButtonDown("Cancel"))
		{
			paused = !paused;
		}
		if (paused)
		{
			pause.text = "PAUSED";
			pauseBG.gameObject.SetActive(true);
			resume.gameObject.SetActive (true);
			//controls.gameObject.SetActive (true);
			menu.gameObject.SetActive (true);
			quit.gameObject.SetActive (true);
			Time.timeScale = 0;
		}
		else if (!paused)
		{
			pause.text = "";
			pauseBG.gameObject.SetActive(false);
			resume.gameObject.SetActive (false);
			//controls.gameObject.SetActive (false);
			menu.gameObject.SetActive (false);
			quit.gameObject.SetActive (false);
			Time.timeScale = 1;
		}
	}

	//resume button
	public void resumegame()
	{
		paused = !paused;
	}

	//control button
	public void controller()
	{
		controlImage.gameObject.SetActive (true);
		closeController.gameObject.SetActive (true);

	}

	public void closeControl()
	{
		controlImage.gameObject.SetActive (false);
		closeController.gameObject.SetActive (false);
	}
}
