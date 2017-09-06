using UnityEngine;
using System.Collections;

public class BoozeDrop : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        //this only controls a little velocity when a heart is spawned to give it some movement.
        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
        Vector2 v = rb.velocity; 
        v = new Vector3(Random.Range(-6, 6), Random.Range(4, 8), 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
