using UnityEngine;
using System.Collections;

public class DialogueTest : MonoBehaviour {

    private bool started = false;
    public int dialogueNumber;
    private string portrait; 

    // Use this for initialization
    void Start ()
    {
        Dialoguer.StartDialogue(dialogueNumber);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (started == false)
        {
            StartThatDialogue();
        }
    }

    void StartThatDialogue()
    {
        Dialoguer.StartDialogue(dialogueNumber);
        started = true; 
    }

    void onTextPhase(DialoguerTextData data)
    {
        portrait = data.portrait; 
    }

}
