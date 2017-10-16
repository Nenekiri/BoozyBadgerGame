using UnityEngine;
using System.Collections;

public class ComputerTouch : MonoBehaviour {

    public GameObject compDialog; 

	// Use this for initialization
	void Start ()
    {
        compDialog = GameObject.Find("ComputerDialogue");
        compDialog.SetActive(false); 
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "player")
        compDialog.SetActive(true);

    }

}
