using UnityEngine;
using System.Collections;

public class ChainsawSnake : MonoBehaviour {

    public string playerName;

    public GameObject player;
    public float distance = 0.0f;
    public float speed = 1.0f;

    public AudioSource audios;
    public AudioClip chainsawSound;
    public AudioClip smacked; 
    //public ParticleSystem ps;

    //public float pointA;
    //public float pointB;

    public Vector3 pointB;

    public bool OtterSmacked = false;
    public SpriteRenderer sp;
    public Sprite snakeSmacked;
    public Sprite OtterBatBloody; 

    public GameObject OtterBat;
    public SpriteRenderer OtterBatSP; 
    public GameObject OtterSmackDialogue;
    public GameObject FinalExitDoor;  


    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find(playerName);
        //used for audiosource
        audios = this.GetComponent<AudioSource>();
        sp = this.GetComponent<SpriteRenderer>();
        OtterBatSP = OtterBat.GetComponent<SpriteRenderer>(); 
        

        //used for particlesystem
        //ps = GetComponent<ParticleSystem>(); 
        //ps.Stop();

        //StartCoroutine(MoveSnake());

    }//end of Start

    //IEnumerator MoveSnake()
    //{
    //    var pointA = transform.position;
    //    while (true)
    //    {
    //        yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
    //        yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
    //    }
    //}
	
	// Update is called once per frame
	void Update ()
    {

        distance = player.transform.position.x - transform.position.x;

        if (Application.loadedLevelName == "Facility1-3" || Application.loadedLevelName == "Facility1-4" || Application.loadedLevelName == "Facility1-5")
        {
            //keeps the chainsaw snake from flipping its sprite and becoming completely invisible
        }
        else
        {
            //changes the direction that the enemy is facing
            if (player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(10, 10, 1);
            }
            if (player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-10, 10, 1);
            }

        }


    }//end of Update
    void FixedUpdate()
    {

        //Section for a random number generator to pick a number and then drastically increase his speed briefly



        if (OtterSmacked != true)
        {

            if (Mathf.Abs(distance) <= 30f && playercontrols.camoOn != true)//increased range to make him harder to get out from under. 
            {

                if (player.transform.position.x < transform.position.x)
                {
                    speed = 5f;
                    StartCoroutine(Delay(2.0f));
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                }
                else if (player.transform.position.x > transform.position.x)
                {
                    speed = 5f;
                    StartCoroutine(Delay(2.0f));
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                }
            }
            else if (Mathf.Abs(distance) > 30f && playercontrols.camoOn != true)
            {
                if (player.transform.position.x < transform.position.x)
                {
                    if (!audios.isPlaying)
                    {
                        audios.PlayOneShot(chainsawSound);
                    }
                    speed = 15f;
                    StartCoroutine(Delay(2.0f));
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                }
                else if (player.transform.position.x > transform.position.x)
                {
                    if (!audios.isPlaying)
                    {
                        audios.PlayOneShot(chainsawSound);
                    }
                    speed = 15f;
                    StartCoroutine(Delay(2.0f));
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                }
            }


        }//end of logic to check if the Chainsaw snake was hit by QM
        //MoveSnakeAtoB();
    }//end of FixedUpdate


    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.tag == "DFWOtterBat")
    //    {
    //        audios.PlayOneShot(smacked);
    //        OtterSmacked = true;
    //        sp.sprite = snakeSmacked;
    //        this.gameObject.tag = "Untagged";
    //        OtterSmackDialogue.SetActive(true);
    //        FinalExitDoor.SetActive(true);
    //    }

    //}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "DFWOtterBat")
        {
            audios.Stop(); 
            audios.PlayOneShot(smacked);
            OtterSmacked = true;
            sp.sprite = snakeSmacked;
            OtterBatSP.sprite = OtterBatBloody; 
            this.gameObject.tag = "Untagged";
            OtterSmackDialogue.SetActive(true);
            FinalExitDoor.SetActive(true);
        }
    }

    //IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    //{
    //    var i = 0.0f;
    //    var rate = 1.0f / time;
    //    while (i < 1.0f)
    //    {
    //        i += Time.deltaTime * rate;
    //        thisTransform.position = Vector3.Lerp(startPos, endPos, i);
    //        if (thisTransform.position == endPos) //need to find an alternative for this as comparing the float value to an exact number causes the snake to stop and then never start again.
    //        {
    //            StopAllCoroutines();
    //            StartCoroutine(Delay(3.0f));
    //        }
    //        yield return null;
    //    }

    //}

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
    }

    IEnumerator DelayThenMove(float delay)
    {
        Debug.Log("Made it into the delay coroutine");
        yield return new WaitForSeconds(delay);
        float t = transform.position.x; 
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

}//end of ChainsawSnake class
