using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ErrorContainer : MonoBehaviour
{
    [SerializeField]
    bool o2_error;
    [SerializeField]
    bool pump_error;
    [SerializeField]
    bool power_error;
    [SerializeField]
    bool fan_error;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateFromJson(string json){
        JsonUtility.FromJsonOverwrite(json, this);
    }

    public bool getO2Error(){
        return o2_error;
    }

    public bool getPumpError(){
        return pump_error;
    }
    
    public bool getPowerError(){
        return power_error;
    }

    public bool getFanError(){
        return fan_error;
    }
}
