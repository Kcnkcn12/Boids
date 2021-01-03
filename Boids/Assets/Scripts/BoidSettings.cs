using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoidSettings : ScriptableObject
{
    public float detectionDistance;

    public float separationModifier;
    public float alignmentModifier;
    public float cohesionModifier;

    public int rayCount;
    public float obstacleAvoidanceModifier;

    public float minVelocity;
    public float maxVelocity;
}
