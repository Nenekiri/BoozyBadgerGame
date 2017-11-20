﻿using UnityEngine;
using System.Collections;

public class SuggestivePowerup : MonoBehaviour {


    //define variables for this class
    public GameObject g;

    public GameObject UsefulDialogue; 

	// Use this for initialization
	void Start ()
    {
        g.SetActive(false); 
	}//end of Start
	
	// Update is called once per frame
	void Update ()
    {
        if (Dialoguer.GetGlobalBoolean(3) == true)
        {
            g.SetActive(true); 
        }
	
	}//end of Update

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "player")
        {
            UsefulDialogue.transform.GetChild(0).gameObject.SetActive(true);
        }
    }//end of OnCollisionEnter2D

}//end of class
