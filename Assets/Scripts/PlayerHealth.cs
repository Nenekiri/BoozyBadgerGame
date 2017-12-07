using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int health = 3;
    public AudioClip hitSound;
    public AudioClip boozeSound;

    public Image HP1;
    public Image HP2;
    public Image HP3; 

    public Sprite glassWhole;
    public Sprite glassHalf;
    public Sprite glassEmpty;

    public string deathAnim;
    public AudioSource audios;
    public Renderer render; 
    private bool dead = false;

    private float hitCounter = 0.0f;
    private bool hit = false; 


    void hitCheck()
    {
        if (hit)
        {
            hitCounter += Time.deltaTime; 
        }

        if (hitCounter > 0.25f)
        {
            hitCounter = 0.0f;
            hit = false; 
        }
    }

    void Start()
    {
        audios = this.GetComponent<AudioSource>();
        render = this.GetComponent<Renderer>(); 
    }

    void Update()
    {
        //checks to see if the player can be damaged
        hitCheck();
    }

    //    //here are public variables that can be edited in the inspector for the players health.
    //    var health:int = 3;
    ////sound when he's hit
    //var hitSound:AudioClip;
    ////death animation if he dies
    //var deathAnim:GameObject;
    ////the 3 heart guitextures that are updated at the top of the screen to show his health.
    //var heart1:GUITexture;
    //var heart2:GUITexture;
    //var heart3:GUITexture;
    ////var heart4:GUITexture; 
    ////var heart5:GUITexture;
    ////var heart6:GUITexture;
    ////var heart7:GUITexture;
    ////var heart8:GUITexture;
    ////the 3 different heart textures that will be changed in the hearts at the top of the screen depending on his health.
    //var heartWhole:Texture;
    //var heartHalf:Texture;
    //var heartEmpty:Texture;
    ////the sound if a heart is picked up
    //var heartSound:AudioClip;

    //private var dead = false;
    //    private var colorCounter:float = 0.0;


    //function Update()
    //    {
    //        //here we check to see if the players color was changed when he got hurt. if so, we'll give it a bit of time before we switch it back so the player can see it.
    //        if (renderer.material.color.b == 0.25)
    //        {
    //            colorCounter += Time.deltaTime;
    //            if (colorCounter > 0.25)
    //            {
    //                renderer.material.color.g = 1;
    //                renderer.material.color.b = 1;
    //                colorCounter = 0.0;
    //            }
    //        }

    //        //if the player falls down a hole we want to reload the scene... because he died.
    //        if (transform.position.y < -50)
    //        {
    //            var lvlName:String = Application.loadedLevelName;
    //            Application.LoadLevel(lvlName);
    //        }
    //    }

    //    //here we check to see if the we hit an enemy or spikes, but we won't get hurt if our color was changed because that was the indication that we were hurt not too long ago. like 0.25 seconds ago.
    //    function OnTriggerStay(other : Collider)
    //    {
    //        if (other.tag == "enemy" && renderer.material.color.b != 0.25 && dead == false || other.tag == "spikes" && renderer.material.color.b != 0.25 && dead == false)
    //        {
    //            audio.PlayOneShot(hitSound);
    //            renderer.material.color.g = 0.25;
    //            renderer.material.color.b = 0.25;
    //            checkHealth();
    //            if (other.name == "Boss bullet(Clone)")
    //            {
    //                Destroy(other.gameObject);
    //            }
    //        }
    //    }

    //    //this is the same as ontriggerstay, but for enemy's whose colliders aren't triggers.
    //    function OnCollisionStay(other : Collision)
    //    {
    //        if (other.collider.tag == "enemy" && renderer.material.color.b != 0.25 && dead == false || other.collider.tag == "spikes" && renderer.material.color.b != 0.25 && dead == false)
    //        {
    //            audio.PlayOneShot(hitSound);
    //            renderer.material.color.g = 0.25;
    //            renderer.material.color.b = 0.25;
    //            checkHealth();
    //        }
    //        //if its a heart though, we want health back instead of taken away.
    //        if (other.collider.tag == "heart")
    //        {
    //            Destroy(other.gameObject);
    //            addHealth();
    //        }
    //    }

    //    //here we checkhealth when a player is hit by an enemy.
    void checkHealth()
    {
        health -= 1;

        //here we update the hearts on the screen so that they show an accurate health amount
        updateHearts();

        // if health is 0 then we're going to do all of this stuff once, which is why we check to see if dead was previously false.
        //it turns off a bunch of stuff like physics, renderers, scripts, then waits for 3 seconds before it reloads the scene again.	
        if (health <= 0 && dead == false)
        {
            dead = true;
            //renderer.enabled = false;
            //rigidbody.isKinematic = true;
            //collider.enabled = false;
            //Instantiate(deathAnim, transform.position, Quaternion.Euler(0, 180, 0));
            //var controls = gameObject.GetComponent(playercontrols);
            //var weapons = gameObject.GetComponent(playerweapons);
            //controls.enabled = false;
            //weapons.enabled = false;
            //Globals.keyGetYellow = false;
            //Globals.keyGetRed = false;
            Wait(3); 
            string lvlName = Application.loadedLevelName;
            Application.LoadLevel(lvlName);
        }

    }


    IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    //use this method for enemies who need to be able to fall off platforms or need a rigidbody, IsTrigger should be off
    void OnCollisionEnter2D(Collision2D col)
    {
        //logic for when the player is touching the enemy
        if (col.gameObject.tag == "CollisionEnemy")
        {
            audios.PlayOneShot(hitSound);
            checkHealth();
        }

        //logic for when the player is touching the enemy
        if (col.gameObject.tag == "CollisionSnakeEnemy")
        {
            audios.PlayOneShot(hitSound);
            checkHealth();
        }

        if (col.gameObject.tag == "healthPickup")
        {
            addHealth();
            audios.PlayOneShot(boozeSound);
            Destroy(col.gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        //logic for when the player is touching the enemy
        if (col.gameObject.tag == "CollisionSnakeEnemy")
        {
            audios.PlayOneShot(hitSound);
            checkHealth();
        }

    }



    //this code could be helpful for traps as they should continuously do damage. 

    //void OnTriggerStay2D(Collider2D col)
    //{
    //    if (col.gameObject.tag == "enemy" && hit == false)
    //    {
    //        audios.PlayOneShot(hitSound);
    //        checkHealth();
    //        hit = true; 
    //    }
    //}


    //use this method for enemies that need to be able to pass through the enemy, IsTrigger should be on
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "IsTriggerEnemy" && hit == false)
        {
            audios.PlayOneShot(hitSound);
            checkHealth();
            hit = true;
        }
    }

    //    //here we add health back.
    public void addHealth()
    {
        audios.PlayOneShot(boozeSound);
        health += 2;
        //if the players health is more than 6, we want to make sure its 6 because thats the max we chose.
        if (health > 6)
        {
            health = 6;
        }
        //here we update the hearts on the screen so that they show an accurate health amount
        updateHearts();
    }

    public void updateHearts()
    {
        //here we check how much health the player has, then change the textures for the 3 hearts on the top of the screen accordingly.
        if (health == 6)
        {
            HP1.sprite = glassWhole;
            HP2.sprite = glassWhole;
            HP3.sprite = glassWhole;
        }
        if (health == 5)
        {
            HP1.sprite = glassWhole;
            HP2.sprite = glassWhole;
            HP3.sprite = glassHalf;
        }
        if (health == 4)
        {
            HP1.sprite = glassWhole;
            HP2.sprite = glassWhole;
            HP3.sprite = glassEmpty;
        }
        if (health == 3)
        {
            HP1.sprite = glassWhole;
            HP2.sprite = glassHalf;
            HP3.sprite = glassEmpty;
        }
        if (health == 2)
        {
            HP1.sprite = glassWhole;
            HP2.sprite = glassEmpty;
            HP3.sprite = glassEmpty;
        }
        if (health == 1)
        {
            HP1.sprite = glassHalf;
            HP2.sprite = glassEmpty;
            HP3.sprite = glassEmpty;
        }
        if (health == 0)
        {
            HP1.sprite = glassEmpty;
            HP2.sprite = glassEmpty;
            HP3.sprite = glassEmpty;
        }
    }//end of UpdateHearts

    }//end of PlayerHealth script
