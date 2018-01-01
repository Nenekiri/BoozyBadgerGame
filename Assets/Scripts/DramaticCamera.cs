using UnityEngine;
using System.Collections;

public class DramaticCamera : MonoBehaviour {

   public Camera dramaCamera; 

	// Use this for initialization
	void Start ()
    {
        dramaCamera = GameObject.Find("Main Camera").GetComponent<Camera>(); 
        //dramaCamera = GetComponent<Camera>();
        dramaCamera.fieldOfView = 154; 
        
	
	}
	
    void FixedUpdate()
    {
        if (dramaCamera.fieldOfView > 80)
        {
            dramaCamera.fieldOfView -= 0.2f; 
        }
    }

	// Update is called once per frame
	void Update ()
    {
	
	}
}
