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
    Position pos;
    public IMU imu;
    public float bearing;
    public List<double> spawn_location;
    public bool is_advance = true;
    public bool PlaceDisable = false;
    public List<GameObject> PinList = new List<GameObject>();
    public List<pinType> pinTypeList = new List<pinType>();
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
    public enum pinType
    {
        ROCK,
        HOME,
        POI,
        NONE
    }
    private void ProcessRightHand(InputAction.CallbackContext ctx)
    {

        //currentTime = Time.time;
        //if (currentTime - SpawnTimer <= 3 && currentTime - MaxTimeForSpawn > 3)
        //{
        //    canSpawn = true;
        //}
        //else
        //{
        //    SpawnTimer = Time.time;
        //}

        //if (canSpawn)
        //{
        //    MaxTimeForSpawn = Time.time;
        //    currentRightLocation = rightHand.transform.position;
        //    canSpawn = false;
        //    PinList.Add(Instantiate(objectToSpawn));
        //    PinList[PinList.Count - 1].transform.position = currentRightLocation;
        //    pinTypeList.Add(pinType.NONE);
        //}
    }

    private void ProcessLeftHand(InputAction.CallbackContext ctx)
    {
        //is_advance = !is_advance;
    }

    private IEnumerator loop()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            bool isNear = false;
            if (is_advance)
            {
                indicator.GetComponent<DirectionalIndicator>().DirectionalTarget = null;
                if (breadList.Count == 0)
                {
                    GameObject tempObject = Instantiate(breadCrumb);
                    breadList.Add(tempObject);
                    breadList[breadList.Count - 1].transform.position = Camera.transform.position - new Vector3(0, 0, .8f);

                }
                waitTime = Time.time;
                foreach (GameObject crumbs in breadList)
                {
                    Vector3 combinedVectors = crumbs.transform.position - Camera.transform.position;
                    if ((combinedVectors[0] <= 3f && combinedVectors[0] >= -3f) && (combinedVectors[1] <= 3f && combinedVectors[1] >= -3f) && (combinedVectors[2] <= 3f && combinedVectors[2] >= -3f))
                    {
                        isNear = true;
                    }
                }
                if (!isNear)
                {
                    GameObject tempObject = Instantiate(breadCrumb);
                    breadList.Add(tempObject);
                    breadList[breadList.Count - 1].transform.position = Camera.transform.position - new Vector3(0, 0, 0.3f);
                    waitTime = Time.time;

                }
            }
            else
            {
                if (breadList.Count > 1)
                {
                    Vector3 combinedVectors = breadList[breadList.Count - 1].transform.position - Camera.transform.position;
                    print(combinedVectors);
                    if ((combinedVectors[0] <= 3f && combinedVectors[0] >= -3f) && (combinedVectors[1] <= 3f && combinedVectors[1] >= -3f) && (combinedVectors[2] <= 3f && combinedVectors[2] >= -3f))
                    {
                        GameObject objecttobedeleted = breadList[-1];
                        breadList.RemoveAt(breadList.Count - 1);
                        Destroy(objecttobedeleted);
                    }
                    indicator.GetComponent<DirectionalIndicator>().DirectionalTarget = breadList[breadList.Count - 1].transform
                }
                else { 
                    indicator.GetComponent<DirectionalIndicator>().DirectionalTarget = breadList[0]; 
                }
            }
        }
    }
    public void setPinType(GameObject pinToSet, pinType pinSet)
    {
        int I = 0;
        foreach (GameObject pin in PinList)
        {
            if (pin == pinToSet)
            {
                pinTypeList[I] = pinSet;
            }
            I += 1;
        }
    }
    public List<double> getPinLocation(int index)
    {
        //This takes the angle of the orininal bearing then corrects it by finding the hipotinuse then using trig functions to find lat and lon of the real world.   |-_-|
        List<double> result = new List<double>(); //                                                                                                                 /|\
        double ingameLat = PinList[index].transform.position[0];//                                                                                                    / \
        double ingameLon = PinList[index].transform.position[1];
        int adjust = 0;
        int gpsadjustlat = 1;
        int gpsadjustlon = 1;
        if (ingameLat > 0 && ingameLon > 0)
        {
            adjust = 90;
        }
        else if (ingameLat < 0 && ingameLon > 0)
        {
            gpsadjustlat = -1;
            adjust = 360;
        }
        else if (ingameLat < 0 && ingameLon < 0)
        {
            gpsadjustlat = -1;
            gpsadjustlon = -1;
            adjust = 270;
        }
        else if (ingameLat > 0 && ingameLon < 0)
        {
            gpsadjustlon = -1;
            adjust = 180;
        }
        double anglelat = (System.Math.Acos(adjust - (bearing + ingameLat / ingameLon)));
        double anglelon = (System.Math.Asin(adjust - (bearing + ingameLat / ingameLon)));
        result.Add(spawn_location[0] + ((anglelon * System.Math.Sqrt(ingameLat * ingameLat + ingameLon * ingameLon)) * 180 / 6378100 * gpsadjustlon));
        result.Add(spawn_location[1] + ((anglelat * System.Math.Sqrt(ingameLat * ingameLat + ingameLon * ingameLon)) * 180 / 6378100 * gpsadjustlat));
        return (result);
    }
    private void Start()
    {
        StartCoroutine(loop());
        leftHandReference.action.performed += ProcessLeftHand;
        rightHandReference.action.performed += ProcessRightHand;
        //spawn_location = pos.getPos();
        //bearing = imu.getHeading();
    }
    private void OnDestroy()
    {

        leftHandReference.action.performed -= ProcessLeftHand;
        rightHandReference.action.performed -= ProcessRightHand;
    }
}
