using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CordGrabber : MonoBehaviour
{

    public roverPOI rover;
    public bool mode;

    public float lattidue;
    public float longitude;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       lattidue = rover.getLat();
       longitude = rover.getLon();
       mode = rover.getMode();
    }
}
