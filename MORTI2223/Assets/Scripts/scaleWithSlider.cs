using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scaleWithSlider : MonoBehaviour
{
    private float scaleNum;
    public Slider scaleSlider;
   




    // Update is called once per frame
    void Update()
    {
        scaleNum = scaleSlider.value;
        Vector3 scale = new Vector3(scaleNum, scaleNum, scaleNum);
        this.transform.localScale = scale;
        
    }
}
