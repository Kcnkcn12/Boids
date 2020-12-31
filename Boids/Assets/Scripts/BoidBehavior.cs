using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidBehavior : MonoBehaviour
{
    private CharacterController boid;
    [SerializeField] BoidSettings boidSettings;

    private Vector3 resultantMovementVector;

    [HideInInspector] public Vector3 MovementVector
    {
        get { return resultantMovementVector; }
    }

    // Start is called before the first frame update
    void Start()
    {
        boid = gameObject.GetComponent<CharacterController>();

        resultantMovementVector = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        resultantMovementVector = BoidIntereaction() + ObstacleInteraction();
        resultantMovementVector = resultantMovementVector.normalized * Mathf.Clamp(resultantMovementVector.magnitude, 0, boidSettings.maxVelocity);
//        Debug.Log(resultantMovementVector.magnitude);
        boid.Move(resultantMovementVector * Time.deltaTime);
    }

    /**
     * Tells boid how to move based on the boids around it 
     * using the 3 rules of Boid emergent behavior.
     * If no boids are present, continue in current direction.
     * 
     * Param: none, uses class variables directly.
     * 
     * Return: Vector3 containing the movement vector.
     */
    Vector3 BoidIntereaction()
    {
        // obtain array of neighboring boids within a radius around the boid
        Collider[] neighboringBoids = Physics.OverlapSphere(gameObject.transform.position, boidSettings.detectionDistance, LayerMask.GetMask("Boid"));

        Vector3 combinedMovementVector = Vector3.zero; // combination of vectors from all neighboring boids
        if (neighboringBoids.Length == 0)
        {
            // return current direction
            combinedMovementVector = resultantMovementVector;
        }
        else
        {
            Vector3 separationVector = Vector3.zero;
            Vector3 boidToNeighborVector = Vector3.zero;    // vector pointing towards neighboring boid
            Vector3 neighborAvoidanceVector = Vector3.zero; // modified vector pointing away from neighboring boid

            Vector3 alignmentVector = Vector3.zero;
            Vector3 neighborMovementVector = Vector3.zero;  // movement vector of neighboring boid

            Vector3 cohesionVector = Vector3.zero;
            Vector3 neighborPosition = Vector3.zero;        // current position of neighboting boid

            foreach (Collider neighborBoid in neighboringBoids)
            {
                //ignore self
                if(neighborBoid.gameObject == gameObject)
                {
                    continue;
                }

                separationVector = Vector3.zero;
                alignmentVector = Vector3.zero;
                cohesionVector = Vector3.zero;

                // separation rule (move away from neighboring boids)
                // strength is based on inverse square law ('normalized = vector / magnitude', so only need 1 more "/ magnitude")
                boidToNeighborVector = neighborBoid.gameObject.transform.position - gameObject.transform.position;
                neighborAvoidanceVector = -(boidToNeighborVector.normalized / boidToNeighborVector.magnitude);
                Debug.Log(boidToNeighborVector.magnitude);
                separationVector += neighborAvoidanceVector * boidSettings.separationModifier;

                // alignment rule (move in average same direction and speed as neighboring boids)
                neighborMovementVector = neighborBoid.gameObject.GetComponent<BoidBehavior>().MovementVector;
                alignmentVector += neighborMovementVector.normalized * boidSettings.alignmentModifier;

                // cohesion rule (move toward the average center of neighboring boids)
                neighborPosition = neighborBoid.gameObject.transform.position;
                cohesionVector += ((neighborPosition - gameObject.transform.position) / neighboringBoids.Length) * boidSettings.cohesionModifier;

                //combine rules
                combinedMovementVector += separationVector + alignmentVector + cohesionVector;
            }
        }

        return combinedMovementVector;
    }

    /**
     * Tells boid to avoid colliding with obstacles using raycasts.
     * If no obstacles, return zero vector.
     * Raycasts will be done on the x-z axes (for now).
     * 
     * Param: none, uses class variables directly.
     * 
     * Return: Vector3 containing the movement vector.
     */
    Vector3 ObstacleInteraction()
    {
//      TODO: convert raycasts to 3 dimensional



//      TODO: check if raycasts should be done on FixedUpdate()




        float rayAngle = 0;
        RaycastHit hit;
        Vector3 boidToObstacleVector = Vector3.zero;        // vector pointing towards obstacle
        Vector3 obstacleAvoidanceVector = Vector3.zero;     // modified vector pointing away from obstacle
        Vector3 combinedMovementVector = Vector3.zero;      // combination of vectors from all rays

        for (int i = 0; i < boidSettings.rayCount; ++i)
        {
            // draw raycast
            rayAngle = (360 / boidSettings.rayCount) * i;
            //            Debug.DrawRay(transform.position, Quaternion.AngleAxis(rayAngle, transform.up) * transform.forward * detectionDistance);

            // move in opposite direction if obstacle is found
            // strength is based on inverse square law ('normalized = vector / magnitude', so only need 1 more "/ magnitude")
            if (Physics.Raycast(transform.position, Quaternion.AngleAxis(rayAngle, transform.up) * transform.forward, out hit, boidSettings.detectionDistance, LayerMask.GetMask("Obstacle")))
            {
                boidToObstacleVector = hit.point - gameObject.transform.position;
                obstacleAvoidanceVector = -(boidToObstacleVector.normalized / boidToObstacleVector.magnitude);
                combinedMovementVector += obstacleAvoidanceVector;
            }
        }

        return combinedMovementVector;
    }
}
