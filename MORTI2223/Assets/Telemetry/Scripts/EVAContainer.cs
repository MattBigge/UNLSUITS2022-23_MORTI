using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
// Serialize the class to create usefull getter functions
public class EVAContainer : MonoBehaviour
{
    [SerializeField]
    int id = -1;
    [SerializeField]
    int room_id = -1;
    [SerializeField]
    bool is_running;
    [SerializeField]
    bool is_paused;
    [SerializeField]
    float time;
    [SerializeField]
    string timer;
    [SerializeField]
    string started_at;
    [SerializeField]
    int heart_rate;
    [SerializeField]
    float sub_pressure;
    [SerializeField]
    float suit_pressure;
    [SerializeField]
    float temperature;
    [SerializeField]
    float fan_tachometer;
    [SerializeField]
    float o2_pressure;
    [SerializeField]
    float o2_rate;
    [SerializeField]
    float battery_percent;
    [SerializeField]
    int battery_capacity;
    [SerializeField]
    float battery_outputput;
    [SerializeField]
    float h2o_gas_pressure;
    [SerializeField]
    float h2o_liquid_pressure;
    [SerializeField]
    float sop_pressure;
    [SerializeField]
    float sop_rate;
    [SerializeField]
    string battery_time_left;
    [SerializeField]
    float oxygen_primary_time;
    [SerializeField]
    float oxygen_secondary_time;
    [SerializeField]
    float primary_oxygen;
    [SerializeField]
    float secondary_oxygen;
    [SerializeField]
    string o2_time_left;
    [SerializeField]
    float water_capacity;
    [SerializeField]
    string h2o_time_left;
    [SerializeField]
    string created_at;
    [SerializeField]
    string updated_at;
    [SerializeField]

    

    // Start is called before the first frame update

    void Update(){
    }
    
    public void setData(string json){
        JsonUtility.FromJsonOverwrite(json, this);
    }

    public int getId(){
        return id;
    }
    public int getRoom(){
        return room_id;
    }

    public bool getIsRunning(){
        return is_running;
    }
    public bool getIsPaused(){
        return is_paused;

    }
    public float getTime(){
        return time;
    }
    public string getTimer(){
        return timer;
    }
    public string getStartedAt(){
        return started_at;
    }
    public int getHeartBpm(){
        return heart_rate;
    }
    public float getPSub(){
        return sub_pressure;
    }
    public float getPSuit(){
        return suit_pressure;
    }
    public float getTSub(){
        return temperature;
    }
    public float getVFan(){
        return fan_tachometer;
    }
    public float getPO2(){
        return o2_pressure;
    }
    public float getRateO2(){
        return o2_rate;
    }
    public float getBatteryPercent(){
        return battery_percent;
    }
    public int getCapBattery(){
        return battery_capacity;
    }
    public float getBatteryOut(){
        return battery_outputput;
    }
    public float getPH2OG(){
        return h2o_gas_pressure;
    }
    public float getPH2OL(){
        return h2o_liquid_pressure;
    }
    public float getPSop(){
        return sop_pressure;
    }
    public float getRateSop(){
        return sop_rate;
    }
    public string getTBattery(){
        return battery_time_left;
    }
    public float getTOxygenPrimary(){
        return oxygen_primary_time;
    }
    public float getTOxygenSec(){
        return oxygen_secondary_time;
    }
    public float getOxPrimary(){
        return primary_oxygen;
    }
    public float getOxSecondary(){
        return secondary_oxygen;
    }
    public string getTOxygen(){
        return o2_time_left;
    }
    public float getCapWater(){
        return water_capacity;
    }
    public string getTWater(){
        return h2o_time_left;
    }
    public string getCreatedAt(){
        return created_at;
    }
    public string getUpdatedAt(){
        return updated_at;
    }
}



   
