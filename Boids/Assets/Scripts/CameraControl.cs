using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private float moveX;
    [SerializeField] float xSpeed;
    private float moveZ;
    [SerializeField] float zSpeed;

    private Vector3 movementVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveZ = Input.GetAxis("Vertical") * zSpeed;
        moveX = Input.GetAxis("Horizontal") * xSpeed;

        movementVector = Vector3.forward * moveZ + Vector3.right * moveX;
        transform.position += movementVector * Time.deltaTime;
    }
}
