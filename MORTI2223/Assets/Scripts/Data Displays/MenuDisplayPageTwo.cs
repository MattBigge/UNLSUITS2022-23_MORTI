using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuDisplayPageTwo : MonoBehaviour
{


    public TMP_Text batteryCapacity;
    public TMP_Text primaryOxygenFlowrate;
    public TMP_Text secondaryOxygenFlowrate;
    public TMP_Text waterGasPressure;
    public TMP_Text waterLiquidPressure;
    
    void Start()
    {
        StartCoroutine(UpdateValues2Sec());
    }
    IEnumerator UpdateValues2Sec()
        {
            yield return new WaitForSeconds(1);
            while (true)
            {
                batteryCapacity.text = TeleLIB.getCapBattery().ToString() + " amp-hr";
                primaryOxygenFlowrate.text = TeleLIB.getRateO2().ToString() + " psi/min";
                secondaryOxygenFlowrate.text = TeleLIB.getRateSop().ToString() + " psi/min";
                waterGasPressure.text = TeleLIB.getPH2OG().ToString() + " psia";
                waterLiquidPressure.text = TeleLIB.getPH2OL().ToString() + " psia";
                yield return new WaitForSeconds(2);
            }
        }
}