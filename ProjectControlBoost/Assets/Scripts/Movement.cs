using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        // Left Arrow
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Debug.Log("Pressing Left arrow.");
        }
        // Right Arrow
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Debug.Log("Pressing Right arrow");
        }
    }

    private void ProcessThrust()
    {
        // Space bar
        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Press Space... Lift off");
        }
    }
}
