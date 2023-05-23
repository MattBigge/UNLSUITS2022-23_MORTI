using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAStateTest : MonoBehaviour
{

    public UIAStatesContainer uiaStatesContainer;

    public EgressContainer egressContainer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changeStates());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator changeStates(){
        yield return new WaitForSeconds(5);
        uiaStatesContainer.airlock_pressure = 420;
        uiaStatesContainer.depress_pump_fault = true;
        uiaStatesContainer.uia_supply_pressure = 420;
        uiaStatesContainer.emu1_is_booted = true;
        uiaStatesContainer.water_level = 420;

    }
}
