using UnityEngine;
using System.Collections;

public class MontegueTrigger : MonoBehaviour {

    public GameObject Montegue;
    public GameObject ExitDoor; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Dialoguer.GetGlobalBoolean(10) == true)
        {
            Montegue.SetActive(true);
        }

        if (Dialoguer.GetGlobalBoolean(12) == true)
        {
            ExitDoor.SetActive(true); 
        }
    }

}
