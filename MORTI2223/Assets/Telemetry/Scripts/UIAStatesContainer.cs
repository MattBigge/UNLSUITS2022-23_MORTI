using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UIAStatesContainer : MonoBehaviour
{

    [SerializeField]
    public bool emu1_is_booted = false;
    [SerializeField]
    public float uia_supply_pressure = 3000;
    [SerializeField]
    public float water_level = 100;
    [SerializeField]
    public float airlock_pressure = 14.7f;
    [SerializeField]
    public bool depress_pump_fault = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool getEmu1IsBooted()
    {
        return emu1_is_booted;
    }

    public float getUIASupplyPressure()
    {
        return uia_supply_pressure;
    }

    public float getWaterLevel()
    {
        return water_level;
    }

    public float getAirlockPressure()
    {
        return airlock_pressure;
    }

    public bool getDepressPumpFault()
    {
        return depress_pump_fault;
    }

    public void UpdateValues(string json){
        JsonUtility.FromJsonOverwrite(json, this);
    }
  





}
