using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {


    //create a simple class that can be extended as needed 
    public AudioClip sound;
    public bool movingPickup; 

    private AudioSource audios;
    private float yPosition;


    public Vector3 tempPos;
    public Vector3 currentPos; 
    public float amplitude;
    public float speed;

    public GameObject DrunkCanvas;
    public SpriteRenderer sp; 
    //public ParticleSystem ps;


    // Use this for initialization
    void Start ()
    {
        //get the yPosition of the object
        yPosition = transform.position.y;
        Debug.Log("This is the current yPosition" + yPosition);
        //use this for on the gameobject itself
        //audios = this.gameObject.GetComponent<AudioSource>();

        //use this if we want to use the audiosource on the player object
        audios = GameObject.Find("AnimatedBoozy").GetComponent<AudioSource>();
        currentPos = transform.position;

        DrunkCanvas = GameObject.Find("DrunkGogglesCanvas");
        sp = gameObject.GetComponent<SpriteRenderer>(); 
        //ps = this.GetComponent<ParticleSystem>();
        //ps.Stop();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (movingPickup == true && Time.timeScale == 1)
        {
            Debug.Log("The pickup should be moving"); 
            tempPos.y = yPosition + amplitude * Mathf.Sin(speed * Time.time);
             
            currentPos.y = tempPos.y;
            transform.position = currentPos; 
        }

        //test for using the particle emitter
        if (DrunkCanvas.activeInHierarchy)
        {
            if (this.gameObject.tag == "healthPickup")
            {
                sp.material.SetColor("_Color", Color.green); 
            }
            else
            sp.material.SetColor("_Color", Color.cyan); 
        }
        else if(!DrunkCanvas.activeInHierarchy)
        {
            sp.material.SetColor("_Color", Color.white); 
        }
    }//end of Update

    void LateUpdate()
    {
        
    }//end of LateUpdate


    //void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (col.gameObject.tag == "player")
    //    {
    //        Debug.Log("This should be colliding!");
    //        audios.PlayOneShot(sound);
    //        Destroy(this.gameObject);
    //    }
    //}

}//end of the class
