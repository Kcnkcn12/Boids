using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class EntitySpawner : MonoBehaviour//, IPointerDownHandler
{
    [SerializeField] GameObject boidPrefab;
    [SerializeField] GameObject obstaclePrefab;

    private Ray mouseClickRay;
    private RaycastHit mouseClickLocation;
    private Vector3 spawnLocation;
    private float spawnRotationY;

    private bool dragOnEventSystemGameObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))        // left mouse button
        {
            // ignores clicks on EventSystem elements (i.e. UI elements)
            // still allows spawning due to dragging from play area to the EventSystem element
            if (EventSystem.current.IsPointerOverGameObject())
            {
                dragOnEventSystemGameObject = true;
                return;
            }
        }

        if (Input.GetMouseButton(0))            // left mouse button
        {
            // ignores unintentional spawning due to dragging from EventSystem element to the play area
            if (dragOnEventSystemGameObject == true)
            {
                return;
            }

            // spawn boid
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
        else if (Input.GetMouseButton(1))       // right mouse button
        {
            // spawn obstacle
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

        // disable EventSystem spawn prevention when UI is no longer being modified
        if (Input.GetMouseButtonUp(0))          // left mouse button
        {
            dragOnEventSystemGameObject = false;
        }
    }

    /*    public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("down");
            if(eventData.button == PointerEventData.InputButton.Left)
            {
                spawnLocation = eventData.pointerCurrentRaycast.worldPosition;
                spawnLocation.y += 1.01f;

                spawnRotationY = Random.Range(0, 360);

                Instantiate(boidPrefab, spawnLocation, Quaternion.Euler(0, spawnRotationY, 0));
            }
            else if(eventData.button == PointerEventData.InputButton.Right)
            {
                spawnLocation = eventData.pointerCurrentRaycast.worldPosition;
                spawnLocation.y += 1.0f;

                Instantiate(obstaclePrefab, spawnLocation, Quaternion.Euler(Vector3.zero));
            }
        }
    */
}
