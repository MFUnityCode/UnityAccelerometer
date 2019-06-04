using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accelerometer : MonoBehaviour
{
    
    [Header("Accelerometer")] 
    [SerializeField] private float shakeDetectionThreshold = 2.0f;
    [SerializeField] private float accelerometerUpdateInterval = 1.0f / 60.0f;
    [SerializeField] private float lowPassKernelWidthInSeconds = 1.0f;
    [SerializeField] private float lowPassFilterFactor;
    private float lowPassValue;

    [Header("References")]
    [SerializeField] private Text[] showStats;

    void Start()
    {
        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        shakeDetectionThreshold *= shakeDetectionThreshold;
        lowPassValue = Input.acceleration.y;
    }

    void Update()
    {
        float acceleration = Input.acceleration.y;
        lowPassValue = Mathf.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
        float deltaAcceleration = acceleration - lowPassValue;

        if(deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
            OnShake();
        else if(deltaAcceleration.sqrMagnitude < shakeDetectionThreshold)
        {
            showStats[1].text = "Stoped";
        }
    }

    void OnShake(){
        showStats[0].text = "Input: " + Input.acceleration;
        showStats[1].text = "Moving";
    }
}
