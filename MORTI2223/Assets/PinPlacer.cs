using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PinPlacer : MonoBehaviour
{
    private bool canSpawn = true;
    private float SpawnTimer = 0;
    private float MaxTimeForSpawn = 3;
    public GameObject objectToSpawn;
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
    private void ProcessRightHand(InputAction.CallbackContext ctx)
    {
        ProcessHand(ctx, rightHand);
        if (canSpawn)
        {
            canSpawn = false;
            print("trying to instanciate");
            Instantiate(objectToSpawn).transform.position = rightHand.transform.position;
        }
    }

    private void ProcessLeftHand(InputAction.CallbackContext ctx)
    {
        ProcessHand(ctx, leftHand);
        if (canSpawn)
        {
            canSpawn = false;
            print("trying to instanciate");
            Instantiate(objectToSpawn).transform.position = leftHand.transform.position;
        }
    }

    private void ProcessHand(InputAction.CallbackContext ctx, GameObject g)
    {
        g.SetActive(ctx.ReadValue<float>() > 0.95f);
    }
    private void Update()
    {
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
        leftHand.SetActive(false);
        rightHand.SetActive(false);
        leftHandReference.action.performed += ProcessLeftHand;
        rightHandReference.action.performed += ProcessRightHand;
    }
    private void OnDestroy()
    {
        leftHandReference.action.performed -= ProcessLeftHand;
        rightHandReference.action.performed -= ProcessRightHand;
    }

}