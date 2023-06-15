using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Position : MonoBehaviour
{

    [SerializeField]
    float lon = 0;
    [SerializeField]
    float lat = 0;
    // Start is called before the first frame update

    public float[] getPos()
    {
        return new float[] { lat, lon };
    }

    public void setPos(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
    }
    // Update is called once per frame
    
}
