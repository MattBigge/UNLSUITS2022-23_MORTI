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
    public void On_toggle()
    {
        PinPlacer scriptb = NavSystem.GetComponent<PinPlacer>();
        scriptb.is_advance = !scriptb.is_advance;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
