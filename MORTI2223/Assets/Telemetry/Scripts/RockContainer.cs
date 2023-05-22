using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RockContainer : MonoBehaviour
{

    [SerializeField]
    float SiO2;
    [SerializeField]
    float TiO2;
    [SerializeField]
    float Al2O3;
    [SerializeField]
    float FeO;
    [SerializeField]
    float MnO;
    [SerializeField]
    float MgO;
    [SerializeField]
    float CaO;
    [SerializeField]
    float K2O;
    [SerializeField]
    float P2O3;
    [SerializeField]


    public float [] getSample(){
        return new float[] {SiO2, TiO2, Al2O3, FeO, MnO, MgO, CaO, K2O, P2O3};
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateValues(string json){
        JsonUtility.FromJsonOverwrite(json, this);
    }

    public void updateTest(float[] values){
        SiO2 = values[0];
        TiO2 = values[1];
        Al2O3 = values[2];
        FeO = values[3];
        MnO = values[4];
        MgO = values[5];
        CaO = values[6];
        K2O = values[7];
        P2O3 = values[8];
    }
}
