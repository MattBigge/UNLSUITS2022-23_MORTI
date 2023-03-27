using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class TeleLIB : MonoBehaviour
{
    public ConnScript connection;
    static EVAContainer biometricsContainer;

    public static string globalURI = "http://ec2-3-137-219-57.us-east-2.compute.amazonaws.com:8080/api";
    
    void Start(){
       StartCoroutine(startSim());
       StartCoroutine(stopSim());
    }
    
    public static void setContainer(EVAContainer container){
        biometricsContainer = container;
    }
     public static int getId(){
        return biometricsContainer.getId();
    }

    public static int getRoom(){
        return biometricsContainer.getRoom();
    }

    public static bool getIsRunning(){
        return biometricsContainer.getIsRunning();
    }

    public static bool getIsPaused(){
        return biometricsContainer.getIsPaused();
    }

    public static float getTime(){
        return biometricsContainer.getTime();
    }

    public static string getTimer(){
        return biometricsContainer.getTimer();
    }

    public static string getStartedAt(){
        return biometricsContainer.getStartedAt();
    }

    public static  int getHeartBpm(){
        return biometricsContainer.getHeartBpm();
    }

    public static float getPSub(){
        return biometricsContainer.getPSub();
    }

    public static float getPSuit(){
        return biometricsContainer.getPSuit();
    }

    public static float getTSub(){
        return biometricsContainer.getTSub();
    }

    public static float getVFan(){
        return biometricsContainer.getVFan();
    }

    public static  float getPO2(){
        return biometricsContainer.getPO2();
    }

    public static float getRateO2(){
        return biometricsContainer.getRateO2();
    }


    public static float getBatteryPercent(){
        return biometricsContainer.getBatteryPercent();
    }

    public static int getCapBattery(){
        return biometricsContainer.getCapBattery();
    }

    public static float getBatteryOut(){
        return biometricsContainer.getBatteryOut();
    }

    public static float getPH2OG(){
        return biometricsContainer.getPH2OG();
    }

    public static float getPH2OL(){
        return biometricsContainer.getPH2OL();
    }

    public static float getPSop(){
        return biometricsContainer.getPSop();
    }

    public static float getRateSop(){
        return biometricsContainer.getRateSop();
    }

    public static string getTBattery(){
        return biometricsContainer.getTBattery();
    }

    public static float getTOxygenPrimary(){
        return biometricsContainer.getTOxygenPrimary();
    }

    public static float getTOxygenSec(){
        return biometricsContainer.getTOxygenSec();
    }

    public static  float getOxPrimary(){
        return biometricsContainer.getOxPrimary();
    }

    public static float getOxSecondary(){
        return biometricsContainer.getOxSecondary();
    }
    public static string getTOxygen(){
        return biometricsContainer.getTOxygen();
    }
    public static float getCapWater(){
        return biometricsContainer.getCapWater();
    }

    public static string getTWater(){
        return biometricsContainer.getTWater();
    }
    public static string getCreatedAt(){
        return biometricsContainer.getCreatedAt();
    }
    public static string getUpdatedAt(){
        return biometricsContainer.getUpdatedAt();
    }

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
    }

    public static IEnumerator stopSim()
    {
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

}
