using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckboxEgress : MonoBehaviour
{
    public Image EgressFanCheck;
    public Image OxygenSwitchCheck;
    public Image EgressAuxCheck;
    public Image EgressRCACheck;
    public Image EgressPumpCheck;

    void Start()
    {   
        StartCoroutine(UpdateValues1Sec());
    }

    IEnumerator UpdateValues1Sec()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            //TODO: if egress telelib is true set check active etc etc

            yield return new WaitForSeconds(1);
        }
    }
}
