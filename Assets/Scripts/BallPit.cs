using UnityEngine;
using System.Collections;

public class BallPit : MonoBehaviour {

    public GameObject player;
    public string playerName;
    public float distance = 0.0f;
    public SpriteRenderer sp;

    public Sprite ballPit;
    public Sprite ballPitOpen;


    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find(playerName);
        sp = this.GetComponent<SpriteRenderer>(); 
    }
	
	// Update is called once per frame
	void Update ()
    {
        distance = player.transform.position.x - transform.position.x;

        if (Mathf.Abs(distance) <= 10f)
        {
            sp.sprite = ballPitOpen;
        }
        else
        {
            sp.sprite = ballPit; 
        }
    }//end of Update

}
