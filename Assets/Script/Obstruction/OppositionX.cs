using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Instantiate‚Å¶¬‚³‚ê‚½‚ç-X•ûŒü‚ÉˆÚ“®
public class WaterSplashX : MonoBehaviour
{

    public float speed;
    // Update is called once per frame
    void Update()
    {
        Vector2 positionx = transform.position;
        positionx.x += speed;
        transform.position = positionx;
    }

    void OnBecameInvisible()
    {

        Destroy(this.gameObject);
    }
}
