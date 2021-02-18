using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // SerializeField allows usage in unity env.
    [SerializeField] float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        CubeMan();
    }

    public void CubeMan()
    {
        //Distance Per Second: FPS * DOF * moveSpeed
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zFloat = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        // Accessing Player(Cubeman) object.
        transform.Translate(xValue, 0, zFloat);
    }
}
