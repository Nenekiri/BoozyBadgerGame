using UnityEngine;
using System.Collections;

public class BigAssSword : MonoBehaviour {

    public Transform endpos; 

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;

    float timer = 0.0f; 


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //movement for the sword, called as soon as it spawns. endpos is determined by the StopSword object position
        transform.position = Vector3.Lerp(transform.position, endpos.position, 0.01f);
        StartCoroutine(DelayThenDestroy(1.0f, enemy1));
        StartCoroutine(DelayThenDestroy(1.5f, enemy2));
        StartCoroutine(DelayThenDestroy(2.0f, enemy3));
        StartCoroutine(DelayThenDestroy(2.5f, enemy4));

        StartCoroutine(DelayThenDestroy(5.0f, this.gameObject)); 


    }


    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    //logic for when the player is touching the enemy
    //    if (col.gameObject.tag == "CollisionEnemy" || col.gameObject.tag == "projectile")
    //    {
    //        Destroy(col.gameObject);
    //    }
    //}

    //used for killing the enemies that come into contact with the sword
    void OnCollisionEnter2D(Collision2D col)
    {
        //logic for when the player is touching the enemy
        if (col.gameObject.tag == "CollisionEnemy" || col.gameObject.tag == "projectile")
        {
            Destroy(col.gameObject);
        }
    }//end of OnCollisionEnter2D


    IEnumerator DelayThenDestroy(float delay, GameObject E)
    {
        yield return new WaitForSeconds(delay);
        Destroy(E); 
    }

}
