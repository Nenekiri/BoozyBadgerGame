using UnityEngine;
using System.Collections;

public class MusicSingleton : MonoBehaviour {

    //declares this script as a singleton, which means that there will only be one of these at all times even when transitioning between scenes
    private static MusicSingleton instance = null;
    public static MusicSingleton Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    //declare some public variables I will need to get this functioning

    public AudioSource s;
    public AudioClip ac;
    public AudioClip startingScene; 
    public AudioClip firstLevel;
    public AudioClip EagleBoss;
    public AudioClip Internet;
    public AudioClip LewdFoxBoss; 




    //on start get the audiocomponent for the audio source
    void Start()
    {
        s = GetComponent<AudioSource>();

        s.clip = ac;
        s.Play();
    }


    void Update()
    {

        if (Application.loadedLevelName == "OpeningScene")
        {
            s.clip = startingScene;
            if (!s.isPlaying)
            {
                s.Play();
            }
        }

        if (Application.loadedLevelName == "GameStart")
        {
            s.clip = firstLevel;
            if (!s.isPlaying)
            {
                s.Play();
            }
        }

        if (Application.loadedLevelName == "EagleBossFight")
        {
            s.clip = EagleBoss;
            if (!s.isPlaying)
            {
                s.Play();
            }
        }

        if (Application.loadedLevelName == "Internet1-1")
        {
            s.clip = Internet;
            if (!s.isPlaying)
            {
                s.Play();
            }
        }

        if (Application.loadedLevelName == "LewdFoxBoss")
        {
            s.clip = LewdFoxBoss;
            if (!s.isPlaying)
            {
                s.Play();
            }
        }

        //as long as I put Menu in the name of the level this should fix the problem for those menus as well
        //if (Application.loadedLevelName.Contains("Menu"))
        //{
        //    s.enabled = false;
        //    RandomMusic();
        //}
        //else
        //{
        //    s.enabled = true;


        //}


    }//end of update



}//end of MusicSingleton
