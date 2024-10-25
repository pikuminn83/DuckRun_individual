using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Instantiateで生成されたら+Y方向に移動
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
