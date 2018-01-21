using UnityEngine;
using System.Collections;

public class ProtectiveMeow : MonoBehaviour {

    public GameObject bigSword; 

	// Use this for initialization
	void Start ()
    {
        bigSword.SetActive(false); 
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Dialoguer.GetGlobalBoolean(14) == true)
        {
            bigSword.SetActive(true);
        }
	}//end of update

}//end of class
