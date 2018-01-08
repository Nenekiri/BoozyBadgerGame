using UnityEngine;
using System.Collections;

//Create a simple position class outside of the main enemy class to store the position of the enemy
public class Positions
{
    public AnimationCurve x = new AnimationCurve();
    public AnimationCurve y = new AnimationCurve();
    //public AnimationCurve z = new AnimationCurve();//Remove if not needed
}

public class BoozyBot : Enemy {

    //Call a new instance of the PlayerPositions class
    public Positions PlayerPositions = new Positions();

    //create variables to use for the shooting
    //private bool shooting = false;
    //public GameObject enemyBullet;
    //public bool direction;
    public int timer;
    public GameObject projectile;

    public GameObject endDialogue; 
    //private Vector3 t; 

    // Use this for initialization
    void Start ()
    {
        base.Start();
        //Vector2 t = transform.position; 
        //t.x = player.transform.position.x + 10;
        //t.y = player.transform.position.y + 1;  
    }


    void FixedUpdate()
    {
    //Save player positions
        Vector2 playerpos = player.transform.position;
        //Debug.Log(playerpos); 
        float currenttime = Time.time;
        PlayerPositions.x.AddKey(currenttime, (playerpos.x * -1)); //if you take the -1 out of this equation then the character will follow your movements exactly, with the -1 they move opposite to the character on the x plane
        PlayerPositions.y.AddKey(currenttime, playerpos.y);

        //Load positions for enemy
        float x = PlayerPositions.x.Evaluate(currenttime - 5f);
        float y = PlayerPositions.y.Evaluate(currenttime - 5f);
        Vector3 newpos = new Vector2(x, y);
        Debug.Log("This should be the new position for the enemy" + newpos); 
        transform.position = newpos;



        if (Mathf.Abs(distance) <= 10f)
        {

            timer++;
            if (timer >= 120)
            {
                timer = 0;
                GameObject clone = (GameObject)Instantiate(projectile, transform.position, transform.rotation);

                if (player.transform.position.x < transform.position.x)
                {
                    clone.transform.localScale = new Vector3(3, 3, 1);
                    clone.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
                }
                else if (player.transform.position.x > transform.position.x)
                {
                    clone.transform.localScale = new Vector3(-3, 3, 1);
                    clone.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
                }
                Destroy(clone, 4);
            }//end of timer logic
        }//end of distance calc

        
    }

	// Update is called once per frame
	void Update ()
    {
        distance = player.transform.position.x - transform.position.x;
        //changes the direction that the enemy is facing
        if (player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-5, 5, 1);
            //direction = true;
        }
        if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(5, 5, 1);
            //direction = false; 
        }

        //damage calculation
        HurtEnemy();

        //centers the healthBar
        CenterHealthBar();

        //hides the healthbar if not in range
        ShowHealthBar();


        if (currentHealth <= 0)
        {
            endDialogue.SetActive(true);
        }

        ////logic to handle the BoozyBot's shooting functionality
        //if (Mathf.Abs(distance) <= 10f && shooting == false)
        //{
        //    shootBullet();
        //}


    }//end of Update

    //void shootBullet()
    //{
    //    Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
    //    Vector2 v = rb.velocity;
    //    v.x = 0.0f;
    //    shooting = true;

    //    float shotPos = 0.0f;
    //    float bulletAngle = 0.0f;
    //    float bulletVelocity = 0.0f;

    //    if (direction == true)
    //    {
    //        //renderer.material.mainTexture = shootRight;
    //        shotPos = 0.5f;
    //        bulletAngle = 0.0f;
    //        bulletVelocity = 16;
    //    }
    //    if (direction == false)
    //    {
    //        //renderer.material.mainTexture = shootLeft;
    //        shotPos = -0.5f;
    //        bulletAngle = 180.0f;
    //        bulletVelocity = -35;
    //    }

    //    StartCoroutine(Wait(0.5f)); 

    //    Vector3 bulletPosition = new Vector3(shotPos, 0, 0);
    //    var bullet = Instantiate(enemyBullet, transform.position + bulletPosition, Quaternion.Euler(0, 180, bulletAngle)) as Rigidbody2D;
    //    Rigidbody2D rbAgain = bullet.GetComponent<Rigidbody2D>();
    //    Vector2 v2 = rbAgain.velocity;  
    //    v2.x = bulletVelocity;

    //    shooting = false;

    //}//end of shootBullet

    //IEnumerator Wait(float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //}

}
