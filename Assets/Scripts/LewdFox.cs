using UnityEngine;
using System.Collections;

public class LewdFox : Enemy {

    //public Vector3 SpawnPoint1;
    //public Vector3 SpawnPoint2;
    //public Vector3 SpawnPoint3;
    //public Vector3 SpawnPoint4;
    //public Vector3 SpawnPoint5;
    //public Vector3 SpawnPoint6;

    public Vector3[] points;
    public GameObject projectile;
    public float timer;
    private ParticleEmitter emitter;

    public AudioSource audiosource;
    public AudioClip teleportSound;

    public GameObject endDialogue;

    private bool foxDead = false; 

    // Use this for initialization
    void Start ()
    {
        base.Start();
        emitter = GetComponent<ParticleEmitter>();
        audiosource = this.GetComponent<AudioSource>();
        //starts the coroutine that handles the waiting and then firing of the fox enemy
    }


    void FixedUpdate()
    {
        timer += Time.deltaTime;

        //might be able to vary this boss fight up a bit by having him fire faster and fire more projectiles as the battle goes on and his health gets lower
        if (timer >= 5.0f && !foxDead)
        {
            audiosource.PlayOneShot(teleportSound); 
            this.transform.position = (points[Random.Range(0, points.Length * 7) % points.Length]);
            GameObject clone = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
            GameObject clone2 = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
            GameObject clone3 = (GameObject)Instantiate(projectile, transform.position, transform.rotation);

            if (player.transform.position.x < transform.position.x)
            {
                clone.transform.localScale = new Vector3(3, 3, 1);
                clone.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
                clone2.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 1);
                clone3.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 2);

            }
            else if (player.transform.position.x > transform.position.x)
            {
                clone.transform.localScale = new Vector3(-3, 3, 1);
                clone.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
                clone2.transform.localScale = new Vector3(-3, 3, 1);
                clone2.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 1);
                clone3.transform.localScale = new Vector3(-3, 3, 1);
                clone3.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 2);
            }
            Destroy(clone, 4);
            Destroy(clone2, 4);
            Destroy(clone3, 4);

            timer = 0.0f; 
        }

        

    }
	
	// Update is called once per frame
	void Update ()
    {
        distance = player.transform.position.x - transform.position.x;

        //changes the direction that the enemy is facing
        if (player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(7, 7, 1);
        }
        if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-7, 7, 1);
        }

        //damage calculation
        HurtEnemy();

        //centers the healthBar
        CenterHealthBar();

        //hides the healthbar if not in range
        ShowHealthBar();

        //plays the death dialogue if the health is 0
        if (currentHealth <= 0)
        {
            foxDead = true;
            endDialogue.SetActive(true);
        }
    }

}
