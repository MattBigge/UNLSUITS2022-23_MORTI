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

    private bool firstPassed = false;

 void OnEnable()
    {
        StartCoroutine(UpdateValues2Sec());
    }


    IEnumerator UpdateValues2Sec()
        {
            yield return new WaitForSeconds(1);
            while (true)
            {
                yield return new WaitForSeconds(1);
                
                while (stage == 0){
                    mainWriting.text = "Make Sure all Switches are Off";
                    if(container.getPwrSwitch() == false && container.getSupplySwitch() == false && container.getWaterWasteSwitch() == false &&
                    container.getO2SupplySwitch() == false && container.getVentSwitch() == false && container.getDepressPumpSwitch() == false){
                        stage=1;
                        break;
                    }   
                    yield return null;
                }
                while (stage == 1){
                    mainWriting.text = "Switch EMU-1 Power to ON and Wait For Boot";
                    if (stateContainer.getEmu1IsBooted()){
                        stage=2;
                        break;
                    }
                    yield return null;        
                }
                while (stage == 2){
                    mainWriting.text = "Switch O2 Vent to OPEN and Wait for Pressure Change";
                    while (stateContainer.getUIASupplyPressure() < 23 && stage == 2){
                        mainWriting.text = "Switch O2 Vent to CLOSE";
                        if (!container.getVentSwitch()){
                        stage=3;
                    }
                    yield return null;
                    } 
                    yield return null;
                    
                }
                while (stage == 3){
                    if (!firstPassed) mainWriting.text = "Switch EV-1 Oxygen to OPEN and Wait for Pressure Change";
                    while (stateContainer.getUIASupplyPressure()>3000 && !firstPassed){
                        mainWriting.text = "Switch EV-1 Oxygen to CLOSE and Wait";
                        if (!container.getO2SupplySwitch()){
                        mainWriting.text = "Switch O2 Vent to OPEN and Wait for Prssure Change";
                        firstPassed = true;
                        break;
                    }
                    yield return null;
                    }
                    while (stateContainer.getUIASupplyPressure() < 23 && firstPassed){
                        mainWriting.text = "Switch O2 Vent to CLOSE and Wait for Confirmation";
                        if (!container.getVentSwitch()){
                        firstPassed = false;
                        stage=4;
                        break;
                    }
                    yield return null;
                    }
                    yield return null;
                    
                }
                while (stage == 4){
                    mainWriting.text = "Switch EV-1 Oxygen to OPEN and Wait for Pressure Change";
                    if (stateContainer.getUIASupplyPressure() > 1500){
                        mainWriting.text = "Switch EV-1 Oxygen to CLOSE and Wait for Confirmation";
                        if (!container.getO2SupplySwitch()){
                        stage=5;
                        break;
                    }     
                    }
                    yield return null;
                }
                while (stage == 5){
                    if (!firstPassed) mainWriting.text = "Dump waste water and Switch EV-1 Waste to OPEN, Wait for Water Level to Fall";
                    while (stateContainer.getWaterLevel() < 5){
                        mainWriting.text = "Switch EV-1 Waste to CLOSE and Wait for Confirmation";
                        if (!container.getWaterWasteSwitch()){
                        mainWriting.text = "Switch EV-1 Supply to OPEN and Wait for Water Level to Rise";
                        firstPassed = true;
                        break;
                    }
                    yield return null;
                    }
                    
                    while (stateContainer.getWaterLevel() > 95 && firstPassed){
                        mainWriting.text = "Switch EV-1 Supply to CLOSE and Wait for Confirmation";
                        if (!container.getSupplySwitch()){
                        firstPassed = false;
                        stage=6;
                        break;
                    }
                    yield return null;
                    }
                    yield return null;
                    
                }
                while (stage == 6){
                    if (stateContainer.getDepressPumpFault()){
                        mainWriting.text = "Switch the Depress Pump to OFF";
                    }
                    else{
                        mainWriting.text = "Switch the Depress Pump to ON and Wait for Airlock Pressure Change";
                        if (stateContainer.getAirlockPressure() < 10.2 && !stateContainer.getDepressPumpFault()){
                            mainWriting.text = "Switch the Depress Pump to OFF and Wait for Confirmation";
                            if (!container.getDepressPumpSwitch()){
                            stage=7;
                            }
                        }
                    }
                    yield return null;
                }
                
                while (stage == 7){
                    mainWriting.text = "Switch EV-1 Oxygen to OPEN and Wait for Pressure Change";
                    if (stateContainer.getUIASupplyPressure() > 3000){
                        mainWriting.text = "Switch EV-1 Oxygen to CLOSE and Wait for Confirmation";
                        if (!container.getO2SupplySwitch()){
                            stage=8;
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
                            stage=9;
                            break;
                        }
                    }
                    yield return null;
                }
                if (stage == 9){
                    mainWriting.text = "UIA Procedures are Complete, Exit the Airlock, Close Egress with Menu";
                    
                }               
            }
        }
}
