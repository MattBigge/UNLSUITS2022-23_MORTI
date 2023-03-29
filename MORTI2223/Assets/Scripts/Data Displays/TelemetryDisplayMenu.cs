using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TelemetryDisplayMenu : MonoBehaviour
{
    private float delay = 2;

    //menu data points
    public TMP_Text evaTime;
    public TMP_Text externalPressure;
    public TMP_Text suitPressure;
    public TMP_Text fanSpeed;
    public TMP_Text primaryOxygenPressure;
    public TMP_Text primaryOxygenFlowRate;
    public TMP_Text batteryCapacity;
    public TMP_Text waterGasPressure;
    public TMP_Text waterLiquidPressure;
    public TMP_Text secondaryOxygenPressure;
    public TMP_Text secondaryOxygenFlowrate;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delay-= Time.deltaTime;

        if(delay < 0){
            evaTime.text = "" + TeleLIB.getTimer();
            externalPressure.text = "" + TeleLIB.getPSub();
            suitPressure.text = "" + TeleLIB.getPSuit();
            fanSpeed.text = "" + TeleLIB.getVFan();
            primaryOxygenPressure.text = "" + TeleLIB.getPO2();
            primaryOxygenFlowRate.text = "" + TeleLIB.getRateO2();
            batteryCapacity.text = "" + TeleLIB.getCapBattery();
            waterGasPressure.text = "" + TeleLIB.getPH2OG();
            waterLiquidPressure.text = "" + TeleLIB.getPH2OL();
            secondaryOxygenPressure.text = "" + TeleLIB.getPSop();
            secondaryOxygenFlowrate.text = "" + TeleLIB.getRateSop();
    }
}
}
