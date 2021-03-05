using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int hits = 0;

<<<<<<< HEAD
    // Keeping count how many times Cubeman bumps something.
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Hit")
        {
            hits++;
            Debug.Log("You touch the wall this many time: " + hits);
        }

=======

    // Keeping count how many times Cubeman bumps something.
    private void OnCollisionEnter(Collision collision)
    {
        hits++;
        Debug.Log("You touch the wall this many time: " + hits);
>>>>>>> 0fd9d5f876b748405e4745eefe6769315919703a
    }
}
