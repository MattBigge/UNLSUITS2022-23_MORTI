using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class AbnormalValues : MonoBehaviour
{

    // Update is called once per frame
    public bool PrimaryOxygenLow(){
        return TeleLIB.getOxPrimary() < 0.2;
    }
    public bool SecondaryOxygenLow(){
        return TeleLIB.getOxSecondary() < 0.2;
    }

    public bool BPMLow(){
        return TeleLIB.getHeartBpm() < 80;
    }

    public bool BPMHigh(){
        return TeleLIB.getHeartBpm() > 120;
    }

    public bool SubPressureLow(){
        return TeleLIB.getPSub() < 2;
    }

    public bool SubPressureHigh(){
        return TeleLIB.getPSub() > 4;
    }

    public bool SuitPressureLow(){
        return TeleLIB.getPSuit() < 2;
    }
    public bool SuitPressureHigh(){
        return TeleLIB.getPSuit() > 4;
    }
    public bool FanSpeedHigh(){
        return TeleLIB.getVFan() > 40000;
    }
    public bool FanSpeedLow(){
        return TeleLIB.getVFan() < 20000;
    }

    public bool OxygenPressureLow(){
        return TeleLIB.getPO2() < 750;
    }
    public bool OxygenPressureHigh(){
        return TeleLIB.getPO2() > 950;
    }
    public bool OxygenRateLow(){
        return TeleLIB.getRateO2() < 0.5;
    }
    public bool OxygenRateHigh(){
        return TeleLIB.getRateO2() > 1;
    }
    public bool BatteryCapacityLow(){
        return TeleLIB.getCapBattery() < 5;
    }
    public bool H20GasPressureLow(){
        return TeleLIB.getPH2OG() < 14;
    }
    public bool H20GasPressureHigh(){
        return TeleLIB.getPH2OG() > 16;
    }
    public bool H20LiquidPressureLow(){
        return TeleLIB.getPH2OL() < 14;
    }
    public bool H20LiquidPressureHigh(){
        return TeleLIB.getPH2OL() > 16;
    }

    public bool SecondaryOxygenPressureLow(){
        return TeleLIB.getPSop() < 750;
    }

    public bool SecondaryOxygenPressureHigh(){
        return TeleLIB.getPSop() > 950;
    }

    public bool SecondaryOxygenRateLow(){
        return TeleLIB.getRateSop() < 0.5;
    }

    public bool SecondaryOxygenRateHigh(){
        return TeleLIB.getRateSop() > 1;
    }

    public bool BatteryLow(){
        return TeleLIB.getBatteryPercent() < 0.2;
    }

    
     
}
