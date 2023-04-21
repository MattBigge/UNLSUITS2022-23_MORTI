using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject Camera_to_Follow;
    public GameObject Camera_to_Move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera_to_Move.transform.position = Camera_to_Follow.transform.position + new Vector3(0, 0, 10);
    }
}
