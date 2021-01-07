using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private float moveX;
    [SerializeField] float xSpeed;
    private float moveZ;
    [SerializeField] float zSpeed;

    private float zoomLevel;
    [SerializeField] float zoomSensitivity;
    [SerializeField] float minZoomLevel;
    [SerializeField] float maxZoomLevel;

    [HideInInspector] public bool cameraLock;
    [HideInInspector] public bool CameraLock
    {
        set { cameraLock = value; }
    }

    private Vector3 movementVector;

    // Start is called before the first frame update
    void Start()
    {
        zoomLevel = Camera.main.orthographicSize;
        cameraLock = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraLock == false)
        {
            moveZ = Input.GetAxis("Vertical") * zSpeed;
            moveX = Input.GetAxis("Horizontal") * xSpeed;
            movementVector = Vector3.forward * moveZ + Vector3.right * moveX;
            transform.position += movementVector * Time.deltaTime;

            zoomLevel += -Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
            zoomLevel = Mathf.Clamp(zoomLevel, minZoomLevel, maxZoomLevel);
            Camera.main.orthographicSize = zoomLevel;
        }
    }
}
