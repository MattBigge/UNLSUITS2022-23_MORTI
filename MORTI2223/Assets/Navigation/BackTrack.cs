using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTrack : MonoBehaviour
{
    public GameObject NavSystem
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void On_toggle()
    {
        PinPlacer scriptb = NavSystem.GetComponent<PinPlacer>()
        if (scriptb.is_advance)
        {
            scriptb.is_advance=false
        }
        else
        {
            scriptb.is_advance =true
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
