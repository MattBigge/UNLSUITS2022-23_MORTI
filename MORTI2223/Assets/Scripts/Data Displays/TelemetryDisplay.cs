using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TelemetryDisplay : MonoBehaviour
{
    private bool flag = false;


    //hud data displays
    public TMP_Text heartRate;
    public TMP_Text bodyTemp;
    public TMP_Text currentEVALength;
    public TMP_Text batteryTime;
    public TMP_Text oxygenTime;
    public TMP_Text waterTime;
    public TMP_Text longitudeAndLatitude;

    void Start()
    {   
        currentEVALength.text = "00:00:00";
        StartCoroutine(UpdateValues1Sec());
        StartCoroutine(UpdateValues2Sec());
    }

    IEnumerator UpdateValues2Sec()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            heartRate.text = TeleLIB.getHeartBpm().ToString();
            bodyTemp.text = TeleLIB.getTSub().ToString();
            longitudeAndLatitude.text = TeleLIB.get
            yield return new WaitForSeconds(2);
        }
    }

    IEnumerator UpdateValues1Sec()
    {
        yield return new WaitForSeconds(5);
        while (true)
        {
            if(flag){
            currentEVALength.text = TeleLIB.getTimer().ToString();
            batteryTime.text = TeleLIB.getTBattery().ToString();
            oxygenTime.text = TeleLIB.getTOxygen().ToString();
            waterTime.text = TeleLIB.getTWater().ToString();
            flag = false;
            }else{
            currentEVALength.text = TimeToInt.SecToTime(TimeToInt.TimeToSec(currentEVALength.text) + 1);
            Debug.Log("currentEVALength.text = " + currentEVALength.text);
            flag = true;
            }
            yield return new WaitForSeconds(1);
        }
    }
}
