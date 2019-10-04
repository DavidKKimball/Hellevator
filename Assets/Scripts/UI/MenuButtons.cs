using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

	public AudioSource audioSource;

	//play game
	public void Play()
	{
		SceneManager.LoadScene ("Tutorial");
		audioSource.Play();
	}

    public void PlayAgain()
    {
        audioSource.Play();
        SceneManager.LoadScene ("AlphaPrototype 1");
    }

    //controls scene
    public void Controls()
	{
		SceneManager.LoadScene ("Controls");
	}

	//credits scene
	public void Credits()
	{
		audioSource.Play();
		SceneManager.LoadScene ("Credits");
	}

	//quit game
	public void Quit()
	{
		audioSource.Play();
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}

	//back to menu
	public void Back()
	{
		SceneManager.LoadScene ("Main Menu");
	}

}
