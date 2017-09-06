using UnityEngine;
using System.Collections;

public class FrillLizard : Enemy {

    //public int firstPosition;
    //public int endPosition;

    public Vector3 pos1 = new Vector3(-6, 0, 0);
    public Vector3 pos2 = new Vector3(6, 0, 0);
    public float speed = 3.0f;


    

    //private bool dirLeft = true;
    //public float speed = 10.0f;

    private float moveSpeed = 4.0f;

    //public Enemy e = new Enemy(); 

	// Use this for initialization
	void Start ()
    {
        base.Start();

        //wholeHealthBar = target.Find("EnemyCanvas").gameObject;
        //wholeHealthBar.SetActive(false);

        //healthBar.value = maxHealth;
        //wholeHealthBar = gameObject.FindInChildren("EnemyCanvas"); 
        //wholeHealthBar.SetActive(false);
    }
	


	// Update is called once per frame
	void Update ()
    {
        distance = player.transform.position.x - transform.position.x;
        Debug.Log("This is the distance the player is from the character: " + distance);

        if (currentHealth > 0)
        {
            transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
        }
        

        //tells the lizard to rush towards the player if it is within striking distance
        if (Mathf.Abs(distance) <= 10f)
        {
            //transform.position += transform.forward * moveSpeed * Time.deltaTime;
            //Vector2 velocity = new Vector2((transform.position.x - player.transform.position.x) * moveSpeed, (transform.position.y - player.transform.position.y) * moveSpeed);
            //GetComponent<Rigidbody2D>().velocity = -velocity;


            //if (dirLeft)
            //    transform.Translate(Vector2.left * speed * Time.deltaTime);
            //else
            //    transform.Translate(-Vector2.left * speed * Time.deltaTime);

            //if (transform.position.x >= 2.0f)
            //{
            //    dirLeft = false;
            //}

            //if (transform.position.x <= -2)
            //{
            //    dirLeft = true;
            //}

            //This code can still be used, perhaps in another enemy
            //transform.position = Vector2.MoveTowards(player.transform.position, target.position, 5f); //possible helpful note, if you want the enemy to be an epilepsy inducing flash on either side of the character then set the float value to negative

        }

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

        //ShowHealthBarImproved();

    }

   //public void ShowHealthBarImproved()
   // {
   //     if (Mathf.Abs(distance) > 10f)
   //     {
   //         GameObject.Find("EnemyCanvas").transform.localScale = new Vector3(0, 0, 0);
   //     }
   //     else
   //     {
   //         Debug.Log("Player is close enough to trigger the health bar"); 
   //         // Show button
   //         GameObject.Find("EnemyCanvas").transform.localScale = new Vector3(0.5f, 0.5f, 1);
   //     }
   // }

}//end of FrillLizard class
