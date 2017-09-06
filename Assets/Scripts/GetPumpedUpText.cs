using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class GetPumpedUpText : MonoBehaviour {

    public static bool hasShownText = false;
    Text displayText; 
    public string firstWord; 
    public string secondWord; 
    public string thirdWord;

    void Awake()
    {
        //PlayerPrefs.SetInt("highscore", 0); 


        displayText = GetComponent<Text>();

    }

    // Use this for initialization
    void Start ()
    {
        hasShownText = false; 
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hasShownText == false)
        {
            StartCoroutine(ShowMessage(firstWord, secondWord, thirdWord, .5f));
            hasShownText = true; 
        }
	
	}

    IEnumerator ShowMessage(string message1, string message2, string message3, float delay)
    {
        //display and hide first message
        displayText.text = message1;
        displayText.enabled = true;
        yield return new WaitForSeconds(delay);
        displayText.enabled = false;

        //display and hide 2nd message
        displayText.text = message2;
        displayText.enabled = true;
        yield return new WaitForSeconds(delay);
        displayText.enabled = false;

        //display and hide third message
        displayText.text = message3;
        displayText.enabled = true;
        yield return new WaitForSeconds(delay);
        displayText.enabled = false;
    }


}
