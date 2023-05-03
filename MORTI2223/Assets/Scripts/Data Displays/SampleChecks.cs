using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SampleChecks : MonoBehaviour
{
    public TMP_Text mainPercentage;
    public TMP_Text otherSources;

 void OnEnable()
    {
        StartCoroutine(UpdateValues2Sec());
    }


    IEnumerator UpdateValues2Sec()
        {
            yield return new WaitForSeconds(1);
            while (true)
            {

                yield return new WaitForSeconds(2);
            }

        }
}
