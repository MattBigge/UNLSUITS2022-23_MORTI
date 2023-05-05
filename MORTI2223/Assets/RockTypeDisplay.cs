using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTypeDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject Si;
    public GameObject Ti;
    public GameObject Al;
    public GameObject Fe;
    public GameObject Mn;
    public GameObject Mg;
    public GameObject Ca;
    public GameObject KO;
    public GameObject PO;

    public bool display = false;
    
    private RectTransform transport;
    public float moveSpeed = 0.1f;
    
    private Vector2 transportDown;
    private Vector2 transportUp;

    public float transportOffset = 0.085f;
    private float podStartMovement = 0;
    public float transportMP = 0;
    
    void Start()
    {
        transport = gameObject.GetComponent<RectTransform>();
        transportUp = new Vector2(transport.anchoredPosition.x, transport.anchoredPosition.y);
        transportDown = new Vector2(transport.anchoredPosition.x+transportOffset, transport.anchoredPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (display)
        {
            transportMP += 0.01f*moveSpeed;
        } else 
        {
            transportMP -= 0.01f * moveSpeed;
        }

        transportMP = Mathf.Clamp(transportMP, 0, 1); 
        transport.anchoredPosition = Vector2.Lerp(transportDown, transportUp, transportMP);
    }
}
