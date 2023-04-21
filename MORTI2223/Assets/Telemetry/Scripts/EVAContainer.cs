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
    int room = -1;
    [SerializeField]
    bool isRunning;
    [SerializeField]
    bool isPaused;
    [SerializeField]
    float time;
    [SerializeField]
    string timer;
    [SerializeField]
    string started_at;
    [SerializeField]
    int heart_bpm;
    [SerializeField]
    float p_sub;
    [SerializeField]
    float p_suit;
    [SerializeField]
    float t_sub;
    [SerializeField]
    float v_fan;
    [SerializeField]
    float p_o2;
    [SerializeField]
    float rate_o2;
    [SerializeField]
    float batteryPercent;
    [SerializeField]
    int cap_battery;
    [SerializeField]
    float battery_out;
    [SerializeField]
    float p_h2o_g;
    [SerializeField]
    float p_h2o_l;
    [SerializeField]
    float p_sop;
    [SerializeField]
    float rate_sop;
    [SerializeField]
    string t_battery;
    [SerializeField]
    float t_oxygenPrimary;
    [SerializeField]
    float t_oxygenSec;
    [SerializeField]
    float ox_primary;
    [SerializeField]
    float ox_secondary;
    [SerializeField]
    string t_oxygen;
    [SerializeField]
    float cap_water;
    [SerializeField]
    string t_water;
    [SerializeField]
    string created_at;
    [SerializeField]
    string updated_at;
    [SerializeField]

    

    // Start is called before the first frame update
    
    public void setData(string json){
        JsonUtility.FromJsonOverwrite(json, this);
    }

    public int getId(){
        return id;
    }
    public int getRoom(){
        return room;
    }

    public bool getIsRunning(){
        return isRunning;
    }
    public bool getIsPaused(){
        return isPaused;

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
        return heart_bpm;
    }
    public float getPSub(){
        return p_sub;
    }
    public float getPSuit(){
        return p_suit;
    }
    public float getTSub(){
        return t_sub;
    }
    public float getVFan(){
        return v_fan;
    }
    public float getPO2(){
        return p_o2;
    }
    public float getRateO2(){
        return rate_o2;
    }
    public float getBatteryPercent(){
        return batteryPercent;
    }
    public int getCapBattery(){
        return cap_battery;
    }
    public float getBatteryOut(){
        return battery_out;
    }
    public float getPH2OG(){
        return p_h2o_g;
    }
    public float getPH2OL(){
        return p_h2o_l;
    }
    public float getPSop(){
        return p_sop;
    }
    public float getRateSop(){
        return rate_sop;
    }
    public string getTBattery(){
        return t_battery;
    }
    public float getTOxygenPrimary(){
        return t_oxygenPrimary;
    }
    public float getTOxygenSec(){
        return t_oxygenSec;
    }
    public float getOxPrimary(){
        return ox_primary;
    }
    public float getOxSecondary(){
        return ox_secondary;
    }
    public string getTOxygen(){
        return t_oxygen;
    }
    public float getCapWater(){
        return cap_water;
    }
    public string getTWater(){
        return t_water;
    }
    public string getCreatedAt(){
        return created_at;
    }
    public string getUpdatedAt(){
        return updated_at;
    }
}



   
