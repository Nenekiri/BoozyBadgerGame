using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class LetterManager : MonoBehaviour {


    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        text.color = new Color(255f, 255f, 255f);

    }


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void FixedUpdate()
    {
        text.text = LevelManager.collectedPapersStatic + "/" + LevelManager.paperNumberStatic;

        if (LevelManager.collectedPapersStatic >= LevelManager.paperNumberStatic)
        {
            text.color = new Color(215f, 215f, 0f);
        }
    }

}
