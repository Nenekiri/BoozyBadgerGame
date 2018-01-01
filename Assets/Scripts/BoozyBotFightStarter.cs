using UnityEngine;
using System.Collections;

public class BoozyBotFightStarter : MonoBehaviour {


    public GameObject BoozyBot;
    public GameObject DramCam; 

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //This should turn the boss object on after the dialogue is complete. 
        if (Dialoguer.GetGlobalBoolean(11) == true)
        {
            BoozyBot.SetActive(true);
            DramCam.SetActive(true);
        }
    }

    //void FixedUpdate()
    //{
    //    //This should turn the boss object on after the dialogue is complete. 
    //    if (Dialoguer.GetGlobalBoolean(11) == true)
    //    {
    //        BoozyBot.SetActive(true);
    //        DramCam.SetActive(true); 
    //    }
    //}

}//end of class
