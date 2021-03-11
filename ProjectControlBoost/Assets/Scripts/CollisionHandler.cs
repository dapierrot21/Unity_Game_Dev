using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delaySeconds = 1f;
    [SerializeField] AudioClip crashLanding;
    [SerializeField] AudioClip successfulLanding;

    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
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
        audio.PlayOneShot(successfulLanding);
        // Disable controls after landing.
        GetComponent<Movement>().enabled = false;
        // Waiting 1secs before loading of next level.
        Invoke("NextLevel", delaySeconds);
    }

    void StartCrashSequence()
    {
 
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
