using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int hits = 0;


    // Keeping count how many times Cubeman bumps something.
    private void OnCollisionEnter(Collision collision)
    {
        hits++;
        Debug.Log("You touch the wall this many time: " + hits);
    }
}
