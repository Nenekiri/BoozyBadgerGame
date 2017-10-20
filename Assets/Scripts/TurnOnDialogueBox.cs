using UnityEngine;
using System.Collections;

public class TurnOnDialogueBox : MonoBehaviour {

    public GameObject g; 

	// Use this for initialization
	void Start ()
    {
        Debug.Log("This is the value of the static variable continued" + MainMenuUI.continued);
        if (MainMenuUI.continued == true)
        {
            g.SetActive(true);
        }
        else if (MainMenuUI.continued == false)
        {
            g.SetActive(false); 
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
       

    }
}
