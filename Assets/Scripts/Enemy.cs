using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float maxHealth;
    public float currentHealth;
    public AudioClip hurtSound;
    public GameObject boozeDrop;
    public Slider healthBar;
    public GameObject wholeHealthBar; 

    public Transform target;
    //public Camera camera;

    public float threshold = 1.0f;
    public float sensitivity = 100;
    public string playerName; 

    public GameObject player;
    public float distance = 0.0f;
    private float ydistance = 0.0f;
    public tk2dSpriteAnimator animP;

    private bool isAttacked;

    private int healthBarWidth = 20;
    private int healthBarHeight = 5;

    private float left;
    private float top;
    private ParticleSystem ps;

    private tk2dSpriteAnimator anim;
    private AudioSource audios;

    public int randNum;
    public bool spawnedHealth = false; 

    //specific variables used for Boss Death anim and sound played when defeated
    public bool isBoss;
    public AudioClip bossDeathSound; 
    //public tk2dSpriteAnimationClip bossDeathClip; 

    // Use this for initialization
    public void Start ()
    {
        player = GameObject.Find(playerName);
        animP = player.GetComponent<tk2dSpriteAnimator>();

        //maxHealth = 5f;
        //currentHealth = 5f;
        healthBar.value = maxHealth;
        isAttacked = false;
        ps = player.GetComponent<ParticleSystem>();
        ps.Stop();


        //gets the sprite animator for the enemy
        anim = GetComponent<tk2dSpriteAnimator>();
        audios = GetComponent<AudioSource>();


        randNum = Random.Range(1, 4);

        //foreach (Transform child in transform)
        //{
        //    if (child.name == "EnemyHealthBar")
        //    {
        //        wholeHealthBar = child.gameObject;
        //        wholeHealthBar.SetActive(false);
        //    }
        //}

        //for (var child in transform)
        //{
        //    if (child.name == "Bone")
        //    {
        //        // the code here is called 
        //        // for each child named Bone
        //    }
        //}

        //Transform t = target.Find("EnemyHealthBar");
        //Debug.Log("This is supposed to be the transform: " + t);
        wholeHealthBar = target.Find("EnemyCanvas").gameObject; 
        wholeHealthBar.SetActive(false);
    }


    void DestroyDelegate(tk2dSpriteAnimator sprite, tk2dSpriteAnimationClip clip)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update ()
    {
        //gets the distance the player is from the enemy
        distance = player.transform.position.x - transform.position.x;
        ydistance = player.transform.position.y - transform.position.y;

        Debug.Log("This is current distance: " + distance); 

        //checks to see if the enemy is getting hurt
        HurtEnemy();

        //centers the currently selected healthbar
        CenterHealthBar();

        //hides the healthbar if not in range
        ShowHealthBar();

    }

    public void HurtEnemy()
    {

        //If Boozy is talking, then the enemy takes some damage
        if (MicInput.MicLoudness * sensitivity > threshold && Mathf.Abs(distance) <= 10f)
        {
            //isAttacked = true;
            //if (isAttacked)
            //{
            //animP.Play("BoozyAttack");
            //}
            ps.Play(); 

            
            currentHealth -= 0.1f;
            healthBar.value = currentHealth; 
            Debug.Log(currentHealth); 
            if (currentHealth <= 0)
            {
                animP.Play("BoozyStandStill");
                ps.Stop();

                this.gameObject.tag = "Untagged";  

                
                if (randNum == 2 && spawnedHealth == false)
                {
                    Instantiate(boozeDrop, transform.position, Quaternion.Euler(0, 180, 0));
                    spawnedHealth = true; 
                }

                //isAttacked = false; 

                if (!anim.IsPlaying("EnemyDeathAnim") && !isBoss)
                {
                    //used only if the enemy is a boss
                    //if (isBoss)
                    //{

                    //}

                    anim.Play("EnemyDeathAnim");
                    anim.AnimationCompleted = DestroyDelegate;
                }
                else if(isBoss)
                {
                    //this is to ensure that all movement based in coroutines stops before the final cutscene plays
                    StopAllCoroutines(); 
                    //Start the coroutine that does a delay and then plays the ending dialogue for the boss
                    StartCoroutine(DelayBoss(3.0f)); 
                }

                

                    //destroy the gameobject here just in case we need to spawn a health pickup
                    //Destroy(gameObject);
                } 
        }
        else if(!animP.IsPlaying("BoozyWalk"))
        {
            animP.Play("BoozyStandStill");
        }

    }

    //float CalcHealth()
    //{
    //    return currentHealth / maxHealth;
    //}

    public void CenterHealthBar()
    {
        Vector3 healthBarWorldPosition = target.transform.position + new Vector3(0.0f, target.transform.localScale.y, 0.0f);
        Vector3 healthBarScreenPosition = Camera.main.WorldToScreenPoint(healthBarWorldPosition);

        left = healthBarScreenPosition.x - (healthBarWidth / 2);
        top = healthBarScreenPosition.y + (healthBarHeight / 2);

        Vector3 healthpos = healthBar.transform.position;

        healthpos.x = left;
        healthpos.y = top;

    }

    public void ShowHealthBar()
    {
        if (Mathf.Abs(distance) <= 10f)
        {
            wholeHealthBar.SetActive(true);
            Debug.Log("Health bar should be showing"); 
        }
        else
        {
            wholeHealthBar.SetActive(false);
            Debug.Log("Fuck off Health bar");
        }
    }

    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }

    public IEnumerator DelayBoss(float delay)
    {
        yield return new WaitForSeconds(delay);
        audios.PlayOneShot(bossDeathSound);
        anim.Play();
        anim.AnimationCompleted = DestroyDelegate;
    }

}
