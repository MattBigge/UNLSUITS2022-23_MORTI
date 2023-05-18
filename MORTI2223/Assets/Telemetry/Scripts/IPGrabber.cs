using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IPGrabber : MonoBehaviour
{

     string ip;
     public TextMeshProUGUI ipObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ip = ipObj.text;
    }

    public string getIP(){
        return ip;
    }
}
