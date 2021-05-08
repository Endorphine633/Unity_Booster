using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float loadDelay = 1f;
    [SerializeField] private AudioClip audioClipCrash;
    [SerializeField] private AudioClip audioClipFinished;
    [SerializeField] private ParticleSystem particleSystemCrash;
    [SerializeField] private ParticleSystem particleSystemFinished;

    private AudioSource mAudiosource;

    private bool isTransitioning = false;
    private bool collisionDisabled = false;

    private void Start()
    {
        mAudiosource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        RespondToDebugKeys();
    }

    private void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            //Toggle bool
            collisionDisabled = !collisionDisabled;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collisionDisabled) { return; }
        if (isTransitioning) { return; }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Hit Start Platform");
                break;
            case "Finished":
                StartLevelFinishSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }               
    }
    private void StartCrashSequence()
    {
        isTransitioning = true;
        mAudiosource.Stop();
        mAudiosource.PlayOneShot(audioClipCrash);
        particleSystemCrash.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", loadDelay);     
    }
    private void StartLevelFinishSequence()
    {
        isTransitioning = true;
        mAudiosource.Stop();
        mAudiosource.PlayOneShot(audioClipFinished);
        particleSystemFinished.Play();
        GetComponent<Movement>().enabled = false;        
        Invoke("LoadNextLevel", loadDelay);  
    }
    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentSceneIndex + 1;
        if (nextLevelIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextLevelIndex = 0;
        }
        SceneManager.LoadScene(nextLevelIndex);
    }
}
