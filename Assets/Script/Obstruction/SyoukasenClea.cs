using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyoukasenClea : MonoBehaviour
{
    void OnBecameInvisible()
    {
        
        Destroy(this.gameObject);
    }
}
