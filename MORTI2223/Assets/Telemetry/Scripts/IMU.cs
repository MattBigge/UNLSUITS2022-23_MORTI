using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IMU : MonoBehaviour
{

    [SerializeField]
    float heading = 0;
    // Start is called before the first frame update

    public float getHeading()
    {
        return heading;
    }

    public void setIMU(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
    }
    // Update is called once per frame
    
}