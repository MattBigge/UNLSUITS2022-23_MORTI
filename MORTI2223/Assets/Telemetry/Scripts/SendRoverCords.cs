using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SendRoverCords : MonoBehaviour
{

public TMP_Text coords;
private string uri = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    void OnConfirm(){
        float[] cords = new float[2];
        string[] split = coords.text.Split(',');
        cords[0] = float.Parse(split[0]);
        cords[1] = float.Parse(split[1]);
        Debug.Log(cords[0]);
    }
}
