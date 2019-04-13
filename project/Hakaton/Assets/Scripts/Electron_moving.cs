using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electron_moving : MonoBehaviour
{
    public float radius;
    public float speed;
    float angle;
    Vector3 axis = new Vector3(0,1,0);
    Quaternion rotateQuaternion;
    void Start()
     {
        angle = 180f*speed/radius/3.14159f;
        transform.position = new Vector3(-radius, 0, 0);
        rotateQuaternion = Quaternion.AngleAxis(angle, axis);
    }
    void FixedUpdate()
    {
        transform.rotation*=rotateQuaternion;
        transform.position+=transform.forward*speed;
    }
}
