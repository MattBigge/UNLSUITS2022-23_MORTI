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
                    mainWriting.text = "Switch EMU-1 Power to ON";
                    if (stateContainer.getEmu1IsBooted()){
                        stage++;
                        break;
                    }
                    yield return null;        
                }
                while (stage == 2){
                    mainWriting.text = "Switch O2 Vent to OPEN";
                    if (stateContainer.getUIASupplyPressure() < 23){
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
                    if (stateContainer.getUIASupplyPressure()>3000){
                        mainWriting.text = "Switch O2 Supply to CLOSE";
                        if (!container.getO2SupplySwitch()){
                        mainWriting.text = "Switch O2 Vent to OPEN";
                        firstPassed = true;
                    }
                    }
                    if (stateContainer.getUIASupplyPressure() < 23 && firstPassed){
                        mainWriting.text = "Switch O2 Vent to CLOSE";
                        if (!container.getVentSwitch()){
                        firstPassed = false;
                        stage++;
                        break;
                    }
                    }
                    yield return null;
                    
                }
                while (stage == 4){
                    mainWriting.text = "Switch O2 Supply to OPEN";
                    if (stateContainer.getUIASupplyPressure() > 1500){
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
                    if (stateContainer.getWaterLevel() < 5){
                        mainWriting.text = "Switch EV-1 Waste to CLOSE";
                        if (!container.getWaterWasteSwitch()){
                        mainWriting.text = "Switch EV-1 Supply to OPEN";
                        firstPassed = true;
                    }
                    }
                    
                    if (stateContainer.getWaterLevel() > 95 && firstPassed){
                        mainWriting.text = "Switch EV-1 Supply to CLOSE";
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
                        mainWriting.text = "Switch the Depress Pump to ON";
                        if (stateContainer.getAirlockPressure() < 10.2){
                            mainWriting.text = "Switch the Depress Pump to OFF";
                            if (!container.getDepressPumpSwitch()){
                            stage++;
                            }
                        }
                    }
                    yield return null;
                }
                
                while (stage == 7){
                    mainWriting.text = "Switch O2 Supply to OPEN";
                    if (stateContainer.getUIASupplyPressure() > 3000){
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
                    if (stateContainer.getAirlockPressure() < 0.1){
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
                    yield return null;
                }               
                yield return new WaitForSeconds(1);
            }
        }
}
