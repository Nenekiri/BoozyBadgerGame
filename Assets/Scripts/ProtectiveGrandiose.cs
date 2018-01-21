using UnityEngine;
using System.Collections;

public class ProtectiveGrandiose : MonoBehaviour {

    public SpriteRenderer sp;
    public Sprite busterBleaton;
    public ParticleSystem ps;

    // Use this for initialization
    void Start ()
    {
        sp = this.GetComponent<SpriteRenderer>();
        ps = this.GetComponent<ParticleSystem>();

        if (ps.isPlaying)
        {
            ps.Stop();
        }
        
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Dialoguer.GetGlobalBoolean(13) == true)
        {
            sp.sprite = busterBleaton;
            transform.localScale = new Vector3(6, 6, 1);
            if (!ps.isPlaying)
            {
                ps.Play();
            }
            
        }
	
	}//end of update

}//end of class
