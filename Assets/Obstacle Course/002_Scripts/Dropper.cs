using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] private float timeToWait = 5f;

    MeshRenderer mRenderer;
    Rigidbody mRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        mRenderer = GetComponent<MeshRenderer>();
        mRigidbody = GetComponent<Rigidbody>();

        mRenderer.enabled = false;
        mRigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(Time.time > timeToWait)
        {
            mRenderer.enabled = true;
            mRigidbody.useGravity = true;
        }
        
    }
}
