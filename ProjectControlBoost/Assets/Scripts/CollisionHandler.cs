using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Your on the launch pad");
                break;
            case "Finish":
                NextLevel();
                break;
            default:
                ReloadLevel(); 
                break;

        }
    }

    private void NextLevel()
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
    private static void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
