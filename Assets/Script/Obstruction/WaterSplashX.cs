using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//InstantiateÇ≈ê∂ê¨Ç≥ÇÍÇΩÇÁ-Xï˚å¸Ç…à⁄ìÆ
public class OppositionX : MonoBehaviour
{

    public float speed;
    // Update is called once per frame
    void Update()
    {
        Vector2 positionx = transform.position;
        positionx.x -= speed;
        transform.position = positionx;
    }

    void OnBecameInvisible()
    {

        Destroy(this.gameObject);
    }
}
