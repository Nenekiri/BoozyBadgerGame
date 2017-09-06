using UnityEngine;
using System.Collections;

public class Beetle : Enemy {

	// Use this for initialization
	void Start ()
    {
        base.Start();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Mathf.Abs(distance) <= 10f)
        {
            //this code will follow the player around once the player gets close enough
            transform.position = Vector2.MoveTowards(player.transform.position, target.position, 5f); //possible helpful note, if you want the enemy to be an epilepsy inducing flash on either side of the character then set the float value to negative
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


    }


}//end of Beetle class
