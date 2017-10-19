using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private float lifeCounter = 0.0f; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //lifeCounter += Time.deltaTime;

        //when the counter is higher than 1(1 second) it will destroy the bullet it is attached to.
        //if (lifeCounter > 1)
        //{
        //    Destroy(gameObject);
        //}

    }


    //void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (col.gameObject.tag == "player")
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "player" || col.gameObject.tag == "platform")
        {
            Destroy(gameObject);
        }
    }

}
