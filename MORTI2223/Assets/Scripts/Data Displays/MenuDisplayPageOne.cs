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
                waterPercentage.text = TeleLIB.getCapWater().ToString() + "%";
                primaryOxygenPercentage.text = TeleLIB.getOxPrimary().ToString() + "%";
                secondaryOxygenPercentage.text = TeleLIB.getOxSecondary().ToString() + "%";
                externalPressure.text = TeleLIB.getPSub().ToString() + "psia";
                suitPressure.text = TeleLIB.getPSuit().ToString() + "psid";
                primaryOxygenPressure.text = TeleLIB.getPO2().ToString() + "psia";
                secondaryOxygenPressure.text = TeleLIB.getPSop().ToString() + "psia";
                fanSpeed.text = TeleLIB.getVFan().ToString() + "RPM";
                yield return new WaitForSeconds(2);
            }
        }
}
