using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    // When a object run into our wall.
    private void OnCollisionEnter(Collision collision)
    {
<<<<<<< HEAD
        if(collision.gameObject.tag == "Player")
        {
            // Change wall material when touched by Cubeman.
            GetComponent<MeshRenderer>().material.color = Color.blue;
            gameObject.tag = "Hit";
        }

=======
        // Change wall material when touched by Cubeman.
        GetComponent<MeshRenderer>().material.color = Color.blue;
>>>>>>> 0fd9d5f876b748405e4745eefe6769315919703a

    }
}
