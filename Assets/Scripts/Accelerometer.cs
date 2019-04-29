using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accelerometer : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private Text text;
    [SerializeField] private Text textInfo;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 ac = Input.acceleration;
        textInfo.text = "X = " + ac.x + "Y = " + ac.y;
    }
}
