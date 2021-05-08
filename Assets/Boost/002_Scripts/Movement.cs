using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float thrust = 1000f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private AudioClip audioClipThrust;
    [SerializeField] private ParticleSystem particleSystemBooster;
    [SerializeField] private ParticleSystem particleSystemSideThrusterLeft;
    [SerializeField] private ParticleSystem particleSystemSideThrusterRight;

    private Rigidbody mRigidbody;
    private AudioSource mAudioSource;

    void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
        mAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {        
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }
    private void StartThrusting()
    {
        if (!particleSystemBooster.isPlaying)
        {
            particleSystemBooster.Play();
        }
        mRigidbody.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
        if (!mAudioSource.isPlaying)
        {
            mAudioSource.PlayOneShot(audioClipThrust);
        }
    }
    private void StopThrusting()
    {
        mAudioSource.Stop();
        particleSystemBooster.Stop();
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotation();
        }
    }   
    private void RotateRight()
    {
        ApplyRotation(-rotationSpeed);
        if (!particleSystemSideThrusterLeft.isPlaying)
        {
            particleSystemSideThrusterLeft.Play();
        }
    }
    private void RotateLeft()
    {
        ApplyRotation(rotationSpeed);
        if (!particleSystemSideThrusterRight.isPlaying)
        {
            particleSystemSideThrusterRight.Play();
        }
    }
    private void StopRotation()
    {
        particleSystemSideThrusterLeft.Stop();
        particleSystemSideThrusterRight.Stop();
    }
    private void ApplyRotation(float rotationThisFrame)
    {
        mRigidbody.freezeRotation = true; //Freeze physic rotation
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        mRigidbody.freezeRotation = false;
    }

}
