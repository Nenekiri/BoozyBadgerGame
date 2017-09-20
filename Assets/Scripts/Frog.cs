using UnityEngine;
using System.Collections;

public class Frog : Enemy {


public float jumpSpeed = 2.0f;

//here are some private variables that we use to help animate the enemy
public float counter = 0.0f;
//private var colorCounter:float = 0.0;
//private var target:GameObject;
//private var direction = false;
private bool touched = true;
//private var distance:float = 0.0;
//private var ydistance:float = 0.0;
private float playerDist = 0.0f;

    public int hopHeight;
    public int hopSpeed; 

    public RaycastHit rayHit;
    public float jumpDist;

    public bool grounded; 

	// Use this for initialization
	void Start ()
    {
        base.Start();

        
    }//end of start

    void FixedUpdate()
    {
        distance = player.transform.position.x - transform.position.x;

        //Debug.Log("Testing distance of frog: " + distance); 


        if (Mathf.Abs(distance) <= 10f)
        {
            //run the jumping code here once the player is close enough
            Jumping();
        }
    }

	// Update is called once per frame
	void Update ()
    {

     



        //logic for the jumping
        //if (Mathf.Abs(distance) <= 10f)
        //{
            //counter += Time.deltaTime;

            //if (counter > jumpSpeed)
            //{
            //    playerDist = player.transform.position.x - transform.position.x;

            //    touched = false;

            //    Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            //    Vector2 v = rb.velocity;
            //    v.y = 19f;

            //    //here we make the jump move towards the player
            //    if (v.y > 0.5)
            //    {
            //        v.x = playerDist * 1.5f;
            //    }

            //    counter = 0.0f;
            //}
        

        //}



       
        
        //if the enemy touches an object, it will stop moving on the x plane. touched is set to true in OnCollisionEnter.
        //if (touched == true)
        //{
        //    Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        //    Vector2 v = rb.velocity;
        //    v.x = 0.0f; 
        //}
        //if the jumper falls down a hole we want to destroy it so that it doesn't continue to exist for no reason. he's not coming back.
        //if (transform.position.y < -10)
        //{
        //    Destroy(gameObject);
        //}

        //changes the direction that the enemy is facing
        if (player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(5, 5, 1);
        }
        if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-5, 5, 1);
        }

        //damage calculation
        HurtEnemy();

        //centers the healthBar
        CenterHealthBar();

        //hides the healthbar if not in range
        ShowHealthBar();

    }//end of update

    //keeps the enemy from getting stuck on other enemies
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "CollisionEnemy")
    //    {
    //        Collider2D col = this.gameObject.GetComponent<Collider2D>();
    //        Physics2D.IgnoreCollision(collision.collider, col);
    //        //Physics.IgnoreCollision(collision, col);
    //    }
    //    else if (counter > 3)
    //    {
    //        touched = true; 
    //    }
        
    //}//end of OnCollisionEnter

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
            //jumpCounter = 0;
        }

    }

    void Jumping()
    {
        //if (Physics.Linecast(transform.position, player.transform.position))
        //{
            Debug.Log("Made it to the part that's past the linecast");

            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            if (rayHit.distance < jumpDist)
            {
                Debug.Log("Made it to the part that's supposed to jump!");

            if (player.transform.position.x < transform.position.x && grounded)
            {
                rb.AddForce(transform.up * hopHeight + (transform.right * hopSpeed) * -1);   //transform.up * 35 produces the cute little 'hopping' behavior
            }
            if (player.transform.position.x > transform.position.x && grounded)
            {
                rb.AddForce(transform.up * hopHeight + transform.right * hopSpeed);
            }

            
                
            }

        //}
    }//end of jumping method


    }//end of frog class
