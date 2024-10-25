using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private float zoom;
    private float minZoom = 3f;
    private float maxZoom = 6f;
    public Camera cam;

    public GameObject Player;
    void Start()
    {
        //cam = GetComponent<Camera>();
        zoom = cam.orthographicSize;
    }
    void Update()
    {
        cam.transform.position = Player.transform.position;
        float val = Input.GetAxis("Vertical");
        zoom -= val;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        cam.orthographicSize = zoom;
    }
}
