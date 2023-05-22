using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EgressProcedure : MonoBehaviour
{
    public TMP_Text mainWriting;
    private int stage = 0;
    public EgressContainer container;

    public UIAStatesContainer stateContainer;

    private bool firstPassed;

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
                    mainWriting.text = "Switch EMU-1 Power to ON and Wait For Boot";
                    if (stateContainer.getEmu1IsBooted()){
                        stage++;
                        break;
                    }
                    yield return null;        
                }
                while (stage == 2){
                    mainWriting.text = "Switch O2 Vent to OPEN and Wait for Pressure Change";
                    if (stateContainer.getUIASupplyPressure() < 23){
                        mainWriting.text = "Switch O2 Vent to CLOSE and Wait for Confirmation";
                        if (!container.getVentSwitch()){
                        stage++;
                        break;
                    }
                    } 
                    yield return null;
                    
                }
                while (stage == 3){
                    mainWriting.text = "Switch O2 Supply to OPEN and Wait for Pressure Change";
                    if (stateContainer.getUIASupplyPressure()>3000){
                        mainWriting.text = "Switch O2 Supply to CLOSE and Wait for Confirmation";
                        if (!container.getO2SupplySwitch()){
                        mainWriting.text = "Switch O2 Vent to OPEN and Wait for Prssure Change";
                        firstPassed = true;
                    }
                    }
                    if (stateContainer.getUIASupplyPressure() < 23 && firstPassed){
                        mainWriting.text = "Switch O2 Vent to CLOSE and Wait for Confirmation";
                        if (!container.getVentSwitch()){
                        firstPassed = false;
                        stage++;
                        break;
                    }
                    }
                    yield return null;
                    
                }
                while (stage == 4){
                    mainWriting.text = "Switch O2 Supply to OPEN and Wait for Pressure Change";
                    if (stateContainer.getUIASupplyPressure() > 1500){
                        mainWriting.text = "Switch O2 Supply to CLOSE and Wait for Confirmation";
                        if (!container.getO2SupplySwitch()){
                        stage++;
                        break;
                    }     
                    }
                    yield return null;
                }
                while (stage == 5){
                    mainWriting.text = "Dump waste water and Switch EV-1 Waste to OPEN, Wait for Water Level to Fall";
                    if (stateContainer.getWaterLevel() < 5){
                        mainWriting.text = "Switch EV-1 Waste to CLOSE and Wait for Confirmation";
                        if (!container.getWaterWasteSwitch()){
                        mainWriting.text = "Switch EV-1 Supply to OPEN and Wait for Water Level to Rise";
                        firstPassed = true;
                    }
                    }
                    
                    if (stateContainer.getWaterLevel() > 95 && firstPassed){
                        mainWriting.text = "Switch EV-1 Supply to CLOSE and Wait for Confirmation";
                        if (!container.getSupplySwitch()){
                        firstPassed = false;
                        stage++;
                        break;
                    }
                    }
                    yield return null;
                    
                }
                while (stage == 6){
                    if (stateContainer.getDepressPumpFault()){
                        mainWriting.text = "Switch the Depress Pump to OFF";
                    }
                    else{
                        mainWriting.text = "Switch the Depress Pump to ON and Wait for Airlock Pressure Change";
                        if (stateContainer.getAirlockPressure() < 10.2){
                            mainWriting.text = "Switch the Depress Pump to OFF and Wait for Confirmation";
                            if (!container.getDepressPumpSwitch()){
                            stage++;
                            }
                        }
                    }
                    yield return null;
                }
                
                while (stage == 7){
                    mainWriting.text = "Switch O2 Supply to OPEN and Wait for Pressure Change";
                    if (stateContainer.getUIASupplyPressure() > 3000){
                        mainWriting.text = "Switch O2 Supply to CLOSE and Wait for Confirmation";
                        if (!container.getO2SupplySwitch()){
                            stage++;
                            break;
                        }
                    }
                    yield return null;
                }
                while (stage == 8){
                    mainWriting.text = "Switch Depress Pump to ON and Wait for Airlock Pressure Change";
                    if (stateContainer.getAirlockPressure() < 0.1){
                        mainWriting.text = "Switch Depress Pump to OFF and Wait for Confirmation";
                        if(!container.getDepressPumpSwitch()){
                            stage++;
                            break;
                        }
                    }
                    yield return null;
                }
                while (stage == 9){
                    mainWriting.text = "UIA Procedures are Complete, Exit the Airlock, Close Egress with Menu";
                    yield return null;
                }               
            }
        }
}
