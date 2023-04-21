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
        StartCoroutine(UpdateValues());
        
        
    }

    IEnumerator UpdateValues()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            battery = TimeToInt.TimeToSec(TeleLIB.getTBattery());
            oxygen = TimeToInt.TimeToSec(TeleLIB.getTOxygen());
            water = TimeToInt.TimeToSec(TeleLIB.getTWater());
        
            oxygenTime.SetActive(false);
            waterTime.SetActive(false);
            batteryTime.SetActive(true);
            yield return new WaitForSeconds(10);

            waterTime.SetActive(false);
            batteryTime.SetActive(false);
            oxygenTime.SetActive(true);
            yield return new WaitForSeconds(10);

            oxygenTime.SetActive(false);
            batteryTime.SetActive(false);
            waterTime.SetActive(true);
            yield return new WaitForSeconds(10); 
            
            yield return new WaitForSeconds(1);
        }
    }

    void Update()
    {
        
}
}
