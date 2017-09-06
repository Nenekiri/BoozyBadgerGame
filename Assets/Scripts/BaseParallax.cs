using UnityEngine;
using System.Collections;

public class BaseParallax : MonoBehaviour {

    //declare variables

    public GameObject target;
    public float offset = 3;

    // Use this for initialization
    void Start()
    {

        //target = GameObject.Find("Main Camera");

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 Position = this.transform.position;

        Position.y = target.transform.position.y / offset;
        Position.x = target.transform.position.x / offset;

    }//end of fixed update
}//end of class
