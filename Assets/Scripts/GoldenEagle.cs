using UnityEngine;
using System.Collections;

public class GoldenEagle : Enemy {

    public Vector3 pointB;
    public Vector3 pointC; 

    private RaycastHit2D hit;
    public Vector3 pt;

    public float timer = 0.0f;
    public bool hitPlayer = false;

    public GameObject endDialogue; 

    void Start()
    {
        base.Start();
        
    }

    IEnumerator MoveHorizontal()
    {
        StopCoroutine(MoveVertical()); 
        var pointA = transform.position;
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 7.0f));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 7.0f));
        }
    }

    IEnumerator MoveVertical()
    {
        StopCoroutine(MoveHorizontal()); 
        //var pointC = vec;
        var pointC = player.transform.position;
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointC, pointB, 7.0f));
            yield return StartCoroutine(MoveObject(transform, pointB, pointC, 7.0f));
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            if (timer < 15.0f)
            {
                //endPos = pointB;
                thisTransform.position = Vector3.Lerp(startPos, endPos, i);
               
            }
            else if (timer >= 15.0f && timer <= 25.0f)
            {
                endPos = pointC;
                thisTransform.position = Vector3.Lerp(startPos, endPos, i);
                if (currentHealth <= 0)
                {
                    //this is to ensure that all movement based in coroutines stops before the final cutscene plays
                    StopAllCoroutines();
                    //Start the coroutine that does a delay and then plays the ending dialogue for the boss
                    StartCoroutine(DelayBoss(3.0f));
                }

            }
            else if (timer >= 25.0f)
            {
                timer = 0.0f; 
            }
            yield return null;
        }

      
    }

    void MovingObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
        }
    }

    void FixedUpdate()
    {
        //logic to check for the player being beneath the eagle, activate swooping attack

        //hit = Physics2D.Raycast(transform.position, Vector3.down);
        //Vector2 playerTranform;
        //playerTranform = player.transform.TransformPoint(player.transform.position.x, player.transform.position.y, player.transform.position.z); 
        //if (hit.collider != null)
        //{
        //    Debug.Log("Collider is being hit");
        //    if (hit.collider.gameObject.tag == "player") //the players .gameObject is there because i'm not sure if you have it set to a transform, if it's a GameObject then you can be rid of it :)
        //    {
        //        Debug.Log("Player is below me");

        //        //this code is to move towards the player on the y axis if the eagle is above them
        //        this.transform.localPosition = new Vector3(this.transform.localPosition.x, Mathf.Lerp(this.transform.localPosition.y, player.transform.localPosition.y, Time.deltaTime * 1), this.transform.localPosition.z);
        //        // player is directly above this tile
        //        //pausePlayer = true;
        //    }
        //}

        //if (Mathf.Abs(distance) <= 5f)
        //{
        //    StopCoroutine(Start());
        //    Vector3 pos1 = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        //    Vector3 pos2 = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        //    transform.position = Vector3.Lerp(pos1, pos2, Time.deltaTime * 1);
        //}
        //else
        //{
        //    //StartCoroutine(Start());
        //}

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        pointC = player.transform.position;

        //checks to see if the boss is out of health

            StartCoroutine(MoveHorizontal());
        
        //pt = player.transform.position;
        //if (timer < 10.0f)
        //{
        //    StartCoroutine(MoveHorizontal());

        //    //Vector3 pos1 = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        //    //Vector3 pos2 = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        //    //transform.position = Vector3.Lerp(pos1, pos2, Time.deltaTime * 1);
        //}
        //else if (timer >= 10.0f)
        //{
        //    StopAllCoroutines();
        //    StartCoroutine(MoveVertical());
        //}
        //else if(hitPlayer)
        //{
        //    StopAllCoroutines();
        //    timer = 0.0f;
        //    hitPlayer = false;
        //}

        //if (timer < 10.0f)
        //{
        //    Vector3 pointA = transform.position;
        //    MovingObject(transform, pointA, pointB, 7.0f);
        //    MovingObject(transform, pointB, pointA, 7.0f);
        //}

        //StartCoroutine(Start());

        distance = player.transform.position.x - transform.position.x;

        //changes the direction that the enemy is facing
        if (player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(8, 8, 1);
        }
        if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-8, 8, 1);
        }

        //damage calculation
        HurtEnemy();

        //centers the healthBar
        CenterHealthBar();

        //hides the healthbar if not in range
        ShowHealthBar();

        if (currentHealth <= 0)
        {
            endDialogue.SetActive(true);
        }




    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "player")
            hitPlayer = true;
    }



}
