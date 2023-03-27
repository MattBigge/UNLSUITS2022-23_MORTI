using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToInt : MonoBehaviour
{
    // Start is called before the first frame update
    public static int TimeToSec(string time){
        int seconds = int.Parse(time.Substring(6, 2));
        int minutes = int.Parse(time.Substring(3, 2));
        int hours = int.Parse(time.Substring(0, 2));
        int totalSeconds = seconds + (minutes * 60) + (hours * 3600);
        return totalSeconds;
    }


    // Update is called once per frame
}
