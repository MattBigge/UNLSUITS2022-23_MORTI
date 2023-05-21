using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.SpatialManipulation;
using Unity.VisualScripting;
using UnityEngine;

public class ActivationSwitch : MonoBehaviour
{
    public GameObject o;
    private RockTypeDisplay rd;
    public bool display = false;
    public bool go = false;
    public bool click = false;
    void Start()
    {
        rd = o.GetComponent<RockTypeDisplay>();
    }

    public void Click()
    {
        //o.SetActive(!o.activeSelf);
        display = !display;
        go = true;
        o.SetActive(true);
    }

    void Update()
    {
        if (click)
        {
            display = !display;
            go = true;
            o.SetActive(true);
            click = false;
        }
        if (go)
        {
            if (display)
            {
                rd.transportMP += 0.01f * rd.moveSpeed;
            }
            else
            {
                rd.transportMP -= 0.01f * rd.moveSpeed;
            }

            rd.transportMP = Mathf.Clamp(rd.transportMP, 0, 1);
            rd.transport.anchoredPosition = Vector2.Lerp(rd.transportDown, rd.transportUp, rd.transportMP);

            if (rd.transportMP == 0 || rd.transportMP == 1)
            {
                go = false;
            }

            if (rd.transportMP == 0)
            {
                o.SetActive(false);
            }
        }
    }
}
