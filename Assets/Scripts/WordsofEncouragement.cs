using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class WordsofEncouragement : MonoBehaviour {


    Text displayText;
    public string firstWord;
    public string secondWord;
    public string thirdWord;
    public string fourthWord;

    public GameObject Slider1;
    public GameObject Slider2;
    public GameObject Slider3;
    public GameObject Slider4;
    private bool initiateEncouragement = false; 



    void Awake()
    {
        //PlayerPrefs.SetInt("highscore", 0); 


        displayText = GetComponent<Text>();

    }

    // Use this for initialization
    void Start ()
    {
        Slider1 = GameObject.Find("LevelSlider");
        Slider2 = GameObject.Find("LevelSlider2");
        Slider2.SetActive(false); 
        Slider3 = GameObject.Find("LevelSlider3");
        Slider3.SetActive(false);
        Slider4 = GameObject.Find("LevelSlider4");
        Slider4.SetActive(false);

        initiateEncouragement = false; 

    }

    // Update is called once per frame
    void Update ()
    {
        if (GetPumpedUpText.hasShownText && initiateEncouragement == false)
        {

            StartCoroutine(Delay(2.0f));

            initiateEncouragement = true; 

        }

        Debug.Log(Slider2.activeSelf);
        if (Slider2.activeSelf == true)
        {
            displayText.text = secondWord;
        }
        if (Slider3.activeSelf == true)
        {
            displayText.text = thirdWord;
        }
        if (Slider4.activeSelf == true)
        {
            displayText.text = fourthWord;
        }

    }//end of update


    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        displayText.text = firstWord;
        displayText.enabled = true;
    }//end of Delay
}
