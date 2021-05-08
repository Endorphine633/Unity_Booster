using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float thrust = 1000f;
    [SerializeField] private float rotationSpeed = 100f;
    private Rigidbody mRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {        
        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("SPACE pressed - Thrust");
            mRigidbody.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
        }
    }

     private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
            //Debug.Log("'a' pressed - Rotate left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationSpeed);
            //Debug.Log("'d' pressed - Rotate right");
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        mRigidbody.freezeRotation = true; //Freeze physic rotation
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        mRigidbody.freezeRotation = false;
    }
}
