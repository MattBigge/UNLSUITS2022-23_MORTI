using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TelemetryDisplayHUD : MonoBehaviour
{
    private float delay = 2;

    //hud data displays
    public TMP_Text heartRate;
    public TMP_Text bodyTemp;
    public TMP_Text currentEVALength;
    public TMP_Text batteryTime;
    public TMP_Text oxygenTime;
    public TMP_Text waterTime;


    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {
        delay-= Time.deltaTime;

        if(delay < 0){
            heartRate.text = TeleLIB.getHeartBpm().ToString();
            bodyTemp.text = TeleLIB.getTSub().ToString();
            currentEVALength.text = TeleLIB.getTimer().ToString();
            batteryTime.text = TeleLIB.getTBattery().ToString();
            oxygenTime.text = TeleLIB.getTOxygen().ToString();
            waterTime.text = TeleLIB.getTWater().ToString();
        }

    }
}
