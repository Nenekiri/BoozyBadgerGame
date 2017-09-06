using UnityEngine;
using System.Collections;

public class PointToNearestBrief : MonoBehaviour {

    public Transform tracking;
    public Transform center;
    Transform pivot;

    void Start()
    {
        pivot = new GameObject().transform;
        pivot.position = center.position;

        float dist = Vector3.Distance(center.position, transform.position);
        pivot.LookAt(tracking);
        pivot.parent = center;
        transform.position = center.position + pivot.forward * dist;
        transform.LookAt(tracking);
        transform.parent = pivot;
    }//end of start

    void Update()
    {
        Vector3 v3 = tracking.position;
        Quaternion rot = tracking.rotation;
        rot.y = 270; 
        v3.y = pivot.position.y;
        pivot.LookAt(v3);
    }//end of update



}//end of class
