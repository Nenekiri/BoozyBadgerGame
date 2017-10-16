﻿using UnityEngine;
using System.Collections;

public class ChainsawSnake : MonoBehaviour {

    public string playerName;

    public GameObject player;
    public float distance = 0.0f;

    //public float pointA;
    //public float pointB;

    public Vector3 pointB;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find(playerName);
        StartCoroutine(MoveSnake());

    }//end of Start

    IEnumerator MoveSnake()
    {
        var pointA = transform.position;
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

        distance = player.transform.position.x - transform.position.x;

        //changes the direction that the enemy is facing
        //if (player.transform.position.x < transform.position.x)
        //{
        //    transform.localScale = new Vector3(7, 7, 1);
        //}
        //if (player.transform.position.x > transform.position.x)
        //{
        //    transform.localScale = new Vector3(-7, 7, 1);
        //}

    }//end of Update
    void FixedUpdate()
    {
        //MoveSnakeAtoB();
    }//end of FixedUpdate

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            if (thisTransform.position == endPos) //need to find an alternative for this as comparing the float value to an exact number causes the snake to stop and then never start again.
            {
                StopAllCoroutines();
                StartCoroutine(Delay(3.0f));
            }
            yield return null;
        }
      
    }

        //void MoveSnakeAtoB()
        //{
        //    if (transform.position.x < pointB)
        //    {
        //        Vector2 snakePos = new Vector2(transform.position.x, transform.position.y);
        //        snakePos.x += 1f;
        //        transform.position = snakePos; 
        //    }
        //    else if (transform.position.x >= pointB)
        //    {
        //        StartCoroutine(Delay(3.0f));
        //        CheckPos(); 
        //    }
        //}

        //void MoveSnakeBtoA()
        //{
        //    if (transform.position.x > pointA)
        //    {
        //        Vector2 snakePos = new Vector2(transform.position.x, transform.position.y);
        //        snakePos.x -= 1f;
        //        transform.position = snakePos;
        //    }
        //    else if (transform.position.x <= pointA)
        //    {
        //        StartCoroutine(Delay(3.0f));
        //        CheckPos();
        //    }
        //}

        //void CheckPos()
        //{
        //    if (transform.position.x <= pointA)
        //    {
        //        MoveSnakeAtoB();
        //    }
        //    else if (transform.position.x >= pointB)
        //    {
        //        MoveSnakeBtoA(); 
        //    }
        //}

        IEnumerator Delay(float delay)
    {
        Debug.Log("Made it into the delay coroutine"); 
        yield return new WaitForSeconds(delay);
        StartCoroutine(MoveSnake());
    }

}//end of ChainsawSnake class