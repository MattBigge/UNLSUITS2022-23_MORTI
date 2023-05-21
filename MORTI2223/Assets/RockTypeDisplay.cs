using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RockTypeDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject SampleNumber;
    public GameObject Mission;
    public GameObject RockType;
    public GameObject Petrology;
    public GameObject SiO2;
    public GameObject TiO2;
    public GameObject Al2O3;
    public GameObject FeO;
    public GameObject MnO;
    public GameObject MgO;
    public GameObject CaO;
    public GameObject K2O;
    public GameObject P2O3;

    public bool display = false;
    public bool input = false;
    
    private RectTransform transport;
    public float moveSpeed = 0.1f;
    
    private Vector2 transportDown;
    private Vector2 transportUp;

    public float transportOffset = 0.085f;
    private float podStartMovement = 0;
    public float transportMP = 0;
    
    public List<string> SampleNumbers = new List<string>();
    public List<int> Missions = new List<int>();
    public List<string> RockTypes = new List<string>();
    public List<string> Petrologies = new List<string>();
    public List<float> SiO2s = new List<float>();
    public List<float> TiO2s = new List<float>();
    public List<float> Al2O3s = new List<float>();
    public List<float> FeOs = new List<float>();
    public List<float> MnOs = new List<float>();
    public List<float> MgOs = new List<float>();
    public List<float> CaOs = new List<float>();
    public List<float> K2Os = new List<float>();
    public List<float> P2O3s = new List<float>();
    
    public float inputSiO2;
    public float inputTiO2;
    public float inputAl2O3;
    public float inputFeO;
    public float inputMnO;
    public float inputMgO;
    public float inputCaO;
    public float inputK2O;
    public float inputP2O3;

    public int sample = -1;

    public bool compound = true;

    private float[] TSSInput;
    public RockContainer rc;

    public float displayTime = 0;
    public float displayTimer = 10;
    void Start()
    {
        transport = gameObject.GetComponent<RectTransform>();
        transportUp = new Vector2(transport.anchoredPosition.x, transport.anchoredPosition.y);
        transportDown = new Vector2(transport.anchoredPosition.x+transportOffset, transport.anchoredPosition.y);
        
        // Sample Numbers
        SampleNumbers.AddRange(new string[] { "70,215,312", "15556,11", "12,002,492", "14,310,220", "12052,26", "15555,62", "10017,30" });

        // Missions
        Missions.AddRange(new int[] { 17, 15, 12, 14, 12, 15, 11 });

        // Rock Types
        RockTypes.AddRange(new string[] { "Mare basalt", "Vesicular basalt", "Olivine basalt", "Feldspathic basalt", "Pigeonite basalt", "Olivine basalt", "Ilmenite basalt" });

        // Petrologies
        Petrologies.AddRange(new string[] { "Fine-grained, porphyritic", "Medium-grained, small olv phenocrysts", "Medium-grained, porphyritic", "Fine-grained, phenos of plag, and pyx", "Porphyritic, phenos of oliv and cpx", "Medium-grained, phenos of oliv and pyx", "Fine-grainded, vesicular, poikilitic" });

        // SiO2
        SiO2s.AddRange(new float[] { 40.58f, 36.89f, 41.62f, 46.72f, 46.53f, 42.45f, 42.56f });

        // TiO2
        TiO2s.AddRange(new float[] { 12.83f, 2.44f, 2.44f, 1.1f, 3.4f, 1.56f, 9.38f });

        // Al2O3
        Al2O3s.AddRange(new float[] { 10.91f, 9.6f, 9.52f, 19.01f, 11.68f, 11.44f, 12.03f });

        // FeO
        FeOs.AddRange(new float[] { 13.18f, 14.52f, 18.12f, 7.21f, 16.56f, 17.91f, 11.27f });
        
        // MnO
        MnOs.AddRange(new float[] { 0.19f, 0.24f, 0.27f, 0.14f, 0.24f, 0.27f, 0.17f });

        // MgO
        MgOs.AddRange(new float[] { 6.7f, 5.3f, 11.1f, 7.83f, 6.98f, 10.45f, 9.7f });

        // CaO
        CaOs.AddRange(new float[] { 10.64f, 8.22f, 8.12f, 14.22f, 11.11f, 9.37f, 10.52f });

        // K2O
        K2Os.AddRange(new float[] { -0.11f, -0.13f, -0.12f, 0.43f, -0.02f, -0.08f, 0.28f });

        // P2O3
        P2O3s.AddRange(new float[] { 0.34f, 0.29f, 0.28f, 0.65f, 0.38f, 0.34f, 0.44f });
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInputValues();
        
        input = !(inputSiO2 == 0 && inputTiO2 == 0 && inputAl2O3 == 0 && inputFeO == 0 && inputMnO == 0 && inputMgO == 0 && inputCaO == 0 && inputK2O == 0 && inputP2O3 == 0);
        
        if (input)
        {
            int closestSampleIndex = FindClosestSampleIndex();
            if (sample != closestSampleIndex || sample == -1)
            {
                sample = closestSampleIndex;
                display = true;
                displayTime = 0;
            }
            else
            {
                displayTime += Time.deltaTime;  
            }
            if (displayTime >= displayTimer)
            {
                displayTime = 0;
                display = false;
            }
        }
        else
        {
            display = false;
        }
        
        if (display)
        {
            transportMP += 0.01f * moveSpeed;
        } else 
        {
            transportMP -= 0.01f * moveSpeed;
        }

        transportMP = Mathf.Clamp(transportMP, 0, 1);
        transport.anchoredPosition = Vector2.Lerp(transportDown, transportUp, transportMP);

        if (sample >= 0 && sample < SampleNumbers.Count)
        {
            SampleNumber.GetComponent<TextMeshProUGUI>().text = "Sample Number: " + SampleNumbers[sample];
            Mission.GetComponent<TextMeshProUGUI>().text = "Mission: " + Missions[sample].ToString();
            RockType.GetComponent<TextMeshProUGUI>().text = "Rock Type: " + RockTypes[sample];
            Petrology.GetComponent<TextMeshProUGUI>().text = "Petrology: " + Petrologies[sample];
            if (compound){
            SiO2.GetComponent<TextMeshProUGUI>().text = "SiO2: " + SiO2s[sample].ToString();
            TiO2.GetComponent<TextMeshProUGUI>().text = "TiO2: " + TiO2s[sample].ToString();
            Al2O3.GetComponent<TextMeshProUGUI>().text = "Al2O3: " + Al2O3s[sample].ToString();
            FeO.GetComponent<TextMeshProUGUI>().text = "FeO: " + FeOs[sample].ToString();
            MnO.GetComponent<TextMeshProUGUI>().text = "MnO: " + MnOs[sample].ToString();
            MgO.GetComponent<TextMeshProUGUI>().text = "MgO: " + MgOs[sample].ToString();
            CaO.GetComponent<TextMeshProUGUI>().text = "CaO: " + CaOs[sample].ToString();
            K2O.GetComponent<TextMeshProUGUI>().text = "K2O: " + K2Os[sample].ToString();
            P2O3.GetComponent<TextMeshProUGUI>().text = "P2O3: " + P2O3s[sample].ToString();
            }

        }
        else
        {
            display = false;
        }

        if (!display){
            displayTime = 0;
        }
    }
    int FindClosestSampleIndex()
    {
        int closestSampleIndex = -1;
        float smallestDistance = float.MaxValue;

        for (int i = 0; i < SampleNumbers.Count; i++)
        {
            float distance = CalculateDistance(i);
            if (distance < smallestDistance)
            {
                smallestDistance = distance;
                closestSampleIndex = i;
            }
        }

        return closestSampleIndex;
    }

    float CalculateDistance(int index)
    {
        float distance = 0;

        distance += Mathf.Pow(inputSiO2 - SiO2s[index], 2);
        distance += Mathf.Pow(inputTiO2 - TiO2s[index], 2);
        distance += Mathf.Pow(inputAl2O3 - Al2O3s[index], 2);
        distance += Mathf.Pow(inputFeO - FeOs[index], 2);
        distance += Mathf.Pow(inputMnO - MnOs[index], 2);
        distance += Mathf.Pow(inputMgO - MgOs[index], 2);
        distance += Mathf.Pow(inputCaO - CaOs[index], 2);
        distance += Mathf.Pow(inputK2O - K2Os[index], 2);
        distance += Mathf.Pow(inputP2O3 - P2O3s[index], 2);

        return Mathf.Sqrt(distance);
    }
    
    void UpdateInputValues()
    {
        TSSInput = rc.getSample();
        inputSiO2 = TSSInput[0];
        inputTiO2 = TSSInput[1];
        inputAl2O3 = TSSInput[2];
        inputFeO = TSSInput[3];
        inputMnO = TSSInput[4];
        inputMgO = TSSInput[5];
        inputCaO = TSSInput[6];
        inputK2O = TSSInput[7];
        inputP2O3 = TSSInput[8];
    }
}
