using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinInfo : MonoBehaviour
{
    enum pinType{ 
        ROCK,
        HOME,
        POI
    }   
    private pinType pinTypes;
    void Start()
    {
        
    }
    void setPinType(pinType setpin)
    {
        pinTypes = setpin;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
