using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class BallPitBonusChecker : MonoBehaviour {

    public GameObject BonusStage; 

	// Use this for initialization
	void Start ()
    {

        BonusStage.SetActive(false);
        
	}
	
	// Update is called once per frame
	void Update ()
    {

        //Globals.FinalBossBeat = true; 

        //Debug.Log("The current value of the variable is " + Dialoguer.GetGlobalBoolean(15)); 

        if (Globals.FinalBossBeat == true)
        {
            BonusStage.SetActive(true); 
        }
	}
}
