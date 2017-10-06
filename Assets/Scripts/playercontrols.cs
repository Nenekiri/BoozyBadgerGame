using UnityEngine;
using System.Collections;

public class playercontrols : MonoBehaviour {

    public float maxSpeed = 3.0f; 
    public float walkSpeed = 12.0f;
    public float jumpHeight = 1.0f;
    public float fallLimit = 300.0f;

    public bool grounded; 

    public AudioClip jumpSound;

    public bool firstJump = false;
    public bool secondJump = false;
    private Rigidbody2D rigidbody;
    private RaycastHit2D hit;

    private tk2dSpriteAnimator anim;
    private float idleTimer = 0.0f;

    public GameObject BoozeCanvas;
    //public GameObject Pointer; 
    public bool BoozeGoggles = false;
    public AudioSource audios;
    public AudioClip pickupSound;

    //variables for triggering the dialogue with QM at the beginning of the game
    public GameObject OtterDialogue;
    public GameObject OtterTrigger;

    //varible to control second jump once it is unlocked from beating the eagle boss
    public int jumpCounter = 0;

    //variables to control the logic for when dialogue ends
    public GameObject eagleDial;
    public GameObject eaglePlaceholder;
    public GameObject eagleBoss;  

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        //get the animator
        anim = GetComponent<tk2dSpriteAnimator>();
        audios = this.GetComponent<AudioSource>();


        //find the variables to trigger the QM starting dialogue
        if (Application.loadedLevelName == "OpeningScene")
        {
            OtterDialogue = GameObject.Find("OtterDialogue");
            OtterTrigger = GameObject.Find("DialogueTriggerOtter"); 
        }

        //this bit of code allows us to tell when dialogue events have ended
        Dialoguer.events.onEnded += Events_onEnded;



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
        if(col.gameObject.tag == "platform")
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
            jumpCounter = 0; 
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
            audios.PlayOneShot(pickupSound);
            Destroy(col.gameObject);
        }

        //This section is to trigger the dialogue that starts the convo with QM
        if (col.tag == "DialogueTriggerOtter")
        {
            OtterDialogue.transform.GetChild(0).gameObject.SetActive(true);
            OtterTrigger.SetActive(false);
        }
    }

    //this section is to keep track of when certain dialogues end
    private void Events_onEnded()
    {
        Debug.Log("Dialogue ended!");
        //if (g.activeInHierarchy && !(MaskDialogue.activeInHierarchy))
        //{
        //    MaskTrigger.SetActive(true);
        //}
        //throw new System.NotImplementedException();
        if (eagleDial.activeInHierarchy)
        {
            //this is where we'll play the sound effect and have the little cutscene for Barrister turning into Boozy
            //aus.PlayOneShot(transformSound);
            //ps.Play();
            //StartCoroutine(Delay(2f));

            Debug.Log("Eagle Dialogue is active in Hierarchy");

            eaglePlaceholder.SetActive(false);
            eagleBoss.SetActive(true);

        }
    }

    void ToggleBoozeVision()
    {
        BoozeGoggles = !BoozeGoggles; 
    }


    void Update()
    {
        //logic to add time to the idle timer
        idleTimer += Time.deltaTime;
        //Debug.Log("IdleTimer time: " + idleTimer); 

        var moveH = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        var moveV = new Vector3(0, Input.GetAxis("Vertical"), 0);
        transform.position += moveH * walkSpeed * Time.deltaTime;

        Vector3 v = rigidbody.velocity;
        

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-5, 5, 1);
            anim.Play("BoozyWalk");
            idleTimer = 0.0f;  
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(5, 5, 1);
            anim.Play("BoozyWalk");
            idleTimer = 0.0f; 
        }

        if (Input.GetAxis("Horizontal") == 0.0f && !anim.IsPlaying("BoozyAttack") && !anim.IsPlaying("BoozyIdle"))
        {
            anim.Play("BoozyStandStill");
        }



        if (idleTimer > 5.0f)
        {
            if (!anim.IsPlaying("BoozyIdle"))
            {
                Debug.Log("The animation should be playing!");
                anim.Play("BoozyIdle");
            }
        }

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


        if (Input.GetButtonUp("Jump") && grounded == true && Dialoguer.GetGlobalBoolean(2) == false)
        {
            var jumpVector = new Vector3(0, jumpHeight, 0);
            audios.PlayOneShot(jumpSound);
            v.y = jumpHeight;
            rigidbody.velocity = v;
        }
        else if (Input.GetButtonUp("Jump") && Dialoguer.GetGlobalBoolean(2) == true)
        {
            if (grounded == true)
            {
                var jumpVector = new Vector3(0, jumpHeight, 0);
                audios.PlayOneShot(jumpSound);
                v.y = jumpHeight;
                rigidbody.velocity = v;
                jumpCounter += 1;
            }
            else if(jumpCounter <= 0)
            {
                var jumpVector = new Vector3(0, jumpHeight, 0);
                audios.PlayOneShot(jumpSound);
                v.y = jumpHeight;
                rigidbody.velocity = v;
                jumpCounter += 1;
            }
        }

        //if (Input.GetKeyUp(KeyCode.Space) && grounded == true)
        //{
        //    var jumpVector = new Vector3(0, jumpHeight, 0);

            
        //    v.y = jumpHeight;
        //    rigidbody.velocity = v;

        //    //rigidbody.velocity = jumpVector;  
        //}

        if (grounded == false)
        {
            anim.Play("BoozyJump");
        }


        if (Input.GetButtonUp("BoozeGoggles"))
        {
            ToggleBoozeVision(); 
        }




        //Vector3 velocity = rigidbody.velocity;
        //////Keyboard Controls for web versions (Same as Standalone because they both deal with keyboard)
        //////This checks to see if the player is pressing A or D. This is connected to the else{} statement below
        //if (Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("left") || Input.GetKey("right"))
        //{
        //    //If the player presses A, add velocity to move left.
        //    if (Input.GetKey("a") || Input.GetKey("left"))
        //    {
        //        Debug.Log(rigidbody.velocity.x); 
        //        if (rigidbody.velocity.x > 0)
        //        {
        //            velocity.x = 0;
        //        }
        //        if (rigidbody.velocity.x > -walkSpeed)
        //        {
        //            velocity.x -= 48 * Time.deltaTime;
        //        }
        //    }
        //    //if the player pressed D, add velocity to move right.
        //    if (Input.GetKey("d") || Input.GetKey("right"))
        //    {
        //        if (rigidbody.velocity.x < 0)
        //        {
        //            velocity.x = 0;
        //        }
        //        if (rigidbody.velocity.x < walkSpeed)
        //        {
        //            velocity.x += 48 * Time.deltaTime;
        //        }
        //    }

        //}
        //else
        //{
        //    //use else to do the opposite of an if() statement. this stops the player if lets go of A or D
        //    velocity.x = 0.0f;
        //}

    }//end of Update


    void LateUpdate()
    {
        if (BoozeGoggles)
        {
            BoozeCanvas.SetActive(true);
            //Pointer.SetActive(true); 
        }
        else
        {
            BoozeCanvas.SetActive(false);
            //Pointer.SetActive(false); 
        }


    }//end of LateUpdate


  


    //    //how fast the player walks
    //    var walkSpeed:float = 12.0;
    ////how high the player can jump
    //var jumpHeight:float = 15.0;
    ////at what point the level resets if the player falls in a hole
    //var fallLimit:float = -300;
    ////jump sound
    //var jumpSound:AudioClip;

    //var firstJump:boolean = false;
    //var secondJump:boolean = false;  

    //private var hit:RaycastHit;
    ////using this to ensure the jump sound doesn't play more than once at a time.
    //private var jumpCounter:float = 0.0;
    //private var grounded:boolean = false; 
    //private var canDoubleJump:boolean = false;
    //private var jumpCount: int = 0;  
    //private var maxjumpCount: int = 2; 

    //private var jumpTime: float = 0.0; 

    //private var wallCollide: boolean = false; 

    //function isGrounded()
    //    {
    //        if (Physics.Raycast(transform.position - Vector3(0, 0.25, 0), Vector3(0, -1, 0), hit) && hit.distance < 0.74)
    //        {


    //            jumpCount = 0;
    //            //Debug.Log("isGrounded");
    //            //Debug.Log(jumpCount);  
    //        }
    //    }//end of isGrounded

    //    function isJumping()
    //    {

    //        if (jumpCount < maxjumpCount)
    //        {
    //            rigidbody.velocity.y = jumpHeight;
    //            jumpCount = 1;
    //            jumpTime += Time.deltaTime;
    //            Debug.Log(jumpCount);
    //            if (jumpTime > 0.30)
    //            {
    //                rigidbody.velocity.y = jumpHeight;
    //                jumpCount = 2;
    //                jumpTime = 0.0;
    //                Debug.Log(jumpCount);
    //            }
    //            if (jumpCounter > 0.25)
    //            {
    //                audio.PlayOneShot(jumpSound);
    //                jumpCounter = 0.0;
    //            }
    //        }


    //        //Debug.Log(jumpCount); 
    //        //once jump counter hits a quarter of a second, it can play the sound again.


    //    }//end of isJumping



    //    function Update()
    //    {
    //        //jumpCounter becomes a timer.
    //        jumpCounter += Time.deltaTime;






    //#if UNITY_WEBPLAYER
    ////Keyboard Controls for web versions (Same as Standalone because they both deal with keyboard)
    ////This checks to see if the player is pressing A or D. This is connected to the else{} statement below
    //if(Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("left") || Input.GetKey("right")){
    ////If the player presses A, add velocity to move left.
    //if(Input.GetKey("a") || Input.GetKey("left")){
    //	if(rigidbody.velocity.x > 0){
    //		rigidbody.velocity.x = 0;
    //	}
    //	if(rigidbody.velocity.x > -walkSpeed){
    //		rigidbody.velocity.x -= 48*Time.deltaTime;
    //	}
    //}
    ////if the player pressed D, add velocity to move right.
    //if(Input.GetKey("d")|| Input.GetKey("right")){
    //	if(rigidbody.velocity.x < 0){
    //		rigidbody.velocity.x = 0;
    //	}
    //	if(rigidbody.velocity.x < walkSpeed){
    //		rigidbody.velocity.x += 48*Time.deltaTime;
    //	}
    //}

    //}else{
    ////use else to do the opposite of an if() statement. this stops the player if lets go of A or D
    //rigidbody.velocity.x = 0.0;
    //}

    ////check to see if player is on terrain and can jump
    //if (Physics.Raycast (transform.position - Vector3(0,0.25,0), Vector3(0,-1,0), hit)) {
    //	if(hit.distance < 0.74 && Input.GetKey("space") && hit.transform.tag != "spikes" && hit.transform.tag != "enemy"){
    //		rigidbody.velocity.y = jumpHeight;

    //		//once jump counter hits a quarter of a second, it can play the sound again.
    //		if(jumpCounter > 0.25){
    //			audio.PlayOneShot(jumpSound);
    //			jumpCounter = 0.0;
    //		}
    //	}
    //}
    //#endif

    //#if UNITY_STANDALONE


    //        isGrounded();


    //        //moving left
    //        if (Input.GetAxis("Horizontal") < 0)
    //        {
    //            if (rigidbody.velocity.x > 0)
    //            {
    //                rigidbody.velocity.x = 0;
    //            }
    //            if (rigidbody.velocity.x > -walkSpeed)
    //            {
    //                rigidbody.velocity.x -= 48 * Time.deltaTime * 12;
    //            }
    //        }
    //        //moving right
    //        if (Input.GetAxis("Horizontal") > 0)
    //        {

    //            if (rigidbody.velocity.x < 0)
    //            {
    //                rigidbody.velocity.x = 0;
    //            }
    //            if (rigidbody.velocity.x < walkSpeed)
    //            {
    //                rigidbody.velocity.x += 48 * Time.deltaTime * 12;
    //            }
    //        }
    //        if (Input.GetButtonUp("Jump"))
    //        {

    //            Debug.Log("jumping!");
    //            isJumping();
    //        }

    //        //iOS Controls (same as Android because they both deal with screen touches)
    //        if (Input.touchCount > 0)
    //        {
    //            for (var touch1 : Touch in Input.touches)
    //            {
    //                //if player presses less than 1/5 of the screen, go left.
    //                if (touch1.position.x < Screen.width / 5 && touch1.position.y < Screen.height / 3)
    //                {
    //                    if (rigidbody.velocity.x > 0)
    //                    {
    //                        rigidbody.velocity.x = 0;
    //                    }
    //                    if (rigidbody.velocity.x > -walkSpeed)
    //                    {
    //                        rigidbody.velocity.x -= 48 * Time.deltaTime;
    //                    }
    //                }
    //                //if player presses between 1/5 and 2/5 of the screen, go right.
    //                if (touch1.position.x > Screen.width / 5 && touch1.position.x < Screen.width / 5 * 2 && touch1.position.y < Screen.height / 3)
    //                {
    //                    if (rigidbody.velocity.x < 0)
    //                    {
    //                        rigidbody.velocity.x = 0;
    //                    }
    //                    if (rigidbody.velocity.x < walkSpeed)
    //                    {
    //                        rigidbody.velocity.x += 48 * Time.deltaTime;
    //                    }
    //                }
    //                if (Input.touchCount == 1 && touch1.position.x > Screen.width / 2)
    //                {
    //                    rigidbody.velocity.x = 0.0;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            rigidbody.velocity.x = 0.0;
    //        }


    //        if (Input.touchCount > 0)
    //        {
    //            for (var touch2 : Touch in Input.touches)
    //            {
    //                //2nd touch for jump button
    //                if (touch2.position.x > Screen.width / 4 * 3 && touch2.position.y < Screen.height / 3)
    //                {

    //                    if (Input.touchCount == 1)
    //                    {
    //                        rigidbody.velocity.x = 0.0;
    //                    }

    //                    isJumping();


    //                }

    //            }
    //        }







    //#endif

    //#if UNITY_IOS
    ////iOS Controls (same as Android because they both deal with screen touches)
    //if(Input.touchCount > 0){
    //for(var touch1 : Touch in Input.touches) {
    //	//if player presses less than 1/5 of the screen, go left.
    //	if(touch1.position.x < Screen.width/5 && touch1.position.y < Screen.height/3){
    //		if(rigidbody.velocity.x > 0){
    //			rigidbody.velocity.x = 0;
    //		}
    //		if(rigidbody.velocity.x > -walkSpeed){
    //			rigidbody.velocity.x -= 48*Time.deltaTime;
    //		}
    //	}
    //	//if player presses between 1/5 and 2/5 of the screen, go right.
    //	if(touch1.position.x > Screen.width/5 && touch1.position.x < Screen.width/5*2 && touch1.position.y < Screen.height/3){
    //		if(rigidbody.velocity.x < 0){
    //			rigidbody.velocity.x = 0;
    //		}
    //		if(rigidbody.velocity.x < walkSpeed){
    //			rigidbody.velocity.x += 48*Time.deltaTime;
    //		}
    //	}
    //if(Input.touchCount == 1 && touch1.position.x > Screen.width/2){
    //rigidbody.velocity.x = 0.0;
    //}
    //}
    //}else{
    //rigidbody.velocity.x = 0.0;
    //}

    //if(Input.touchCount > 0){
    //for(var touch2 : Touch in Input.touches) { 
    ////2nd touch for jump button
    //	if(touch2.position.x > Screen.width/4*3 && touch2.position.y < Screen.height/3){
    //		if(Input.touchCount == 1){
    //			rigidbody.velocity.x = 0.0;
    //		}
    //		if (Physics.Raycast (transform.position - Vector3(0,0.25,0), Vector3(0,-1,0), hit)) {
    //			if(hit.distance < 0.74 && hit.transform.tag != "spikes" && hit.transform.tag != "enemy"){
    //				rigidbody.velocity.y = jumpHeight;
    //		//once jump counter hits a quarter of a second, it can play the sound again.
    //			if(jumpCounter > 0.25){
    //				audio.PlayOneShot(jumpSound);
    //				jumpCounter = 0.0;
    //			}
    //			}
    //		}
    //	}
    //}
    //}
    //#endif

    //#if UNITY_ANDROID


    //isGrounded();


    ////iOS Controls (same as Android because they both deal with screen touches)
    //if(Input.touchCount > 0){
    //for(var touch1 : Touch in Input.touches) {
    //	//if player presses less than 1/5 of the screen, go left.
    //	if(touch1.position.x < Screen.width/5 && touch1.position.y < Screen.height/3){


    //		if(rigidbody.velocity.x > 0){
    //			rigidbody.velocity.x = 0;
    //		}
    //		if(rigidbody.velocity.x > -walkSpeed){
    //			rigidbody.velocity.x -= 48*Time.deltaTime;
    //		}

    //	}
    //	//if player presses between 1/5 and 2/5 of the screen, go right.
    //	if(touch1.position.x > Screen.width/5 && touch1.position.x < Screen.width/5*2 && touch1.position.y < Screen.height/3){

    //		if(rigidbody.velocity.x < 0){
    //			rigidbody.velocity.x = 0;
    //		}
    //		if(rigidbody.velocity.x < walkSpeed){
    //			rigidbody.velocity.x += 48*Time.deltaTime;
    //		}

    //	}
    //if(Input.touchCount == 1 && touch1.position.x > Screen.width/2){
    //rigidbody.velocity.x = 0.0;
    //}
    //}
    //}else{
    //rigidbody.velocity.x = 0.0;
    //}


    //if(Input.touchCount > 0){
    //for(var touch2 : Touch in Input.touches) { 
    ////2nd touch for jump button
    //	if(touch2.position.x > Screen.width/4*3 && touch2.position.y < Screen.height/3){
    //		if(Input.touchCount == 1){
    //			rigidbody.velocity.x = 0.0;
    //		}

    //		 isJumping();


    //		}

    //		}
    //	}


    //#endif


    //        //moving left
    //        if (Input.GetAxis("Horizontal") < 0)
    //        {
    //            if (rigidbody.velocity.x > 0)
    //            {
    //                rigidbody.velocity.x = 0;
    //            }
    //            if (rigidbody.velocity.x > -walkSpeed)
    //            {
    //                rigidbody.velocity.x -= 48 * Time.deltaTime * 12;
    //            }
    //        }
    //        //moving right
    //        if (Input.GetAxis("Horizontal") > 0)
    //        {

    //            if (rigidbody.velocity.x < 0)
    //            {
    //                rigidbody.velocity.x = 0;
    //            }
    //            if (rigidbody.velocity.x < walkSpeed)
    //            {
    //                rigidbody.velocity.x += 48 * Time.deltaTime * 12;
    //            }
    //        }
    //        if (Input.GetButtonUp("Jump"))
    //        {

    //            Debug.Log("jumping!");
    //            isJumping();
    //        }


    //        //reset level if player falls past Fall Limit
    //        if (transform.position.y < fallLimit)
    //        {
    //            Globals.keyGetYellow = false;
    //            Globals.keyGetRed = false;
    //            var lvlName:String = Application.loadedLevelName;
    //            Application.LoadLevel(lvlName);
    //        }

    //        //end of function update


}// end of class
