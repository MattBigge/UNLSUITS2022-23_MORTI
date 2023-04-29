using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuDisplayPageOne : MonoBehaviour
{


    public TMP_Text waterPercentage;
    public TMP_Text primaryOxygenPercentage;
    public TMP_Text secondaryOxygenPercentage;
    public TMP_Text externalPressure;
    public TMP_Text suitPressure;
    public TMP_Text primaryOxygenPressure;
    public TMP_Text secondaryOxygenPressure;
    public TMP_Text fanSpeed;

    void OnEnable()
    {
        StartCoroutine(UpdateValues2Sec());
    }


    IEnumerator UpdateValues2Sec()
        {
            yield return new WaitForSeconds(1);
            while (true)
            {
                waterPercentage.text = TeleLIB.getCapWater().ToString("0.00") + "%";
                primaryOxygenPercentage.text = TeleLIB.getOxPrimary().ToString("0.00") + "%";
                secondaryOxygenPercentage.text = TeleLIB.getOxSecondary().ToString("0.00") + "%";
                externalPressure.text = TeleLIB.getPSub().ToString("0.00") + " psia";
                suitPressure.text = TeleLIB.getPSuit().ToString("0.00") + " psid";
                primaryOxygenPressure.text = TeleLIB.getPO2().ToString("0.00") + " psia";
                secondaryOxygenPressure.text = TeleLIB.getPSop().ToString("0.00") + " psia";
                fanSpeed.text = TeleLIB.getVFan().ToString() + " RPM";
                yield return new WaitForSeconds(2);
            }
        }
}
