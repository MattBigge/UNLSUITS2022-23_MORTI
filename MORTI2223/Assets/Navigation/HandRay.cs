using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRay : MonoBehaviour
{
    public GameObject HandToTrack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray TrackingRay = new Ray(HandToTrack.transform.position, HandToTrack.transform.forward);
        print(HandToTrack.transform.position);
    }
}
