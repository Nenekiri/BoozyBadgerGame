using UnityEngine;
using System.Collections;

public class MainMenuUI : MonoBehaviour {

    public static bool continued; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NewGame()
    {
        continued = false; 
        //Deletes the game's data and lets the player start fresh
        PlayerPrefs.DeleteAll();
        Application.LoadLevel("OpeningScene");

        //old method only cleared levels and not upgrades
        //PlayerPrefs.DeleteKey("savedLevel"); 
        //Application.LoadLevel("level1");
    }

    public void ContinueGame()
    {
        continued = true; 

        if (PlayerPrefs.GetFloat("savedLevel") == 1)
        {
            Application.LoadLevel("GameStart"); 
        }
        if (PlayerPrefs.GetFloat("savedLevel") == 2)
        {
            Application.LoadLevel("Office1-2");
        }
        if (PlayerPrefs.GetFloat("savedLevel") == 3)
        {
            Application.LoadLevel("Office1-3");
        }
        if (PlayerPrefs.GetFloat("savedLevel") == 4)
        {
            Application.LoadLevel("EagleBossFight");
        }
        if (PlayerPrefs.GetFloat("savedLevel") == 5)
        {
            Application.LoadLevel("Internet1-1");
        }
        if (PlayerPrefs.GetFloat("savedLevel") == 6)
        {
            Application.LoadLevel("Internet1-2");
        }
        if (PlayerPrefs.GetFloat("savedLevel") == 7)
        {
            Application.LoadLevel("Internet1-3");
        }
        if (PlayerPrefs.GetFloat("savedLevel") == 8)
        {
            Application.LoadLevel("Internet1-4");
        }
        if (PlayerPrefs.GetFloat("savedLevel") == 9)
        {
            Application.LoadLevel("InternetIntermission");
        }
        if (PlayerPrefs.GetFloat("savedLevel") == 10)
        {
            Application.LoadLevel("LewdFoxBoss");
        }
        if (PlayerPrefs.GetFloat("savedLevel") == 11)
        {
            Application.LoadLevel("Facility1-1");
        }
        if (PlayerPrefs.GetFloat("savedLevel") == 12)
        {
            Application.LoadLevel("Facility1-2");
        }
        if (PlayerPrefs.GetFloat("savedLevel") == 13)
        {
            Application.LoadLevel("Facility1-3");
        }
        if (PlayerPrefs.GetFloat("savedLevel") == 14)
        {
            Application.LoadLevel("Facility1-4");
        }
        if (PlayerPrefs.GetFloat("savedLevel") == 15)
        {
            Application.LoadLevel("Facility1-5");
        }
        if (PlayerPrefs.GetFloat("savedLevel") == 16)
        {
            Application.LoadLevel("BoozyBotFight");
        }
        if (PlayerPrefs.GetFloat("savedLevel") == 17)
        {
            Application.LoadLevel("Ohio");
        }

        //this is the general format for how I loaded levels in Ramen Man
        //if (PlayerPrefs.GetFloat("savedLevel") == 1)
        //{
        //    Application.LoadLevel("level1");
        //}
        //if (PlayerPrefs.GetFloat("savedLevel") == 2)
        //{
        //    Application.LoadLevel("level2");
        //}
        //if (PlayerPrefs.GetFloat("savedLevel") == 3)
        //{
        //    Application.LoadLevel("level3");
        //}
        //if (PlayerPrefs.GetFloat("savedLevel") == 4)
        //{
        //    Application.LoadLevel("waitingRoom");
        //}

        //if (PlayerPrefs.GetFloat("savedLevel") == 5)
        //{
        //    Application.LoadLevel("SW_1-1");
        //}

        //if (PlayerPrefs.GetFloat("savedLevel") == 6)
        //{
        //    Application.LoadLevel("SW_1-2");
        //}
        //if (PlayerPrefs.GetFloat("savedLevel") == 7)
        //{
        //    Application.LoadLevel("SW_1-3");
        //}
        //if (PlayerPrefs.GetFloat("savedLevel") == 8)
        //{
        //    Application.LoadLevel("SW_1-4");
        //}


    }

    public void ChangeScene(string scene)
    {

        Application.LoadLevel(scene);


    }

    public void NavigateURL(string URL)
    {
        Application.OpenURL(URL);
    }

    public void GTFO()
    {
        Application.Quit();
    }

    //methods for the Options menu

    public void ToggleMicAttack(bool toggleMic)
    {
        if (toggleMic == true)
        {
            Globals.DamageByMicrophone = true;
            Debug.Log("DBM value is true!"); 
        }
        else if (toggleMic == false)
        {
            Globals.DamageByMicrophone = false;
            Debug.Log("DBM value is false!");
        }

    }//end of ToggleMicAttack method

    public void ToggleMusic(bool toggleMusic)
    {
        if (toggleMusic == true)
        {
            Globals.MusicToggle = true;
            AudioListener.volume = 1; 
            Debug.Log("Music value is true!");
        }
        else if (toggleMusic == false)
        {
            Globals.MusicToggle = false;
            AudioListener.volume = 0; 
            Debug.Log("Music value is false!");
        }
    }

}//end of MainMenuUI
