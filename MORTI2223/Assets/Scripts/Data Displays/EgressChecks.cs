using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EgressChecks : MonoBehaviour
{
    public TMP_Text mainWriting;
    public TMP_Text subWriting;

 void OnEnable()
    {
        StartCoroutine(UpdateValues2Sec());
    }


    IEnumerator UpdateValues2Sec()
        {
            yield return new WaitForSeconds(1);
            while (true)
            {
                //TODO: Check if fan switch is on
                mainWriting.text = "Turn on the fan switch.";
                //TODO: Check if suit power is on
                mainWriting.text = "Turn on the suit power.";
                //TODO: Check if the O2 switch is on
                mainWriting.text = "Turn on the oxygen switch.";
                //TODO: Check if aux is on
                mainWriting.text = "Turn on the AUX.";
                //TODO: Check if RCA is true
                mainWriting.text = "Turn on the RCA.";
                //TODO: Check if pump is flipped
                mainWriting.text = "Flip the pump.";



                yield return new WaitForSeconds(2);
            }
        }

}
