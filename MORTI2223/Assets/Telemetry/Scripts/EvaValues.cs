using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EvaValues : MonoBehaviour
{

    string json = "";
    public EgressContainer egressContiner;
    string url = "http://ec2-3-137-219-57.us-east-2.compute.amazonaws.com:8080/api/simulationcontrol/simctl/1/fan_switch";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetEvaValues());
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    IEnumerator GetEvaValues()
    {
        while(true){
            UnityWebRequest www = UnityWebRequest.Get(url);
            yield return www.SendWebRequest();
            www = UnityWebRequest.Get(url);
            yield return www.SendWebRequest();
            egressContiner.UpdateValues(www.downloadHandler.text);
            yield return new WaitForSeconds(1);
        }
          
    }
}
