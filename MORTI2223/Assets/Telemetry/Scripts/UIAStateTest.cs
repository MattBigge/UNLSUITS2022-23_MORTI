using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAStateTest : MonoBehaviour
{

    public UIAStatesContainer uiaStatesContainer;

    public EgressContainer egressContainer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changeStates());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator changeStates(){
        while(1==1){
        yield return new WaitForSeconds(5);
        if(egressContainer.getPwrSwitch()) uiaStatesContainer.emu1_is_booted = true;
        if(egressContainer.getVentSwitch()) uiaStatesContainer.uia_supply_pressure = 0;
        if(egressContainer.getWaterWasteSwitch()) uiaStatesContainer.water_level = 0;
        if(egressContainer.getDepressPumpSwitch()) uiaStatesContainer.airlock_pressure = 0;
        //uiaStatesContainer.depress_pump_fault = true;
        yield return new WaitForSeconds(5);
        uiaStatesContainer.emu1_is_booted = false;
        uiaStatesContainer.uia_supply_pressure = 4000;
        uiaStatesContainer.water_level = 100;
        uiaStatesContainer.airlock_pressure = 14.7f;
        uiaStatesContainer.depress_pump_fault = false;

        }

    }
}
