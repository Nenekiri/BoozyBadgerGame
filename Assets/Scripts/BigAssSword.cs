using UnityEngine;
using System.Collections;

public class BigAssSword : MonoBehaviour {

    public Transform endpos; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //movement for the sword, called as soon as it spawns. endpos is determined by the StopSword object position
        transform.position = Vector3.Lerp(transform.position, endpos.position, 0.001f);

    }

    //used for killing the enemies that come into contact with the sword
    void OnCollisionEnter2D(Collision2D col)
    {
        //logic for when the player is touching the enemy
        if (col.gameObject.tag == "CollisionEnemy" || col.gameObject.tag == "projectile")
        {
            Destroy(col.gameObject);
        }
    }//end of OnCollisionEnter2D

}
