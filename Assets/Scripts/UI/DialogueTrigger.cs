using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
	public GameObject player;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            Debug.Log("DIALOGUE TRIGGER");
            TriggerDialogue();
            Destroy(gameObject);
        }
    }

    public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager> ().StartDialogue (dialogue);
	}
}
