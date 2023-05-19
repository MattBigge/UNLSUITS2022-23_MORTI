using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TSS;

public class TSSManager : MonoBehaviour
{
    // Start is called before the first frame update
   TSSConnection tss;
    string tssUri;

     EVAContainer evaContainer;

     Position position;
     
    int msgCount = 0;

    // Start is called before the first frame update
    // In 
    async void Start()
    {
        tss = new TSSConnection();
        evaContainer = new EVAContainer();
        position = new Position();
        TeleLIB.setBioContainer(evaContainer);
        TeleLIB.setPosContainer(position);
        Connect();
        //The rest of the Start() method is for setting up the sample

    }

    // Update is called once per frame
    void Update()
    {
        // Updates the websocket once per frame
        tss.Update();
        

    }

    public async void Connect()
    {
      
        string team_name = "RED-MORTI";
        string username = "VK08";
        string university = "University of Nebraska-Lincoln";
        string user_guid = "66b6f3a5-63ca-4c49-95d1-e64d3a85a3a9";
        tssUri = "ws://localhost:3001";

        // Pass in your team's information here. user_guid is most important - it must match your visionkit
        var connecting = tss.ConnectToURI(tssUri, team_name, username, university, user_guid);


        Debug.Log("Connecting to " + tssUri);

        // Create a function that takes a single parameter of type TSSMsg and returns void. For example:
        // public static void PrintInfo(TSS.Msgs.TSSMsg tssMsg) { ... }
        // Then subscribe to the OnTSSTelemetryMsg with the following syntax: tss.OnTSSTelemetryMsg += your_function_here
        tss.OnTSSTelemetryMsg += (telemMsg) =>
        {
            msgCount++;
            Debug.Log("Message #" + msgCount + "\nMessage:\n " + JsonUtility.ToJson(telemMsg, prettyPrint: true));




           // gpsMsgBox.text = "GPS Msg:\n" + JsonUtility.ToJson(telemMsg.gpsMsg, prettyPrint: true);
           if(telemMsg.gpsMsg != null){
            position.setPos(JsonUtility.ToJson(telemMsg.gpsMsg));

           }
           

            //imuMsgBox.text = "IMU Msg:\n" + JsonUtility.ToJson(telemMsg.imuMsg, prettyPrint: true);
            //simulationStatesMsgBox.text = "Simulation States Msg:\n" + JsonUtility.ToJson(telemMsg.simulationStates, prettyPrint: true);
            Debug.Log("EVA Msg:\n" + JsonUtility.ToJson(telemMsg.simulationStates, prettyPrint: true));
            evaContainer.setData(JsonUtility.ToJson(telemMsg.simulationStates));

            //specMsgBox.text = "Spec Msg:\n" + JsonUtility.ToJson(telemMsg.specMsg, prettyPrint: true);
            //uiaSwitchesMsgBox.text = "UIA Switches Msg:\n" + JsonUtility.ToJson(telemMsg.uiaMsg, prettyPrint: true);
            //simulationFailuresMsgBox.text = "Simulation Failures Msg: " + JsonUtility.ToJson(telemMsg.simulationFailures, prettyPrint: true);

            //roverMsgBox.text = "Rover Msg: " + JsonUtility.ToJson(telemMsg.roverMsg, prettyPrint: true);

            // evaMsgBox.text = "EVA Msg: " + JsonUtility.ToJson(telemMsg.simulationStates, prettyPrint: true);

        };

        // tss.OnOpen, OnError, and OnClose events just re-raise events from websockets.
        // Similar to OnTSSTelemetryMsg, create functions with the appropriate return type and parameters, and subscribe to them
        tss.OnOpen += () =>
        {
            Debug.Log("Websocket connection opened");
        };

        tss.OnError += (string e) =>
        {
            Debug.Log("Websocket error occured: " + e);
        };

        tss.OnClose += (e) =>
        {
            Debug.Log("Websocket closed with code: " + e);
        };

        await connecting;

    }

    public void SendNavigationButtonCallback()
    {
        // However you get the lat and lon from the user, pass them to the following method
        tss.SendRoverNavigateCommand(10.023f, 11.245f);
    }
    public void SendRecallButtonCallback()
    {
        // Call the following method
        tss.SendRoverRecallCommand();
    }


    // An example handler for the OnTSSMsgReceived event which just serializes to JSON and prints it all out
    // Can be any function that returns void and has a single parameter of type TSS.Msgs.TSSMsg
    public static void PrintInfo(TSS.Msgs.TSSMsg tssMsg)
    {
        Debug.Log("Received the following telemetry data from the TSS:\n" + JsonUtility.ToJson(tssMsg, prettyPrint: true));
    }
}