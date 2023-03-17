using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PinPlacer : MonoBehaviour
{
    public GameObject objectToSpawn;
    [SerializeField]
    private GameObject leftHand;
    [SerializeField]
    private GameObject rightHand;

    [SerializeField]
    private InputActionReference leftHandReference;
    [SerializeField]
    private InputActionReference rightHandReference;
    
    private void ProcessRightHand(InputAction.CallbackContext ctx)
    {
        ProcessHand(ctx, rightHand);
        Instantiate(objectToSpawn);
    }

    private void ProcessLeftHand(InputAction.CallbackContext ctx)
    {
        ProcessHand(ctx, leftHand);
        Instantiate(objectToSpawn);
    }

    private void ProcessHand(InputAction.CallbackContext ctx, GameObject g)
    {
        g.SetActive(ctx.ReadValue<float>() > 0.95f);
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