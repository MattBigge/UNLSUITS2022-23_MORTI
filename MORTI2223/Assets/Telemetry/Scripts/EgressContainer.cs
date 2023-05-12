using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EgressContainer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    bool emu1_pwr_switch;
    [SerializeField]
    bool ev1_supply_switch;
    [SerializeField]
    bool ev1_water_waste_script;
    [SerializeField]
    bool emu1_o2_supply_switch;
    [SerializeField]
    bool o2_vent_switch;
    [SerializeField]
    bool depress_pump_switch;

    float time = 2;

        /*
    getPwrSwitch(){
        return emu1_pwr_switch;
    }

    getSupplySwitch(){
        return ev1_supply_switch;
    }

    getWaterWasteScript(){
        return ev1_water_waste_script;
    }

    getO2SupplySwitch(){
        return emu1_o2_supply_switch;
    }
    getVentSwitch(){
        return o2_vent_switch;
    }
    
    getDepressPumpSwitch(){
        return depress_pump_switch;
    }
    
    
    void Start()
    {

        
    }

    void Update(){
        time += Time.deltaTime;
        if(time > 2){
            Debug.Log("fan_switch: " + fan_switch);
            time = 0;
        }
    }
    */

    // Update is called once per frame
    public void UpdateValues(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
    }
    
}
