using UnityEngine;
using System.Collections;

public class DialoguerInit : MonoBehaviour {

    //this script is used to initialize the dialoguer system

    void Awake()
    {
        Dialoguer.Initialize(); 
    }


	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    private void dialoguerCallback()
    {
        this.enabled = true;
    }
}
