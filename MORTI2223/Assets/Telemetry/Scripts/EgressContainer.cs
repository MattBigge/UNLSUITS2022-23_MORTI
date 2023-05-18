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
    bool ev1_water_waste_switch;
    [SerializeField]
    bool emu1_o2_supply_switch;
    [SerializeField]
    bool o2_vent_switch;
    [SerializeField]
    bool depress_pump_switch;

    float time = 2;

    public bool getPwrSwitch(){
        return emu1_pwr_switch;
    }

    public bool getSupplySwitch(){
        return ev1_supply_switch;
    }

    public bool getWaterWasteSwitch(){
        return ev1_water_waste_switch;
    }

    public bool getO2SupplySwitch(){
        return emu1_o2_supply_switch;
    }
    public bool getVentSwitch(){
        return o2_vent_switch;
    }
    
    public bool getDepressPumpSwitch(){
        return depress_pump_switch;
    }
    void Start()
    {

        
    }

    // Update is called once per frame
    public void UpdateValues(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
    }
}
