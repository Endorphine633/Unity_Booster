using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;

    Vector3 startPosition;
    float movementFactor;
    float cycles;
    float rawSinWave;

    const float tau = Mathf.PI * 2;                             // constant value of 6.283

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if(period <= Mathf.Epsilon) { return; }                 //Do not compare floats against 0. Use <= Mathf.Elipson instead
        cycles = Time.time / period;                            // continually growing over time   
        rawSinWave = Mathf.Sin(cycles * tau);                   // going from -1 to 1
        movementFactor = (rawSinWave + 1f) / 2f;                // recalculating to going from 0 to 1

        Vector3 offset = movementVector * movementFactor;       // calculate the offset per frame
        transform.position = startPosition + offset;            // move gameobject
    }
}
