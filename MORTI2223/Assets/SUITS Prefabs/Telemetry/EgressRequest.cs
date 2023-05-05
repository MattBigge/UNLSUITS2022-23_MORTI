using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

[System.Serializable]
public class EgressRequest : MonoBehaviour
{

    [SerializeField]
    public bool fan_switch;
    [SerializeField]
    public bool suit_power;
    [SerializeField]
    public bool o2_switch;
    [SerializeField]
    public bool aux;
    [SerializeField]
    public bool rca;
    [SerializeField]
    public bool pump;

    string url = "http://ec2-3-137-219-57.us-east-2.compute.amazonaws.com:3000/api/simulationcontrol/simctl/1/";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EgressStatus(){
        yield return new WaitForSeconds(5);
        UnityWebRequest www = UnityWebRequest.Get(url);

    }
}
