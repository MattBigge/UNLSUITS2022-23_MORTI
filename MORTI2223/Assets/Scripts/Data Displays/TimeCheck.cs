using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class TimeCheck : MonoBehaviour
{

    public GameObject batteryTime;
    public GameObject oxygenTime;
    public GameObject waterTime;

    private double battery;
    private double oxygen;
    private double water;

    void Start()
    {
        batteryTime.SetActive(false);
        waterTime.SetActive(false);
        oxygenTime.SetActive(false);
        
        // battery = Convert.ToDouble(TeleLIB.getTBattery());
        // oxygen = Convert.ToDouble(TeleLIB.getTOxygen());
        // water = Convert.ToDouble(TeleLIB.getTWater());

        // if ((battery < oxygen) && (battery < water)){
        //     oxygenTime.SetActive(false);
        //     waterTime.SetActive(false);
        //     batteryTime.SetActive(true);
        // }
        // else if((oxygen < battery) && (oxygen < water)){
        //     batteryTime.SetActive(false);
        //     waterTime.SetActive(false);
        //     oxygenTime.SetActive(true);
        // }
        // else if((water < battery) && (water < oxygen)){
        //     batteryTime.SetActive(false);
        //     oxygenTime.SetActive(false);
        //     waterTime.SetActive(true);
        // }
    }

    void Update()
    {
        battery = Convert.ToDouble(TeleLIB.getTBattery());
        oxygen = Convert.ToDouble(TeleLIB.getTOxygen());
        water = Convert.ToDouble(TeleLIB.getTWater());


        // if ((battery < oxygen) && (battery < water)){
        //     oxygenTime.SetActive(false);
        //     waterTime.SetActive(false);
        //     batteryTime.SetActive(true);
        // }
        // if((oxygen < battery) && (oxygen < water)){
        //     batteryTime.SetActive(false);
        //     waterTime.SetActive(false);
        //     oxygenTime.SetActive(true);
        // }
        // if((water < battery) && (water < oxygen)){
        //     batteryTime.SetActive(false);
        //     oxygenTime.SetActive(false);
        //     waterTime.SetActive(true);
            
        
    }
}
