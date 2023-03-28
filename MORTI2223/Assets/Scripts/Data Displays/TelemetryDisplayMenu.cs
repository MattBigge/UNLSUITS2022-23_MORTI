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
            evaTime.text = TeleLIB.getTimer().ToString();
            externalPressure.text = TeleLIB.getPSub().ToString();
            suitPressure.text = TeleLIB.getPSuit().ToString();
            fanSpeed.text = TeleLIB.getVFan().ToString();
            primaryOxygenPressure.text = TeleLIB.getPO2().ToString();
            primaryOxygenFlowRate.text = TeleLIB.getRateO2().ToString();
            batteryCapacity.text = TeleLIB.getCapBattery().ToString();
            waterGasPressure.text = TeleLIB.getPH2OG().ToString();
            waterLiquidPressure.text = TeleLIB.getPH2OL().ToString();
            secondaryOxygenPressure.text = TeleLIB.getPSop().ToString();
            secondaryOxygenFlowrate.text = TeleLIB.getRateSop().toString();
    }
}
}
