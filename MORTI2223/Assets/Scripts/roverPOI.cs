using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roverPOI : MonoBehaviour
{

    private List<Vector2> coordinates;
    public float latitude;
    public float longitude;
    public bool coords_updated = false;
    // Start is called before the first frame update
    void Start()
    {
        coordinates.Add(new Vector2(29.5648150f, -95.0817410f)); // A
        coordinates.Add(new Vector2(29.5646824f, -95.0811564f)); // B
        coordinates.Add(new Vector2(29.5650460f, -95.0810944f)); // C
        coordinates.Add(new Vector2(29.5645430f, -95.0516440f)); // D
        coordinates.Add(new Vector2(29.5648290f, -95.0813750f)); // E
        coordinates.Add(new Vector2(29.5647012f, -95.0813750f)); // F
        coordinates.Add(new Vector2(29.5651359f, -95.0807408f)); // G
        coordinates.Add(new Vector2(29.5651465f, -95.0814092f)); // H
        coordinates.Add(new Vector2(29.5648850f, -95.0808360f)); // I
    }

    // Update is called once per frame
    void setPOI(int index)
    {
        latitude = coordinates[index].x;
        longitude = coordinates[index].y;
        coords_updated = true;
    }
}
