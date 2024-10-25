using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcedscrolling : MonoBehaviour
{
    private float STEP = 0.01f;

    void Update()
    {

        //‰EŒü‚«‚É“™‘¬‚Åi‚Ş
        this.transform.position += new Vector3(STEP, 0, 0);
    }
}
