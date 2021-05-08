using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float xSpinn = 0f;
    [SerializeField] private float ySpinn = 1f;
    [SerializeField] private float zSpinn = 0f;
    [SerializeField] private bool counterClock = true;
  

    // Update is called once per frame
    void Update()
    {
        if(counterClock)
        {
            transform.Rotate(xSpinn, ySpinn, zSpinn);
        }
        else
        {
            transform.Rotate(xSpinn, -ySpinn, zSpinn);
        }
        
    }
}
