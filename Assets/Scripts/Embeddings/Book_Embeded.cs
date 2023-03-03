using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book_Embeded : MonoBehaviour
{
    public float rotationSpeed = 50f;

    void Update()
    {
        // Get the current position of the object in world space
        Vector3 center = transform.position;

        // Rotate around the Y axis of the world coordinate system with self as the center
        transform.RotateAround(center, Vector3.up, rotationSpeed * Time.deltaTime);
    }

}
