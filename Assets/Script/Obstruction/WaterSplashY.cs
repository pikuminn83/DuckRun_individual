using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Instantiate‚Å¶¬‚³‚ê‚½‚ç+Y•ûŒü‚ÉˆÚ“®
public class WaterSplashY : MonoBehaviour
{

    public float speed;
    // Update is called once per frame
    void Update()
    {
        Vector2 positionx = transform.position;
        positionx.y += speed;
        transform.position = positionx;
    }

    void OnBecameInvisible()
    {

        Destroy(this.gameObject);
    }
}
