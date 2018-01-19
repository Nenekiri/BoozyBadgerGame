using UnityEngine;
using System.Collections;

public class ProtectiveDante : MonoBehaviour {

    public float speed = 5.0f;
    public GameObject player;
    public float distance = 0.0f;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("GiantHorseMan");
    }
	
	// Update is called once per frame
	void Update ()
    {
        distance = player.transform.position.x - transform.position.x;
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

}
