using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.SpatialManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class PinPlacer : MonoBehaviour
{
    public bool is_advance = true;
    public bool PlaceDisable = false;
    public List<GameObject> PinList = new List<GameObject>(); 
    private bool canSpawn = false;
    private float currentTime = 0;
    private float SpawnTimer = 0;
    private float MaxTimeForSpawn = 0;
    public GameObject objectToSpawn;
    [SerializeField]
    public GameObject indicator;
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
    private float waitTime;
    private float thisTime;
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
        is_advance = false;
    } 
    
    private void Update()
    {
        if (is_advance)
        {
            thisTime = Time.time;
            if (thisTime - waitTime >= 15)
            {
                if (breadList.Count == 0)
                {
                    GameObject tempObject = Instantiate(breadCrumb);
                    breadList.Add(tempObject);
                    breadList[breadList.Count - 1].transform.position = Camera.transform.position - new Vector3(0, 0, 0.3f);
                }
                waitTime = Time.time;
                Vector3 combinedVectors = breadList[breadList.Count - 1].transform.position - Camera.transform.position;
                if (!(combinedVectors[0] <= 3f && combinedVectors[0] >= -3f) || !(combinedVectors[1] <= 3f && combinedVectors[1] >= -3f) || !(combinedVectors[2] <= 3f && combinedVectors[2] >= -3f))
                {
                    GameObject tempObject = Instantiate(breadCrumb);
                    breadList.Add(tempObject);
                    breadList[breadList.Count - 1].transform.position = Camera.transform.position - new Vector3(0, 0, 0.3f);
                    waitTime = Time.time;
                }

            }
        }
        else
        {
            if (breadList.Count != 0)
            {
                Vector3 combinedVectors = breadList[breadList.Count - 1].transform.position - Camera.transform.position;
                if (!(combinedVectors[0] <= 3f && combinedVectors[0] >= -3f) || !(combinedVectors[1] <= 3f && combinedVectors[1] >= -3f) || !(combinedVectors[2] <= 3f && combinedVectors[2] >= -3f))
                {
                    breadList.RemoveAt(breadList.Count - 1);
                }
                indicator.GetComponent<DirectionalIndicator>().DirectionalTarget = breadList[breadList.Count -1].transform;
            }
        }
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