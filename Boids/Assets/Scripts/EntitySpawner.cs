using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] GameObject boidPrefab;
    [SerializeField] GameObject obstaclePrefab;

    private Ray mouseClickRay;
    private RaycastHit mouseClickLocation;
    private Vector3 spawnLocation;
    private float spawnRotationY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))            // left mouse button
        {
            mouseClickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseClickRay, out mouseClickLocation))
            {
                // only spawn if clicked on the ground
                if ((1 << mouseClickLocation.collider.gameObject.layer) == LayerMask.GetMask("Ground"))
                {
                    spawnLocation = mouseClickLocation.point;
                    spawnLocation.y += 1.01f;

                    spawnRotationY = Random.Range(0, 360);

                    Instantiate(boidPrefab, spawnLocation, Quaternion.Euler(0, spawnRotationY, 0));
                }
            }
        }
        else if (Input.GetMouseButton(1))
        {
            mouseClickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseClickRay, out mouseClickLocation))
            {
                // only spawn if clicked on the ground
                if ((1 << mouseClickLocation.collider.gameObject.layer) == LayerMask.GetMask("Ground"))
                {
                    spawnLocation = mouseClickLocation.point;
                    spawnLocation.y += 1.0f;

                    Instantiate(obstaclePrefab, spawnLocation, Quaternion.Euler(Vector3.zero));
                }
            }
        }
    }
}
