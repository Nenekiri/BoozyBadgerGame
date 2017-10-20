using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public float levelNumber;
    public string nextLevel;
    public static int paperNumberStatic;
    public static int collectedPapersStatic;
    public int paperNumber;
    public int collectedPapers; 
    public Sprite happyOtter;
    private SpriteRenderer sr;
    public AudioSource audios; 
    public AudioClip finishLevelSound; 

    void Awake()
    {
        paperNumberStatic = paperNumber;
        collectedPapersStatic = collectedPapers; 

    }

void Start()
    {
        collectedPapers = 0; 
        //we want to save progress. We'll save a number in PlayerPrefs to keep so players can continue progress by loading the latest level they were on
        PlayerPrefs.SetFloat("savedLevel", levelNumber);
        sr = this.gameObject.GetComponent<SpriteRenderer>();

        if (Application.loadedLevelName == "OpeningScene")
        {
            audios = GameObject.Find("AnimatedBoozy(Clone)").GetComponent<AudioSource>();
        }
        else
        {
            audios = GameObject.Find("AnimatedBoozy").GetComponent<AudioSource>();
        }

        
    }


    //check to see if something runs into it and checks only upon enter, not constant. Constant would be OnTriggerStay
    //void  OnTriggerEnter(Collider2D col)
    //{

    //    if (collectedPapers >= paperNumber)
    //    {
    //        //change the sprite to be the happy one
    //        sr.sprite = happyOtter;
    //        Application.LoadLevel(nextLevel);
    //    }

    //}//end of OnTriggerEnter


    void OnCollisionEnter2D(Collision2D col)
    {

        if (collectedPapersStatic >= paperNumberStatic && col.gameObject.tag == "player")
        {
            //change the sprite to be the happy one
            sr.sprite = happyOtter;
            audios.PlayOneShot(finishLevelSound); 
            StartCoroutine(Delay(5.0f)); 
            
        }

    }//end of OnCollisionEnter2D

    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Application.LoadLevel(nextLevel);
    }

    }//end of class
