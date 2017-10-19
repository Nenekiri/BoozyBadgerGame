using UnityEngine;
using System.Collections;

public class TurnOnAbilities : MonoBehaviour {

    public bool isDoubleJump; 

	// Use this for initialization
	void Start ()
    {

        //turn on certain abilities so I don't have to keep doing it over and over again
        if (isDoubleJump)
        {
            Dialoguer.SetGlobalBoolean(2, true);  
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
