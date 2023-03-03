using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MessageBall_Embeded : MonoBehaviour
{
    public float speed = 10f;
    public float maxAngle = 45f;
    public float randomVelocityMin = 0f;
    public float randomVelocityMax = 10f;
    public LayerMask wallLayer;
    public Transform objectTransform;

    private Rigidbody objectRigidbody;

    void Start()
    {
        objectRigidbody = objectTransform.GetComponent<Rigidbody>();

        // Generate a random initial direction and apply a force to the object in that direction
        Vector3 initialDirection = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f) * Vector3.forward;
        objectRigidbody.AddForce(initialDirection * speed, ForceMode.VelocityChange);
    }

    void FixedUpdate()
    {
        // Check if the object has collided with a wall
        RaycastHit hit;
        if (Physics.Raycast(objectTransform.position, objectRigidbody.velocity.normalized, out hit, speed * Time.fixedDeltaTime, wallLayer))
        {
            // Reflect the velocity vector around the surface normal of the wall
            Vector3 normal = hit.normal;
            Vector3 newDirection = Vector3.Reflect(objectRigidbody.velocity, normal);

            // Add a random velocity to the new direction
            float randomVelocity = Random.Range(randomVelocityMin, randomVelocityMax);
            Vector3 randomOffset = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * randomVelocity;
            Vector3 finalDirection = newDirection + randomOffset;

            // Limit the angle between the old and new directions to the maximum angle
            float angle = Vector3.Angle(objectRigidbody.velocity.normalized, finalDirection.normalized);
            if (angle > maxAngle)
            {
                finalDirection = Vector3.RotateTowards(objectRigidbody.velocity.normalized, finalDirection.normalized, Mathf.Deg2Rad * maxAngle, 0f);
            }

            // Set the new velocity of the object
            objectRigidbody.velocity = finalDirection.normalized * objectRigidbody.velocity.magnitude;
        }

    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

}
