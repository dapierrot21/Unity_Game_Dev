using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    // When a object run into our wall.
    private void OnCollisionEnter(Collision collision)
    {
        // Change wall material when touched by Cubeman.
        GetComponent<MeshRenderer>().material.color = Color.blue;

    }
}
