using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

using System;

public class UIControl : MonoBehaviour
{
    [SerializeField] float minModifierValue;
    [SerializeField] float maxModifierValue;

    [SerializeField] int modifierFloatPrecisionAfterDecimal;

    [SerializeField] BoidSettings boidSettings;

    [SerializeField] Slider detectionDistanceSlider;
    [SerializeField] Slider separationSlider;
    [SerializeField] Slider alignmentSlider;
    [SerializeField] Slider cohesionSlider;
    [SerializeField] Slider obstacleAvoidanceSlider;

    [SerializeField] TMP_InputField detectionDistanceInputField;
    [SerializeField] TMP_InputField separationInputField;
    [SerializeField] TMP_InputField alignmentInputField;
    [SerializeField] TMP_InputField cohesionInputField;
    [SerializeField] TMP_InputField obstacleAvoidanceInputField;

    // Start is called before the first frame update
    void Start()
    {
        /*-------- Set Slider Range --------*/

        detectionDistanceSlider.minValue = minModifierValue;
        detectionDistanceSlider.maxValue = maxModifierValue;

        separationSlider.minValue = minModifierValue;
        separationSlider.maxValue = maxModifierValue;

        alignmentSlider.minValue = minModifierValue;
        alignmentSlider.maxValue = maxModifierValue;

        cohesionSlider.minValue = minModifierValue;
        cohesionSlider.maxValue = maxModifierValue;

        obstacleAvoidanceSlider.minValue = minModifierValue;
        obstacleAvoidanceSlider.maxValue = maxModifierValue;

        /*-------- Set Slider Initial Values --------*/

        detectionDistanceSlider.value = boidSettings.detectionDistance;
        separationSlider.value = boidSettings.separationModifier;
        alignmentSlider.value = boidSettings.alignmentModifier;
        cohesionSlider.value = boidSettings.cohesionModifier;
        obstacleAvoidanceSlider.value = boidSettings.obstacleAvoidanceModifier;

    }

    public void UpdateDetectionDistanceModifier(float newValue)
    {
        float truncatedInput = TruncateInput(newValue);

        boidSettings.detectionDistance = truncatedInput;
        detectionDistanceInputField.text = truncatedInput.ToString("n2");
    }

    public void UpdateDetectionDistanceModifier(string newValue)
    {
        float parsedInput = 0.0f;
        if(ParseInput(newValue, out parsedInput))
        {
            float truncatedInput = TruncateInput(parsedInput);

            boidSettings.detectionDistance = truncatedInput;
            detectionDistanceSlider.value = truncatedInput;
            detectionDistanceInputField.text = truncatedInput.ToString("n2");
        }
        else
        {
            // reset input field text to previous valid input
            detectionDistanceInputField.text = boidSettings.detectionDistance.ToString("n2");
        }
    }

    public void UpdateSeparationModifier(float newValue)
    {
        float truncatedInput = TruncateInput(newValue);

        boidSettings.separationModifier = truncatedInput;
        separationInputField.text = truncatedInput.ToString("n2");
    }

    public void UpdateSeparationModifier(string newValue)
    {
        float parsedInput = 0.0f;
        if (ParseInput(newValue, out parsedInput))
        {
            float truncatedInput = TruncateInput(parsedInput);

            boidSettings.separationModifier = truncatedInput;
            separationSlider.value = truncatedInput;
            separationInputField.text = truncatedInput.ToString("n2");
        }
        else
        {
            // reset input field text to previous valid input
            separationInputField.text = boidSettings.separationModifier.ToString("n2");
        }
    }

    public void UpdateAlignmentModifier(float newValue)
    {
        float truncatedInput = TruncateInput(newValue);

        boidSettings.alignmentModifier = truncatedInput;
        alignmentInputField.text = truncatedInput.ToString("n2");
    }

    public void UpdateAlignmentModifier(string newValue)
    {
        float parsedInput = 0.0f;
        if (ParseInput(newValue, out parsedInput))
        {
            float truncatedInput = TruncateInput(parsedInput);

            boidSettings.alignmentModifier = truncatedInput;
            alignmentSlider.value = truncatedInput;
            alignmentInputField.text = truncatedInput.ToString("n2");
        }
        else
        {
            // reset input field text to previous valid input
            alignmentInputField.text = boidSettings.alignmentModifier.ToString("n2");
        }
    }

    public void UpdateCohesionModifier(float newValue)
    {
        float truncatedInput = TruncateInput(newValue);

        boidSettings.cohesionModifier = truncatedInput;
        cohesionInputField.text = truncatedInput.ToString("n2");
    }

    public void UpdateCohesionModifier(string newValue)
    {
        float parsedInput = 0.0f;
        if (ParseInput(newValue, out parsedInput))
        {
            float truncatedInput = TruncateInput(parsedInput);

            boidSettings.cohesionModifier = truncatedInput;
            cohesionSlider.value = truncatedInput;
            cohesionInputField.text = truncatedInput.ToString("n2");
        }
        else
        {
            // reset input field text to previous valid input
            cohesionInputField.text = boidSettings.cohesionModifier.ToString("n2");
        }
    }

    public void UpdateObstacleAvoidanceModifier(float newValue)
    {
        float truncatedInput = TruncateInput(newValue);

        boidSettings.obstacleAvoidanceModifier = truncatedInput;
        obstacleAvoidanceInputField.text = truncatedInput.ToString("n2");
    }

    public void UpdateObstacleAvoidanceModifier(string newValue)
    {
        float parsedInput = 0.0f;
        if (ParseInput(newValue, out parsedInput))
        {
            float truncatedInput = TruncateInput(parsedInput);

            boidSettings.obstacleAvoidanceModifier = truncatedInput;
            obstacleAvoidanceSlider.value = truncatedInput;
            obstacleAvoidanceInputField.text = truncatedInput.ToString("n2");
        }
        else
        {
            // reset input field text to previous valid input
            obstacleAvoidanceInputField.text = boidSettings.obstacleAvoidanceModifier.ToString("n2");
        }
    }

    bool ParseInput(string rawInput, out float parsedValue)
    {
        try
        {
            float parsedTemp = float.Parse(rawInput);
            if (parsedTemp < minModifierValue || parsedTemp > maxModifierValue)
            {
                throw new System.ArgumentOutOfRangeException();
            }

            parsedValue = parsedTemp;
            return true;
        }
        catch (FormatException)
        {
            Debug.Log(rawInput + " is not in a valid format.");
            parsedValue = -1.0f;
            return false;
        }
        catch (OverflowException)
        {
            Debug.Log(rawInput + " is outside of the range of a float.");
            parsedValue = -1.0f;
            return false;
        }
        catch (ArgumentOutOfRangeException)
        {
            Debug.Log(rawInput + " is outside of the accepted range.");
            parsedValue = -1.0f;
            return false;
        }
    }

    // returns the input truncated to a specified number of digits after the decimal
    float TruncateInput(float input)
    {
        return Mathf.Round(input * Mathf.Pow(10.0f, (float)modifierFloatPrecisionAfterDecimal)) / Mathf.Pow(10.0f, (float)modifierFloatPrecisionAfterDecimal);
    }
}
