using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    private int hitCount = 0;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Hit")
        {
            hitCount++;
            Debug.Log($"You've bumped into a thing this many times: {hitCount}");
        }
        
    }
}
