using UnityEngine;
using System.Collections;

public class BlackBox : Enemy {


    public GameObject projectile;
    public int timer;

    // Use this for initialization
    void Start ()
    {
        base.Start();
	}
	
	// Update is called once per frame
	void Update ()
    {



        distance = player.transform.position.x - transform.position.x;


        if (Mathf.Abs(distance) <= 10f)
        {

            timer++;
            if (timer >= 180)
            {
                timer = 0;

                GameObject clone = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
                GameObject clone2 = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
                GameObject clone3 = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
                GameObject clone4 = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
                GameObject clone5 = (GameObject)Instantiate(projectile, transform.position, transform.rotation);

                if (player.transform.position.x < transform.position.x)
                {
                    clone.transform.localScale = new Vector3(3, 3, 1);
                    clone.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
                    //Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                    clone2.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 1);
                    clone3.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 2);

                }
                else if (player.transform.position.x > transform.position.x)
                {
                    clone.transform.localScale = new Vector3(-3, 3, 1);
                    clone.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
                    clone2.transform.localScale = new Vector3(-3, 3, 1);
                    clone2.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 1);
                    clone3.transform.localScale = new Vector3(-3, 3, 1);
                    clone3.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 2);
                }
                Destroy(clone, 4);

            }
        }



        //damage calculation
        HurtEnemy();

        //centers the healthBar
        CenterHealthBar();

        //hides the healthbar if not in range
        ShowHealthBar();

    }

}
