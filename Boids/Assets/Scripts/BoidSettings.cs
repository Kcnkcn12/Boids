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

    /*--------- Default Settings ------------*/
    /*--------- These settings will also override current settings when app is loaded.
       I do not wish to make a settings file to save settings for this project. ------------*/

    // used to make Unity inspector clearer
    [SerializeField] bool GapToSeparateCurrentValuesFromDefaults;

    [SerializeField] float defaultDetectionDistance;

    [SerializeField] float defaultSeparationModifier;
    [SerializeField] float defaultAlignmentModifier;
    [SerializeField] float defaultCohesionModifier;

    [SerializeField] int defaultRayCount;
    [SerializeField] float defaultObstacleAvoidanceModifier;

    [SerializeField] float defaultMinVelocity;
    [SerializeField] float defaultMaxVelocity;

    // OnEnable() is called when the object is loaded
    void OnEnable()
    {
        detectionDistance = defaultDetectionDistance;

        separationModifier = defaultSeparationModifier;
        alignmentModifier = defaultAlignmentModifier;
        cohesionModifier = defaultCohesionModifier;

        rayCount = defaultRayCount;
        obstacleAvoidanceModifier = defaultObstacleAvoidanceModifier;

        minVelocity = defaultMinVelocity;
        maxVelocity = defaultMaxVelocity;
    }

}
