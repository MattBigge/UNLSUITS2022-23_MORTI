using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToInt : MonoBehaviour
{
    // Start is called before the first frame update
    public static int TimeToSec(string time){
        if(time == null) return 0;
        int seconds = int.Parse(time.Substring(6, 2));
        int minutes = int.Parse(time.Substring(3, 2));
        int hours = int.Parse(time.Substring(0, 2));
        int totalSeconds = seconds + (minutes * 60) + (hours * 3600);
        return totalSeconds;
    }

    public static string SecToTime(int time){
        int hours = time/3600;
        time -= hours * 3600;
        int minutes = time/ 60;
        int seconds = time - minutes* 60;
        string time_string = "";
        if(hours < 10){
            time_string += "0" + hours + ":";
        }else{
            time_string += hours + ":";
        }

        if(minutes < 10){
            time_string += "0" + minutes + ":";
        }else{
            time_string += minutes + ":";
        }

        if(seconds < 10){
            time_string += "0" +seconds;
        }else{
            time_string += seconds;
        }
        return time_string;
    }


    // Update is called once per frame
}
