﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delaySeconds = 1f;
    [SerializeField] AudioClip crashLanding;
    [SerializeField] AudioClip successfulLanding;

    AudioSource audio;

    bool isTransitioning = false;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(isTransitioning) { return; }

        switch(collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Your on the launch pad");
                break;
            case "Finish":
                SuccessLanding();
                break;
            default:
                StartCrashSequence(); 
                break;

        }
    }

    void SuccessLanding()
    {
        isTransitioning = true;
        audio.Stop();
        audio.PlayOneShot(successfulLanding);
        GetComponent<Movement>().enabled = false;  // Disable controls after landing.
        Invoke("NextLevel", delaySeconds);  // Waiting 1secs before loading of next level.
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audio.Stop();
        audio.PlayOneShot(crashLanding);
        // Disable controls after crash.
        GetComponent<Movement>().enabled = false;
        // Waiting 1secs before loading of next level.
        Invoke("ReloadLevel", delaySeconds);
    }

    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextScenceNumber = currentSceneIndex + 1;

        if(nextScenceNumber == SceneManager.sceneCountInBuildSettings)
        {
            nextScenceNumber = 0;
        }

        SceneManager.LoadScene(nextScenceNumber);
        
    }

    // If rocket crash reload scene.
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
