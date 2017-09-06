using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class PauseManager : MonoBehaviour {

    public GameObject pausePanel;

    public bool isPaused;

    public string[] Quips; 

    public Text BoozyAdvice; 

	// Use this for initialization
	void Start ()
    {
        isPaused = false;
        BoozyAdvice.text = (Quips[Random.Range(0, Quips.Length * 7) % Quips.Length]);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isPaused)
        {
            PauseGame(true); //show the pause screen
        }
        else
        {
            PauseGame(false); 
        }

        if (Input.GetButtonDown("Cancel"))
        {
            switchPause(); 
        }

	
	}//end of update


    void Awake()
    {
        //BoozyAdvice = GetComponent<Text>();
    }

    void PauseGame(bool state)
    {
        if (state)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
            pausePanel.SetActive(false); 
        }
    }//end of PauseGame method

    public void switchPause()
    {
        if (isPaused)
        {
            isPaused = false;
        }
        else
        {
            isPaused = true; 
        }

    }

    public void ChangeScene(string scene)
    {

        Application.LoadLevel(scene);


    }

}//end of class
