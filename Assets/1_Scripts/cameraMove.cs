using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    Camera camera;
    float slowValue;

    void Start()
    {
        camera = this.gameObject.GetComponent<Camera>();

        camera.orthographicSize = 13f;
        slowValue = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (camera.orthographicSize < 9.0f)
            slowValue = 0.6f;


        if (!(camera.orthographicSize <= 8.5f))
            camera.orthographicSize -= slowValue * Time.deltaTime;
        else camera.orthographicSize = 8.5f;
    }
}
