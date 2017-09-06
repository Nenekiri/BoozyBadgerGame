using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class LevelUpLogic : MonoBehaviour {

    //intialize variables
    public float currentExp { get; set; }
    public float maxExp { get; set; }
    public float currentExp2 { get; set; }
    public float maxExp2 { get; set; }
    public float currentExp3 { get; set; }
    public float maxExp3 { get; set; }
    public float currentExp4 { get; set; }
    public float maxExp4 { get; set; }


    private tk2dSpriteAnimator anim;

    //public Sprite firstLevel;
    //public Sprite secondLevel;
    //public Sprite thirdLevel;
    //public Sprite fourthLevel;

    public string firstIdle;
    public string firstScream;
    public string secondIdle;
    public string secondScream;
    public string thirdIdle;
    public string thirdScream;
    public string fourthIdle;
    public string fourthScream;  


    public float threshold = 1.0f;
    public float sensitivity = 100;
    //public float loud = MicInput.MicLoudness;


    public Slider LevelBar;
    public Slider LevelBar2;
    public Slider LevelBar3;
    public Slider LevelBar4; 


	// Use this for initialization
	void Start ()
    {
        maxExp = 2000f;
        currentExp = 0f; 
        LevelBar.value = CalcExp();

        maxExp2 = 2000f;
        currentExp2 = 0f;
        LevelBar2.value = CalcExp2();

        maxExp3 = 2000f;
        currentExp3 = 0f;
        LevelBar3.value = CalcExp3();

        maxExp4 = 2000f;
        currentExp4 = 0f;
        LevelBar4.value = CalcExp4();

        //this.GetComponent<SpriteRenderer>().sprite = firstLevel;

        //get the animator
        anim = GetComponent<tk2dSpriteAnimator>();

    }

    void GainExp(float expValue)
    {
        if (LevelBar.IsActive())
        {
            currentExp += expValue;
            LevelBar.value = currentExp;
        }

        if (LevelBar2.IsActive())
        {
            currentExp2 += expValue;
            LevelBar2.value = currentExp2;
        }

        if (LevelBar3.IsActive())
        {
            currentExp3 += expValue;
            LevelBar3.value = currentExp3;
        }

        if (LevelBar4.IsActive())
        {
            currentExp4 += expValue;
            LevelBar4.value = currentExp4;
        }
    }

    float CalcExp()
    {
        return currentExp / maxExp;  
    }

    float CalcExp2()
    {
        return currentExp2 / maxExp2;
    }

    float CalcExp3()
    {
        return currentExp3 / maxExp3;
    }

    float CalcExp4()
    {
        return currentExp4 / maxExp4;
    }

    void LevelingSystem()
    {
        //Debug.Log("This is the mic loudness from the LevelUpLogic " + MicInput.MicLoudness);
        //Debug.Log(loud); 
        if (MicInput.MicLoudness * sensitivity > threshold)
        {
            Debug.Log("This is the current exp " + currentExp);
            if (currentExp >= 1)
            {
                Debug.Log("Reached this if statement");
                LevelBar.gameObject.SetActive(false);
                LevelBar2.gameObject.SetActive(true);
                //this.GetComponent<SpriteRenderer>().sprite = secondLevel;

                Debug.Log("This is the current exp2 " + currentExp);
                if (currentExp2 >= 1)
                {
                    LevelBar2.gameObject.SetActive(false);
                    LevelBar3.gameObject.SetActive(true);
                    //this.GetComponent<SpriteRenderer>().sprite = thirdLevel;

                    if (currentExp3 >= 1)
                    {
                        LevelBar3.gameObject.SetActive(false);
                        LevelBar4.gameObject.SetActive(true);
                        //this.GetComponent<SpriteRenderer>().sprite = fourthLevel;

                        if (currentExp4 >= 1)
                        {
                            //logic to turn on label that displays this is the max Level

                            //LevelBar3.gameObject.SetActive(false);
                            //LevelBar4.gameObject.SetActive(true);


                        }
                        else
                        {
                            GainExp(0.001f);
                            anim.Play(fourthScream);
                        }
                    }
                    else
                    {
                        GainExp(0.003f);
                        anim.Play(thirdScream);
                    }
                }
                else
                {
                    GainExp(0.005f);
                    anim.Play(secondScream);
                }

            }
            else
            {
                GainExp(0.01f);
                anim.Play(firstScream); 
            }


        }

        else
        {
            //This is where the system will check and play the idle animation if the person isn't yelling into their mic at the time. 

            //test to see which levelbar is currently active and then play the correct animation.
            if (LevelBar.IsActive())
            {
                anim.Play(firstIdle); 
            }
            else if (LevelBar2.IsActive())
            {
                anim.Play(secondIdle);
            }
            else if (LevelBar3.IsActive())
            {
                anim.Play(thirdIdle);
            }
            else if (LevelBar4.IsActive())
            {
                anim.Play(fourthIdle);
            }

        }
    }

	
	// Update is called once per frame
	void Update ()
    {
        LevelingSystem();
	}
}
