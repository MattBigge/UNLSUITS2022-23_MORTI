using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EgressChecks : MonoBehaviour
{
    public TMP_Text mainWriting;
    public TMP_Text subWriting;
    int stage = 0;

 void OnEnable()
    {
        StartCoroutine(UpdateValues2Sec());
    }


    IEnumerator UpdateValues2Sec()
        {
            yield return new WaitForSeconds(1);
            while (true)
            {
                if (stage == 0){
                    if(EgressContainer.getPwrSwitch() == false && EgressContainer.getSupplySwitch() == false && EgressContainer.getWaterWasteScript() == false &&
                    EgressContainer.getO2SupplySwitch() == false EgressContainer.getVentSwitch() == false && EgressContainer.getDepressPumpSwitch() == false){
                        stage++;
                    }   
                }
                else if (stage = 1){
                    //TODO ENTER text
                    if (EgressContainer.getPwrSwitch()){
                        stage++;
                    }               
                }
                else if (stage = 2){
                    //TODO ENTER text
                    if (EgressContainer.getSupplySwitch()){
                        stage++;
                    }//TODO KILL ME KILL ME KILL ME 
                yield return new WaitForSeconds(2);
            }
        }

}
