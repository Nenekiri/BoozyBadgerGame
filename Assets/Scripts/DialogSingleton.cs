using UnityEngine;
using System.Collections;

public class DialogSingleton : MonoBehaviour {

    //declares this script as a singleton, which means that there will only be one of these at all times even when transitioning between scenes
    private static DialogSingleton instance = null;
    public static DialogSingleton Instance
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

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
