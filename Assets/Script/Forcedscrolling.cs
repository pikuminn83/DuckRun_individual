using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcedscrolling : MonoBehaviour
{
    private float STEP = 0.01f;

    void Update()
    {

        //右向きに等速で進む
        this.transform.position += new Vector3(STEP, 0, 0);
    }
}
