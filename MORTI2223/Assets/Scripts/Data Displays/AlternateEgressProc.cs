using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlternateEgressProc : MonoBehaviour
{
    public TMP_Text mainWriting;
    private int stage = 0;
    public EgressContainer container;

 void OnEnable()
    {
        StartCoroutine(UpdateValues2Sec());
    }


    IEnumerator UpdateValues2Sec()
        {
            yield return new WaitForSeconds(1);
            while (true)
            {
                while (stage == 0){
                    if(container.getPwrSwitch() == false && container.getSupplySwitch() == false && container.getWaterWasteSwitch() == false &&
                    container.getO2SupplySwitch() == false && container.getVentSwitch() == false && container.getDepressPumpSwitch() == false){
                        stage++;
                        break;
                    }   
                }
                while (stage == 1){
                    mainWriting.text = "Switch EMU-1 Power to ON";
                    if (container.getPwrSwitch()){
                        stage++;
                        break;
                    }
                    yield return null;        
                }
                while (stage == 2){
                    mainWriting.text = "Switch O2 Vent to OPEN";
                    if (container.getVentSwitch()){
                        mainWriting.text = "Switch O2 Vent to CLOSE";
                        if (!container.getVentSwitch()){
                        stage++;
                        break;
                    }
                    } 
                    yield return null;
                    
                }
                while (stage == 3){
                    mainWriting.text = "Switch O2 Supply to OPEN";
                    if (container.getO2SupplySwitch()){
                        mainWriting.text = "Switch O2 Supply to CLOSE";
                        if (!container.getO2SupplySwitch()){
                        mainWriting.text = "Switch O2 Vent to OPEN";
                    }
                    }
                    if (container.getVentSwitch()){
                        mainWriting.text = "Switch O2 Vent to CLOSE";
                        if (!container.getVentSwitch()){
                        stage++;
                        break;
                    }
                    }
                    yield return null;
                    
                }
                while (stage == 4){
                    mainWriting.text = "Switch O2 Supply to OPEN";
                    if (container.getO2SupplySwitch()){
                        mainWriting.text = "Switch O2 Supply to CLOSE";
                        if (!container.getO2SupplySwitch()){
                        stage++;
                        break;
                    }     
                    }
                    yield return null;
                }
                while (stage == 5){
                    mainWriting.text = "Dump waste water and Switch EV-1 Waste to OPEN";
                    if (container.getWaterWasteSwitch()){
                        mainWriting.text = "Switch EV-1 Waste to CLOSE";
                        if (!container.getWaterWasteSwitch()){
                        mainWriting.text = "Switch EV-1 Supply to OPEN";
                    }
                    }
                    
                    if (container.getSupplySwitch()){
                        mainWriting.text = "Switch EV-1 Supply to CLOSE";
                        if (!container.getSupplySwitch()){
                        stage++;
                        break;
                    }
                    }
                    yield return null;
                    
                }
                while (stage == 6){
                        mainWriting.text = "Switch the Depress Pump to ON";
                        if (container.getDepressPumpSwitch()){
                            stage++;
                            break;
                        }
                        yield return null;
                    }
                
                while (stage == 7){
                    mainWriting.text = "Switch O2 Supply to OPEN";
                    if (container.getO2SupplySwitch()){
                        mainWriting.text = "Switch O2 Supply to CLOSE";
                        if (!container.getO2SupplySwitch()){
                            stage++;
                            break;
                        }
                    }
                    yield return null;
                }
                while (stage == 8){
                    mainWriting.text = "Switch Depress Pump to ON";
                    if (container.getDepressPumpSwitch()){
                        mainWriting.text = "Switch Depress Pump to OFF";
                        if(!container.getDepressPumpSwitch()){
                            stage++;
                            break;
                        }
                    }
                    yield return null;
                }
                while (stage == 9){
                    mainWriting.text = "UIA Procedures are complete, exit the airlock, close egress with menu";
                    break;
                }               
                yield return new WaitForSeconds(1);
            }
        }

}

