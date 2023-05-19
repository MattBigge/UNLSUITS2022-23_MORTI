// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class EgressChecks : MonoBehaviour
// {
//     public TMP_Text mainWriting;
//     public TMP_Text subWriting;
//     int stage = 0;
//     EgressContainer container;

//  void OnEnable()
//     {
//         StartCoroutine(UpdateValues2Sec());
//     }


//     IEnumerator UpdateValues2Sec()
//         {
//             yield return new WaitForSeconds(1);
//             while (true)
//             {
//                 if (stage == 0){
//                     if(container.getPwrSwitch() == false && container.getSupplySwitch() == false && container.getWaterWasteSwitch() == false &&
//                     container.getO2SupplySwitch() == false && container.getVentSwitch() == false && container.getDepressPumpSwitch() == false){
//                         stage++;
//                     }   
//                 }
//                 else if (stage == 1){
//                     mainWriting.text = "Switch EMU-1 Power to ON";
//                     if (/*check if EMU is booted*/){
//                         stage++;
//                     }               
//                 }
//                 else if (stage == 2){
//                     mainWriting.text = "Switch O2 Vent to OPEN";
//                     if (/*UIA Supply Pressure < 23 psi*/){
//                         mainWriting.text = "Switch O2 Vent to CLOSE";
//                         if (!container.getVentSwitch()){
//                         stage++;
//                     }
//                     } 
                    
//                 }
//                 else if (stage == 3){
//                     mainWriting.text = "Switch O2 Supply to OPEN";
//                     if (/*UIA Supply pressure < 23 psi*/){
//                         mainWriting.text = "Switch O2 Supply to CLOSE";
//                         if (!container.getO2SupplySwitch()){
//                         mainWriting.text = "Switch O2 Vent to OPEN";
//                     }
//                     }
//                     if (/*UIA Supply Pressure < 23 psi*/){
//                         mainWriting.text = "Switch O2 Vent to CLOSE";
//                         if (!container.getVentSwitch()){
//                         stage++;
//                     }
//                     }
                    
//                 }
//                 else if (stage == 4){
//                     mainWriting.text = "Switch O2 Supply to OPEN";
//                     if (/* UIA Supply pressure > 1500 */){
//                         mainWriting.text = "Switch O2 Supply to CLOSE";
//                         if (!container.getO2SupplySwitch()){
//                         stage++;
//                     }     
//                     }
//                 }
//                 else if (stage == 5){
//                     mainWriting.text = "Dump waste water and Switch EV-1 Waste to OPEN";
//                     if (/*when water level is < 5%*/){
//                         mainWriting.text = "Switch EV-1 Waste to CLOSE";
//                         if (!container.getWaterWasteSwitch()){
//                         mainWriting.text = "Switch EV-1 Supply to OPEN";
//                     }
//                     }
                    
//                     if (/* when water level is > 95%*/){
//                         mainWriting.text = "Switch EV-1 Supply to CLOSE";
//                         if (!container.getSupplySwitch()){
//                         stage++;
//                     }
//                     }
                    
//                 }
//                 else if (stage == 6){
//                     if (/* pump fault is true*/){
//                         mainWriting.text = "Switch the Depress Pump to OFF";
//                     }
//                     else{
//                         mainWriting.text = "Switch the Depress Pump to ON";
//                         if (/* airlock  is < 10.2 psi */){
//                             stage++;
//                         }
//                     }
//                 }
//                 else if (stage == 7){
//                     mainWriting.text = "Switch O2 Supply to OPEN";
//                     if (/* uia  supply pressure > 3000 psi*/){
//                         mainWriting.text = "Switch O2 Supply to CLOSE";
//                         if (!container.getO2SupplySwitch()){
//                             stage++;
//                         }
//                     }
//                 }
//                 else if (stage == 8){
//                     mainWriting.text = "Switch Depress Pump to ON";
//                     if (/* airlock pressure is  < 0.1 psi*/){
//                         mainWriting.text = "Switch Depress Pump to OFF";
//                         if(!container.getDepressPumpSwitch()){
//                             stage++;
//                         }
//                     }
//                 }
//                 else if (stage == 9){
//                     mainWriting.text = "UIA Procedures are complete, exit the airlock, close egress with menu";
//                 }               
//                 yield return new WaitForSeconds(1);
//             }
//         }

// }
