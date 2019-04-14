using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    Quaternion originRotation;
    float angle;
    void Start()
    {
        originRotation = transform.rotation;
    }

    
    void FixedUpdate ()
    {
        angle++;
        Quaternion rotationY = Quaternion.AngleAxis(angle, Vector3.up);
        //Quaternion rotationX = Quaternion.AngleAxis(angle, Vector3.right);

        transform.rotation = originRotation * rotationY;
    }
}
