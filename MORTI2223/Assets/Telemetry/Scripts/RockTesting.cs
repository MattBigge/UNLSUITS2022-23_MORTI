using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTesting : MonoBehaviour
{

    public RockContainer rock;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateTestData());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator UpdateTestData(){
        yield return new WaitForSeconds(1);

        while(true){
            
            float[] values = new float[10];
            values[0] = Random.Range(37,47);
            values[1] = Random.Range(1,13);
            values[2] = Random.Range(9,19);
            values[3] = Random.Range(7,18);
            values[4] = Random.Range(14,27)/100f;
            values[5] = Random.Range(5,11);
            values[6] = Random.Range(8,14);
            values[7] = Random.Range(-13,43)/100f;
            values[8] = Random.Range(28,65)/100f;
            rock.updateTest(values);
            yield return new WaitForSeconds(20);
        }


    }
}
