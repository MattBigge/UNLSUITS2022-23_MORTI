using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class TelemetryLIB : MonoBehaviour
{
    static BiometricsContainer biometricsContainer = new BiometricsContainer();
    float updateDelay = 1f;
    public static string json = "";

    public static string globalURI = "http://ec2-3-137-219-57.us-east-2.compute.amazonaws.com:8080/api";
    // Start is called before the first frame update
    

  // starts/resets sim
    void Start()
    {
        StartCoroutine(stopSim());
        StartCoroutine(startSim());
    }

    // Update refreshes data every second to limit excessive calls. 
    void Update()
    {
        if(updateDelay < 0.5){
            StartCoroutine(getData());
        }else if(updateDelay < 0){
            biometricsContainer.setData(json);
            updateDelay = 1f;
        }
        updateDelay -= Time.deltaTime;
    
    }
    //async function to stop the simulation
    public static IEnumerator stopSim()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(globalURI + "/simulationcontrol/sim/1/stop"))
        {
            yield return webRequest.SendWebRequest();
            switch(webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    Debug.Log("Connection Error");
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.Log("Data Processing Error");
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.Log("Protocol Error");
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("Success" + " " + webRequest.downloadHandler.text);
                    
                    break;
            }
        }
    }
    //async function to start the simulation
    public static IEnumerator startSim()
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Get(globalURI + "/simulationcontrol/sim/1/stop"))
        {
            yield return webRequest.SendWebRequest();
            switch(webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    Debug.Log("Connection Error");
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.Log("Data Processing Error");
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.Log("Protocol Error");
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("Success" + " " + webRequest.downloadHandler.text);
                    break;
            }
        }
        using (UnityWebRequest webRequest = UnityWebRequest.Get(globalURI + "/simulationcontrol/sim/1/start"))
        {
            
            yield return webRequest.SendWebRequest();
            switch(webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    Debug.Log("Connection Error");
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.Log("Data Processing Error");
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.Log("Protocol Error");
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("Success" + " " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }


    // Update is called once per frame
    //async function to get the data from the server
    public static IEnumerator getData()
    {
        //make the request to the server to start the simulation
        using (UnityWebRequest webRequest = UnityWebRequest.Get(globalURI + "/simulationstate/1"))
        {
            yield return webRequest.SendWebRequest();
            switch(webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    Debug.Log("Connection Error");
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.Log("Data Processing Error");
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.Log("Protocol Error");
                    break;
                case UnityWebRequest.Result.Success:
                    //Debug.Log("Success" + " " + webRequest.downloadHandler.text);
                    json = webRequest.downloadHandler.text;
                    break;
            }
        
    }

    }
    //async function to resume the simulation
    public static IEnumerator pauseSim()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(globalURI + "/simulationcontrol/sim/1/pause"))
        {
            yield return webRequest.SendWebRequest();
            switch(webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    Debug.Log("Connection Error");
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.Log("Data Processing Error");
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.Log("Protocol Error");
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("Success" + " " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }

     public static int getId(){
        return biometricsContainer.id;
    }

    public static int getRoom(){
        return biometricsContainer.room;
    }

    public static bool getIsRunning(){
        return biometricsContainer.isRunning;
    }

    public static bool getIsPaused(){
        return biometricsContainer.isPaused;
    }

    public static float getTime(){
        return biometricsContainer.time;
    }

    public static string getTimer(){
        return biometricsContainer.timer;
    }

    public static string getStartedAt(){
        return biometricsContainer.started_at;
    }

    public static int getHeartBpm(){
        return biometricsContainer.heart_bpm;
    }

    public static float getPSub(){
        return biometricsContainer.p_sub;
    }

    public static float getPSuit(){
        return biometricsContainer.p_suit;
    }

    public static float getTSub(){
        return biometricsContainer.t_sub;
    }

    public static float getVFan(){
        return biometricsContainer.v_fan;
    }

    public static float getPO2(){
        return biometricsContainer.p_o2;
    }

    public static float getRateO2(){
        return biometricsContainer.rate_o2;
    }


    public static float getBatteryPercent(){
        return biometricsContainer.batteryPercent;
    }

    public static int getCapBattery(){
        return biometricsContainer.cap_battery;
    }

    public static float getBatteryOut(){
        return biometricsContainer.battery_out;
    }

    public static float getPH2OG(){
        return biometricsContainer.p_h2o_g;
    }

    public static float getPH2O1(){
        return biometricsContainer.p_h2o_1;
    }

    public static float getPSop(){
        return biometricsContainer.p_sop;
    }

    public static float getRateSop(){
        return biometricsContainer.rate_sop;
    }

    public static string getTBattery(){
        return biometricsContainer.t_battery;
    }

    public static float getTOxygenPrimary(){
        return biometricsContainer.t_oxygenPrimary;
    }

    public static float getTOxygenSec(){
        return biometricsContainer.t_oxygenSec;
    }

    public static float getOxPrimary(){
        return biometricsContainer.ox_primary;
    }

    public static float getOxSecondary(){
        return biometricsContainer.ox_secondary;
    }
    public static string getTOxygen(){
        return biometricsContainer.t_oxygen;
    }
    public static float getCapWater(){
        return biometricsContainer.cap_water;
    }

    public static string getTWater(){
        return biometricsContainer.t_water;
    }
    public static string getCreatedAt(){
        return biometricsContainer.created_at;
    }
    public static string getUpdatedAt(){
        return biometricsContainer.updated_at;
    }

}
