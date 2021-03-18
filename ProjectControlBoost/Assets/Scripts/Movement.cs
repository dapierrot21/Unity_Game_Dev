using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float thrust = 1000f;
    [SerializeField] float rotationForce = 100f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainBoosterParticles;
    [SerializeField] ParticleSystem leftBoosterParticles;
    [SerializeField] ParticleSystem rightBoosterParticles;

    Rigidbody rb;
    AudioSource audio;

 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ThrustRocket();
        RotateRocket();
    }

    private void RotateRocket()
    {
        // Left Arrow
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            // Frame rate independent.
            ControlRotate(rotationForce);
            // Left booster particles.
            if(!leftBoosterParticles.isPlaying)
            {
                leftBoosterParticles.Play();
            }
            
        }
        // Right Arrow
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            // Frame rate indenpendent.
            ControlRotate(-rotationForce);
            // Right booster paticles.
            if(!rightBoosterParticles.isPlaying)
            {
                rightBoosterParticles.Play();
            }
        }
        else
        {
            rightBoosterParticles.Stop();
            leftBoosterParticles.Stop();
        }
    }

    private void ControlRotate(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate.
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over.
    }

    private void ThrustRocket()
    {
        // Space bar
        if(Input.GetKey(KeyCode.Space))
        {
            // x, y, z
            rb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
            
            if (!audio.isPlaying)
            {
                audio.PlayOneShot(mainEngine);
                
            }
            if(!mainBoosterParticles.isPlaying)
            {
                mainBoosterParticles.Play();
            }
            
        }
        else
        {
            audio.Stop();
            mainBoosterParticles.Stop();
        }
    }
}
