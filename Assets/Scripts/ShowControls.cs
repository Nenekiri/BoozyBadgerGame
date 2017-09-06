using UnityEngine;
using System.Collections;
using DialoguerCore; 

public class ShowControls : MonoBehaviour {

    public GameObject showObject;
    //public bool variableState;
    public int booleanNum; 


	// Use this for initialization
	void Start ()
    {
	
	}

    void LateUpdate()
    {
        //Check for the conditions to show the GameObject
        if (Dialoguer.GetGlobalBoolean(booleanNum) == true)
        {
            showObject.SetActive(true);
        }
        else if (Dialoguer.GetGlobalBoolean(booleanNum) == false)
        {
            showObject.SetActive(false); 
        }
    }


	// Update is called once per frame
	void Update ()
    {
	}


}//end of class
