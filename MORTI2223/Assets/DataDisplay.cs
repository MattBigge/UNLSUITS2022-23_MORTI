using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DataDisplay : MonoBehaviour
{

    public TSSManager tss;
    public GameObject A;
    public GameObject B;
    public GameObject C;
    public GameObject D;
    public GameObject E;
    public GameObject F;
    public GameObject G;
    public GameObject H;
    public GameObject I;

    public roverPOI r;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        A.GetComponent<TextMeshProUGUI>().text = "A: " + r.coordinates[0].x.ToString() + ", " + r.coordinates[0].y.ToString();
        B.GetComponent<TextMeshProUGUI>().text = "B: " + r.coordinates[1].x.ToString() + ", " + r.coordinates[1].y.ToString();
        C.GetComponent<TextMeshProUGUI>().text = "C: " + r.coordinates[2].x.ToString() + ", " + r.coordinates[0].y.ToString();
        D.GetComponent<TextMeshProUGUI>().text = "D: " + r.coordinates[3].x.ToString() + ", " + r.coordinates[3].y.ToString();
        E.GetComponent<TextMeshProUGUI>().text = "E: " + r.coordinates[4].x.ToString() + ", " + r.coordinates[4].y.ToString();
        F.GetComponent<TextMeshProUGUI>().text = "F: " + r.coordinates[5].x.ToString() + ", " + r.coordinates[5].y.ToString();
        G.GetComponent<TextMeshProUGUI>().text = "G: " + r.coordinates[6].x.ToString() + ", " + r.coordinates[6].y.ToString();
        H.GetComponent<TextMeshProUGUI>().text = "H: " + r.coordinates[7].x.ToString() + ", " + r.coordinates[7].y.ToString();
        I.GetComponent<TextMeshProUGUI>().text = "I: " + r.coordinates[8].x.ToString() + ", " + r.coordinates[8].y.ToString();
    }

    public void Send(){
        tss.SendNavigationButtonCallback(r.latitude, r.longitude);
    }
}
