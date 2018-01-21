using UnityEngine;
using System.Collections;

public class BallPitButton : MonoBehaviour {
    
    public GameObject smallBallPit;
    public GameObject mediumBallPit;
    public GameObject largeBallPit;

    public GameObject smallBalls;
    public GameObject mediumBalls;
    public GameObject largeBalls;

    public GameObject player; 

    public Vector3 largeBallPitPosition = new Vector3(38.57006f, 8.228534f);
    public Vector3 largeBallsPosition = new Vector3(37.33084f, 16.22706f);
    public Vector3 playerTeleportPosition = new Vector3(37.5f, 41.1f); 
     


	// Use this for initialization
	void Start ()
    {
        //largeBallPit.SetActive(false);
        //largeBalls.SetActive(false); 
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "player")
        {
            smallBallPit.SetActive(false);
            mediumBallPit.SetActive(false);
            //largeBallPit.SetActive(true);

            smallBalls.SetActive(false);
            mediumBalls.SetActive(false);
            //largeBalls.SetActive(true); 

            //Instantiate the larger ball pit and balls instead as the setactive won't work to keep the CPU from freezing the screen
            Instantiate(largeBallPit, largeBallPitPosition, transform.rotation);
            Instantiate(largeBalls, largeBallsPosition, transform.rotation);

            player.transform.position = playerTeleportPosition;   

        }
    }

}//end of class
