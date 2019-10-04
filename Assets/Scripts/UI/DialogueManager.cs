using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text dialogueText;
	public GameObject TutorialButton;
	public GameObject DialogueBox;
    private bool talking;

	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		DialogueBox.gameObject.SetActive(false);
		sentences = new Queue<string> ();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		DialogueBox.gameObject.SetActive (true);
        talking = true;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences) 
		{
			sentences.Enqueue (sentence);
		}

		DisplayNextSentence ();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0) 
		{
            talking = false;
			EndDialogue();
			return;
		}
        string sentence = sentences.Dequeue ();
		dialogueText.text = sentence;
	}

	void EndDialogue()
	{
		DialogueBox.gameObject.SetActive (false);
		TutorialButton.gameObject.SetActive (false);
		Time.timeScale = 1;
	}

    private void Update()
    {
        if (Input.GetButtonDown("Punch"))
        {
            DisplayNextSentence();
        }

        if (talking == true)
        {
            Time.timeScale = 0;
        }
    }
}
