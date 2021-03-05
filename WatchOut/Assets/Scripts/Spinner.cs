using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float xAngle = 0f;
    [SerializeField] float yAngle = 0.5f;
    [SerializeField] float zAngle = 0f;
    // Update is called once per frame
    void Update()
    {
        Spin();
    }

    public void Spin()
    {
        transform.Rotate(xAngle, yAngle, zAngle);
    }
}
