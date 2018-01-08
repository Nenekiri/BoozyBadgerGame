using UnityEngine;
using System.Collections;

public class TurnOnSuggestivePowerup : MonoBehaviour {

    //define variables for this class
    public GameObject g;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Dialoguer.GetGlobalBoolean(3) == true)
        {
            g.SetActive(true);
        }
    }
}
