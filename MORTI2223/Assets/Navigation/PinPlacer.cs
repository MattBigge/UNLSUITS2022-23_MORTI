using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PinPlacer : MonoBehaviour
{
    public bool PlaceDisable = false;
    public List<GameObject> PinList = new List<GameObject>(); 
    private bool canSpawn = false;
    private float SpawnTimer = 0;
    private float MaxTimeForSpawn = 3;
    public GameObject objectToSpawn;
    [SerializeField]
    private GameObject leftHand;
    [SerializeField]
    private GameObject rightHand;
    private bool isRightPinch= false;
    private bool isLeftPinch=false;
    [SerializeField]
    private InputActionReference leftHandReference;
    [SerializeField]
    private InputActionReference rightHandReference;
    Vector3 currentLeftLocation;
    Vector3 currentRightLocation;
    private void ProcessRightHand(InputAction.CallbackContext ctx)
    {
        print("im being held down omg help");
        if (isRightPinch)
        {
            isRightPinch = false;

        }
        else
        {
            isRightPinch = true;
            StartCoroutine(pinchRightUpdate());
        }
        
    }
    private IEnumerator pinchRightUpdate()
    {
        int i = 0;
        while (isRightPinch)
        {
            i++;
            yield return new WaitForSeconds(1);
        }
        if (i >= 3)
        {
            if (canSpawn&&!PlaceDisable)
            {
                canSpawn = false;
                PinList.Add(Instantiate(objectToSpawn));
                PinList[PinList.Count - 1].transform.position = currentRightLocation;
            }
        }
    }
    private IEnumerator pinchLeftUpdate()
    {
        int i = 0;
        while (isLeftPinch)
        {
            i++;
            yield return new WaitForSeconds(1);
        }
        if (i >= 3)
        {
            if (canSpawn && !PlaceDisable)
            {
                canSpawn = false;
                print(currentLeftLocation);
                PinList.Add(Instantiate(objectToSpawn));
                PinList[PinList.Count - 1].transform.position = currentLeftLocation;
            }
        }
    }
    private void ProcessLeftHand(InputAction.CallbackContext ctx)
    {
        if (isLeftPinch)
        {
            isLeftPinch = false;

        }
        else
        {
            isLeftPinch = true;
            StartCoroutine(pinchLeftUpdate());
        }
        
        //ProcessHand(ctx, leftHand);
    } 

    private void ProcessHand(InputAction.CallbackContext ctx, GameObject g)
    {
        g.SetActive(ctx.ReadValue<float>() > 0.95f);
    }
    private void Update()
    {
        currentRightLocation = rightHand.transform.position;
        currentLeftLocation = leftHand.transform.position;
        if (!canSpawn && (SpawnTimer < MaxTimeForSpawn))
        {
            SpawnTimer += Time.deltaTime;
        }
        else
        {
            SpawnTimer = 0;
            canSpawn = true;
        }
        
    }
    private void Start()
    {
        //leftHand.SetActive(false);
        //rightHand.SetActive(false);
        leftHandReference.action.performed += ProcessLeftHand;
        rightHandReference.action.performed += ProcessRightHand;
    }
    private void OnDestroy()
    {
        leftHandReference.action.performed -= ProcessLeftHand;
        rightHandReference.action.performed -= ProcessRightHand;
    }

}