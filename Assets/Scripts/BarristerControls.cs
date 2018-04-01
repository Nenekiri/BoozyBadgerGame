using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class BarristerControls : MonoBehaviour {

    //varible to stop the barrister character from moving during dialog boxes
    public static bool isDialogBarrister; 

    public float maxSpeed = 3.0f;
    public float walkSpeed = 12.0f;
    public float jumpHeight = 1.0f;
    public float fallLimit = 300.0f;

    public bool grounded;

    public AudioClip jumpSound;
    public AudioClip transformSound; 

    public bool firstJump = false;
    public bool secondJump = false;
    private Rigidbody2D rigidbody;
    private RaycastHit2D hit;

    private tk2dSpriteAnimator anim;
    private float idleTimer = 0.0f;

    private AudioSource aus;
    private ParticleSystem ps;
    private ParticleSystem Boozyps; 

    public GameObject g;
    public GameObject MaskDialogue;
    public GameObject MaskTrigger;
    public GameObject Boozy;
    public GameObject NextConvo;
    public GameObject C;
    public GameObject door;
    public GameObject Camera; 


    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        //get the animator
        anim = GetComponent<tk2dSpriteAnimator>();
        Dialoguer.events.onEnded += Events_onEnded;
        aus = this.gameObject.GetComponent<AudioSource>(); 
        ps = this.gameObject.GetComponent<ParticleSystem>();
        ps.Stop();
        Boozyps = Boozy.GetComponent<ParticleSystem>();
        Boozyps.Stop(); 

    }

    void FixedUpdate()
    {
        //float h = Input.GetAxis("Horizontal");
        //rigidbody.AddForce((Vector2.right * walkSpeed) * h);

        //if (rigidbody.velocity.x > maxSpeed)
        //{
        //    rigidbody.velocity = new Vector2(maxSpeed, rigidbody.velocity.y); 
        //}

        //if (rigidbody.velocity.x < -maxSpeed)
        //{
        //    rigidbody.velocity = new Vector2(-maxSpeed, rigidbody.velocity.y);
        //}
    }

    //void isGrounded()
    //{
    //    if (Physics.Raycast(transform.position - Vector3(0, 0.25, 0), Vector3(0, -1, 0), hit) && hit.distance < 0.74)
    //    {


    //        jumpCount = 0;
    //        //Debug.Log("isGrounded");
    //        //Debug.Log(jumpCount);  
    //    }
    //    else
    //    {
    //        grounded = true; 
    //    }
    //}//end of isGrounded; 

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "platform")
            grounded = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "platform")
            grounded = false;
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "platform")
        {
            grounded = true;
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "legalbrief")
        {
            Debug.Log("This should be colliding!");
            //LevelManager l = new LevelManager();
            //l.collectedPapers += 1; 
            LevelManager.collectedPapersStatic += 1;
            //audios.PlayOneShot(sound);
            Destroy(col.gameObject);
        }

        if (col.tag == "DialogueTrigger")
        {
            g.SetActive(true);
        }

        if (col.tag == "DialogueTriggerMask")
        {
            MaskDialogue.SetActive(true);
            MaskTrigger.SetActive(false); 
        }
        
    }




    void Update()
    {
        //logic to add time to the idle timer
        //idleTimer += Time.deltaTime;
        //Debug.Log("IdleTimer time: " + idleTimer); 

        var moveH = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        var moveV = new Vector3(0, Input.GetAxis("Vertical"), 0);
        transform.position += moveH * walkSpeed * Time.deltaTime;

        Vector3 v = rigidbody.velocity;

        if (isDialogBarrister == false)//this is supposed to check for the static variable to stop the player from moving during the dialog parts, currently doesn't work
        {

            if (Input.GetAxis("Horizontal") < -0.1f)
            {
                transform.localScale = new Vector3(-5, 5, 1);
                anim.Play("BarristerWalk");
                idleTimer = 0.0f;
            }

            if (Input.GetAxis("Horizontal") > 0.1f)
            {
                transform.localScale = new Vector3(5, 5, 1);
                anim.Play("BarristerWalk");
                idleTimer = 0.0f;
            }

            if (Input.GetAxis("Horizontal") == 0.0f)
            {
                anim.Play("BarristerStandStill");
            }

        }
        Boozyps.Stop();


        //if (idleTimer > 5.0f)
        //{
        //    if (!anim.IsPlaying("BoozyIdle"))
        //    {
        //        Debug.Log("The animation should be playing!");
        //        anim.Play("BoozyIdle");
        //    }
        //}

        //isGrounded(); 

        //if (Input.GetKey("a") || Input.GetKey("left"))
        //{
        //    if (rigidbody.velocity.x > 0)
        //    {
        //        v.x = 0;
        //        rigidbody.velocity = v;
        //    }
        //    if (rigidbody.velocity.x > -walkSpeed)
        //    {
        //        v.x -= 48 * Time.deltaTime;
        //        rigidbody.velocity = v;
        //    }
        //}
        ////if the player pressed D, add velocity to move right.
        //if (Input.GetKey("d") || Input.GetKey("right"))
        //{
        //    if (rigidbody.velocity.x < 0)
        //    {
        //        v.x = 0;
        //        rigidbody.velocity = v;
        //    }
        //    if (rigidbody.velocity.x < walkSpeed)
        //    {
        //        v.x += 48 * Time.deltaTime;
        //        rigidbody.velocity = v;
        //    }
        //}


        //if (Input.GetButtonUp("Jump") && grounded == true)
        //{
        //    var jumpVector = new Vector3(0, jumpHeight, 0);


        //    v.y = jumpHeight;
        //    rigidbody.velocity = v;
        //}

        //if (Input.GetKeyUp(KeyCode.Space) && grounded == true)
        //{
        //    var jumpVector = new Vector3(0, jumpHeight, 0);


        //    v.y = jumpHeight;
        //    rigidbody.velocity = v;

        //    //rigidbody.velocity = jumpVector;  
        //}

        //if (grounded == false)
        //{
        //    anim.Play("BoozyJump");
        //}


    }//end of update

    private void Events_onEnded()
    {
        if (g.activeInHierarchy && !(MaskDialogue.activeInHierarchy))
        {
            MaskTrigger.SetActive(true); 
        }
        //throw new System.NotImplementedException();
        if (MaskDialogue.activeInHierarchy)
        {
            //this is where we'll play the sound effect and have the little cutscene for Barrister turning into Boozy
            aus.PlayOneShot(transformSound);
            ps.Play(); 
            StartCoroutine(Delay(2f)); 
            
        }
    }


    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ps.Stop();
        this.gameObject.SetActive(false);
        Instantiate(Boozy, transform.position, transform.rotation);

        //code to set the target to the newly instantiated Boozy object
        FollowCamera cam = Camera.GetComponent<FollowCamera>();
        cam.target = GameObject.Find("AnimatedBoozy(Clone)"); 

        C.SetActive(true);
        door.SetActive(true); 
        NextConvo.SetActive(true); 
        //Boozy.SetActive(true);
        
    }//end of Delay

}//end of class
