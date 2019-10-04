using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour {

	public void quitGame () {

		Application.Quit();
	}

	public void LoadTechDemo () {

		SceneManager.LoadScene("TechPrototype");
	}

	public void LoadArtDemo () {

		SceneManager.LoadScene("ArtPrototype");
	}

	public void TryAgain () {

        SceneManager.LoadScene("TechPrototype");
    }

	public void Pause () {

		SceneManager.LoadScene("TestSplash");
	}
}
