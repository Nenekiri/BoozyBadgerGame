using UnityEngine;
using System.Collections;

public class GreyWolfJudge : Enemy {


    public GameObject projectile;
    public int timer;

    // Use this for initialization
    void Start ()
    {
        base.Start(); 
	
	}

    void FixedUpdate()
    {
        //logic to move the lizard woman in a set pattern
        //transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);

        if (Mathf.Abs(distance) <= 10f)
        {

            timer++;
            if (timer >= 120)
            {
                timer = 0; 
                GameObject clone = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
                GameObject clone2 = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
                GameObject clone3 = (GameObject)Instantiate(projectile, transform.position, transform.rotation);

                if (player.transform.position.x < transform.position.x)
                {
                    clone.transform.localScale = new Vector3(3, 3, 1);
                    clone.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
                    //clone.transform.LookAt(player.transform); 
                    clone2.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 1);
                    //clone2.transform.LookAt(player.transform);
                    clone3.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 2);
                    //clone3.transform.LookAt(player.transform);
                }
                else if (player.transform.position.x > transform.position.x)
                {
                    clone.transform.localScale = new Vector3(-3, 3, 1);
                    clone.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
                    //clone.transform.LookAt(player.transform);
                    clone2.transform.localScale = new Vector3(-3, 3, 1);
                    clone2.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 1);
                    //clone2.transform.LookAt(player.transform);
                    clone3.transform.localScale = new Vector3(-3, 3, 1);
                    clone3.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 2);
                    //clone3.transform.LookAt(player.transform);
                }
                Destroy(clone, 4);

            }//end of timer logic
        }//end of distance calc

    }//end of fixed update

    // Update is called once per frame
    void Update()
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

}
