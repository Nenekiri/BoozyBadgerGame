using UnityEngine;
using System.Collections;

public class HorseMan : Enemy {

    public float speed = 5.0f; 

	// Use this for initialization
	void Start ()
    {
        base.Start();
	}
	
	// Update is called once per frame
	void Update ()
    {
      

            distance = player.transform.position.x - transform.position.x;

        //changes the direction that the enemy is facing
        if (player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(7, 7, 1);
        }
        if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-7, 7, 1);
        }

            //damage calculation
            HurtEnemy();

        //centers the healthBar
        CenterHealthBar();

        //hides the healthbar if not in range
        ShowHealthBar();

    }


    void FixedUpdate()
    {
        if (Mathf.Abs(distance) <= 10f)
        {

            if (player.transform.position.x < transform.position.x)
            {
                //this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
            else if (player.transform.position.x > transform.position.x)
            {
                //this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
    }//end of FixedUpdate


    //void OnCollisonEnter2D(Collision2D col)
    //{
    //    Debug.Log("Collided!");
    //    if (col.gameObject.tag == "player")
    //    {
    //        Debug.Log("Collided with player!");
    //        speed = 10.0f;
    //    }
    //}

}
