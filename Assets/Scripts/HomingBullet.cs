using UnityEngine;
using System.Collections;

public class HomingBullet : MonoBehaviour {

    public GameObject player;
    public string playerName;
    public int speed = 1; 


    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find(playerName);

        

    }
	
	// Update is called once per frame
	void Update ()
    {

        var dir = player.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);

    }

}//end of class
