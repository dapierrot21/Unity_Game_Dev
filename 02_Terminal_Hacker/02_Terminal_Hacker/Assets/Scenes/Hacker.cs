using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local bank.");
        Terminal.WriteLine("Press 2 for the F.B.I.");
        Terminal.WriteLine("Press 3 for Area 51.");
        Terminal.WriteLine("Enter your selection: ");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
