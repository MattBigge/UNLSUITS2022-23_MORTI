using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
// Serialize the class to create usefull getter functions
public class BiometricsContainer : MonoBehaviour
{
    public int id = -1;
    public int room = -1;
    public bool isRunning;
    public bool isPaused;
    public float time;
    public string timer;
    public string started_at;
    public int heart_bpm;
    public float p_sub;
    public float p_suit;
    public float t_sub;
    public float v_fan;
    public float p_o2;
    public float rate_o2;
    public float batteryPercent;
    public int cap_battery;
    public float battery_out;
    public float p_h2o_g;
    public float p_h2o_1;
    public float p_sop;
    public float rate_sop;
    public string t_battery;
    public float t_oxygenPrimary;
    public float t_oxygenSec;
    public float ox_primary;
    public float ox_secondary;
    public string t_oxygen;
    public float cap_water;
    public string t_water;
    public string created_at;
    public string updated_at;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setData(string json){
        JsonUtility.FromJsonOverwrite(json, this);
    }



   
}
