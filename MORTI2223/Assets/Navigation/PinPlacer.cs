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
    private float currentTime = 0;
    private float SpawnTimer = 0;
    private float MaxTimeForSpawn = 0;
    public GameObject objectToSpawn;
    private int frameCounter = 0;
    [SerializeField]
    private GameObject leftHand;
    [SerializeField]
    private GameObject rightHand;
    [SerializeField]
    private InputActionReference leftHandReference;
    [SerializeField]
    private InputActionReference rightHandReference;
    Vector3 currentLeftLocation;
    Vector3 currentRightLocation;
    [SerializeField]
    private GameObject breadCrumb;
    [SerializeField]
    private GameObject Camera;
    private List<GameObject> breadList = new List<GameObject>();
    private void ProcessRightHand(InputAction.CallbackContext ctx)
    {
        currentTime = Time.time;
        if (currentTime - SpawnTimer <= 3 && currentTime - MaxTimeForSpawn > 3)
        {
            canSpawn = true;
        }
        else
        {
            SpawnTimer = Time.time;
        }

        if (canSpawn)
        {
            MaxTimeForSpawn = Time.time;
            currentRightLocation = rightHand.transform.position;
            canSpawn = false;
            PinList.Add(Instantiate(objectToSpawn));
            PinList[PinList.Count - 1].transform.position = currentRightLocation;
        }
    }
     
    private void ProcessLeftHand(InputAction.CallbackContext ctx)
    {
    } 
    IEnumerator breadCrumbs()
    {
        breadList.Add(Instantiate(breadCrumb));
        breadList[breadList.Count - 1].transform.position = currentRightLocation;
        yield return null;
    }
    private void Start()
    {
        leftHandReference.action.performed += ProcessLeftHand;
        rightHandReference.action.performed += ProcessRightHand;
    }
    private void OnDestroy()
    {
        leftHandReference.action.performed -= ProcessLeftHand;
        rightHandReference.action.performed -= ProcessRightHand;
    }

}