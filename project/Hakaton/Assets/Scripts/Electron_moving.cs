using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electron_moving : MonoBehaviour
{
    static public bool Freeze { get; set; } = false;
    public float radius;
    public float speed;
    float angle;
    public Vector3 axis;
    public Vector3 startVector;
    Vector3 vector;
    Quaternion rotateQuaternion;
    void Start()
    {
        angle = 180f * speed / radius / 3.14159f;
        transform.position = startVector * radius;
        vector = startVector.normalized;
        vector = Quaternion.AngleAxis(90f, axis) * vector;
    }
    void FixedUpdate()
    {
        if (!Electron_moving.Freeze)
        {
            vector = Quaternion.AngleAxis(angle, axis) * vector;
            transform.position += vector * speed;
        }
    }
}
