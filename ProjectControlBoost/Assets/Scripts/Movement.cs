﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrust = 1000;
    [SerializeField] float rotationForce = 100;
  

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        }
        // Right Arrow
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            // Frame rate indenpendent.
            ControlRotate(-rotationForce);
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
        }
    }
}
