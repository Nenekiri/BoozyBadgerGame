using UnityEngine;
using System.Collections;

public class LoadFacilityLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Dialoguer.GetGlobalBoolean(9) == true)
        {
            Application.LoadLevel("Facility1-1");
        }
    }
}
