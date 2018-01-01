using UnityEngine;
using System.Collections;

public class OtterBatCollide : MonoBehaviour {


    public Sprite OtterBatBloody;
    public SpriteRenderer sp; 


	// Use this for initialization
	void Start ()
    {
        sp = this.GetComponent<SpriteRenderer>(); 
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.gameObject.tag == "CollisionSnakeEnemy")
    //    {
    //        sp.sprite = OtterBatBloody;
    //    }
    //}

    void OnCollisionEnter2D(Collider2D col)
    {
        //if (col.gameObject.tag == "CollisionSnakeEnemy")
        //{
            sp.sprite = OtterBatBloody;
        //}
    }

    //void OnCollisionStay2D(Collider2D col)
    //{
    //    if (col.gameObject.tag == "CollisionSnakeEnemy")
    //    {
    //        sp.sprite = OtterBatBloody;
    //    }
    //}
}//end of class
