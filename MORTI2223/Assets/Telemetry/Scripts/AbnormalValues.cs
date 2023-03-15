using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbnormalValues : MonoBehaviour
{
    // Start is called before the first frame update
   

    // Update is called once per frame
    bool PrimaryOxygenLow(){
        return TeleLIB.getOxPrimary() < 0.2;
    }
    bool SecondaryOxygenLow(){
        return TeleLIB.getOxSecondary() < 0.2;
    }

    bool BPMLow(){
        return TeleLIB.getHeartBpm() < 80;
    }

    bool BPMHigh(){
        return TeleLIB.getHeartBpm() > 120;
    }

    bool SubPressureLow(){
        return TeleLIB.getPSub() < 2;
    }

    bool SubPressureHigh(){
        return TeleLIB.getPSub() > 4;
    }

    bool SuitPressureLow(){
        return TeleLIB.getPSuit() < 2;
    }
    bool SuitPressureHigh(){
        return TeleLIB.getPSuit() > 4;
    }
    bool FanSpeedHigh(){
        return TeleLIB.getVFan() > 40000;
    }
    bool FanSpeedLow(){
        return TeleLIB.getVFan() < 20000;
    }

    bool OxygenPressureLow(){
        return TeleLIB.getPO2() < 750;
    }
    bool OxygenPressureHigh(){
        return TeleLIB.getPO2() > 950;
    }
    bool OxygenRateLow(){
        return TeleLIB.getRateO2() < 0.5;
    }
    bool OxygenRateHigh(){
        return TeleLIB.getRateO2() > 1;
    }
    bool BatteryCapacityLow(){
        return TeleLIB.getCapBattery() < 5;
    }
    bool H20GasPressureLow(){
        return TeleLIB.getPH2OG() < 14;
    }
    bool H20GasPressureHigh(){
        return TeleLIB.getPH2OG() > 16;
    }
    bool H20LiquidPressureLow(){
        return TeleLIB.getPH2OL() < 14;
    }
    bool H20LiquidPressureHigh(){
        return TeleLIB.getPH2OL() > 16;
    }

    bool SecondaryOxygenPressureLow(){
        return TeleLIB.getPSop() < 750;
    }

    bool SecondaryOxygenPressureHigh(){
        return TeleLIB.getPSop() > 950;
    }

    bool SecondaryOxygenRateLow(){
        return TeleLIB.getRateSop() < 0.5;
    }

    bool SecondaryOxygenRateHigh(){
        return TeleLIB.getRateSop() > 1;
    }

    bool BatteryLow(){
        return TeleLIB.getBatteryPercent() < 0.2;
    }

    
     
}
