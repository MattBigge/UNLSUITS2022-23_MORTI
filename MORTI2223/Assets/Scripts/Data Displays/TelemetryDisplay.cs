using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TelemetryDisplay : MonoBehaviour
{

    //hud TeleLIB displays
    public TMP_Text heartRate;
    public TMP_Text bodyTemp;
    public TMP_Text currentEVALength;
    public TMP_Text batteryTime;
    public TMP_Text oxygenTime;
    public TMP_Text waterTime;

    //menu TeleLIB points
    // public TMP_Text evaTime;
    // public TMP_Text externalPressure;
    // public TMP_Text suitPressure;
    // public TMP_Text fanSpeed;
    // public TMP_Text primaryOxygenPressure;
    // public TMP_Text primaryOxygenFlowRate;
    // public TMP_Text batteryCapacity;
    // public TMP_Text waterGasPressure;
    // public TMP_Text waterLiquidPressure;
    // public TMP_Text secondaryOxygenPressure;
    // public TMP_Text secondaryOxygenFlowrate;

    // Start is called before the first frame update
    void Start()
    {
        //hud
        heartRate.text = TeleLIB.getHeartBpm().ToString();
        bodyTemp.text = TeleLIB.getTSub().ToString();
        currentEVALength.text = TeleLIB.getTimer().ToString();
        batteryTime.text = TeleLIB.getTBattery().ToString();
        oxygenTime.text = TeleLIB.getTOxygen().ToString();
        waterTime.text = TeleLIB.getTWater().ToString();

        //menu
        // evaTime.text = TeleLIB.getTime().ToString();
        // externalPressure.text = TeleLIB.getPSub().ToString();
        // suitPressure.text = TeleLIB.getPSuit().ToString();
        // fanSpeed.text = TeleLIB.getVFan().ToString();
        // primaryOxygenPressure.text = TeleLIB.getPO2().ToString();
        // primaryOxygenFlowRate.text = TeleLIB.getRateO2().ToString();
        // batteryCapacity.text = TeleLIB.getCapBattery().ToString();
        // waterGasPressure.text = TeleLIB.getPH2OG().ToString();
        // waterLiquidPressure.text = TeleLIB.getPH2OL().ToString();
        // secondaryOxygenPressure.text = TeleLIB.getPSop().ToString();
        // secondaryOxygenFlowrate.text = TeleLIB.getRateSop().toString();
    }

    // Update is called once per frame
    void Update()
    {

        heartRate.text = TeleLIB.getHeartBpm().ToString();
        bodyTemp.text = TeleLIB.getTSub().ToString();
        currentEVALength.text = TeleLIB.getTime().ToString();
        batteryTime.text = TeleLIB.getTBattery().ToString();
        oxygenTime.text = TeleLIB.getTOxygen().ToString();
        waterTime.text = TeleLIB.getTWater().ToString();

        // evaTime.text = TeleLIB.getTimer().ToString();
        // externalPressure.text = TeleLIB.getPSub().ToString();
        // suitPressure.text = TeleLIB.getPSuit().ToString();
        // fanSpeed.text = TeleLIB.getVFan().ToString();
        // primaryOxygenPressure.text = TeleLIB.getPO2().ToString();
        // primaryOxygenFlowRate.text = TeleLIB.getRateO2().ToString();
        // batteryCapacity.text = TeleLIB.getCapBattery().ToString();
        // waterGasPressure.text = TeleLIB.getPH2OG().ToString();
        // waterLiquidPressure.text = TeleLIB.getPH2OL().ToString();
        // secondaryOxygenPressure.text = TeleLIB.getPSop().ToString();
        // secondaryOxygenFlowrate.text = TeleLIB.getRateSop().toString();
    }
}
