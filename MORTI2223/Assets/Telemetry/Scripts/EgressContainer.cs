using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EgressContainer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    bool fan_switch;
    [SerializeField]
    bool suit_power;
    [SerializeField]
    bool O2_switch;
    [SerializeField]
    bool aux;
    [SerializeField]
    bool rca;
    [SerializeField]
    bool pump;

    float time = 2;

    public bool fan_switch_is_on(){
        return fan_switch;
    }

    public bool suit_power_is_on(){
        return suit_power;
    }

    public bool O2_switch_is_on(){
        return O2_switch;
    }

    public bool aux_is_on(){
        return aux;
    }

    public bool rca_is_on(){
        return rca;
    }

    public bool pump_is_on(){
        return pump;
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

    // Update is called once per frame
    public void UpdateValues(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
    }
}
