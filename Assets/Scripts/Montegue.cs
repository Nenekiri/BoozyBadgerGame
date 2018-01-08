using UnityEngine;
using System.Collections;

public class Montegue : MonoBehaviour {

    public GameObject MontegueDialogue; 

	// Use this for initialization
	void Start ()
    {
	
	}//end of Start
	
	// Update is called once per frame
	void Update ()
    {
       
	
	}//end of Update

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "player")
        {
            MontegueDialogue.SetActive(true); 
        }
    }

}//end of script
