using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField] BoidSettings boidSettings;

    [SerializeField] Slider detectiondistanceSlider;
    [SerializeField] Slider SeparatioSlider;
    [SerializeField] Slider AlignmentSlider;
    [SerializeField] Slider CohesionSlider;
    [SerializeField] Slider ObstacleAvoidanceSlider;

    // Start is called before the first frame update
    void Start()
    {
        detectiondistanceSlider.value = boidSettings.detectionDistance;
        SeparatioSlider.value = boidSettings.separationModifier;
        AlignmentSlider.value = boidSettings.alignmentModifier;
        CohesionSlider.value = boidSettings.cohesionModifier;
        ObstacleAvoidanceSlider.value = boidSettings.obstacleAvoidanceModifier;
    }


    public void UpdateDetectionDistanceModifier(float newValue)
    {
        boidSettings.detectionDistance = newValue;
    }

    public void UpdateSeparationModifier(float newValue)
    {
        boidSettings.separationModifier = newValue;
    }

    public void UpdateAlignmentModifier(float newValue)
    {
        boidSettings.alignmentModifier = newValue;
    }

    public void UpdateCohesionModifier(float newValue)
    {
        boidSettings.cohesionModifier = newValue;
    }

    public void UpdateObstacleAvoidanceModifier(float newValue)
    {
        boidSettings.obstacleAvoidanceModifier = newValue;
    }
}
