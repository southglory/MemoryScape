using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Embeded : MonoBehaviour
{
    void OnPreCull() => GL.Clear(true, true, Color.black);

    void Start()    
    {
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;
        float scaleheight = ((float)Screen.width / Screen.height) / ((float)16 / 9); // (가로 / 세로)
        float scalewidth = 1f / scaleheight;
        if (scaleheight < 1)
        {
            rect.height = scaleheight;
            rect.y = (1f - scaleheight) / 2f;
        }
        else
        {
            rect.width = scalewidth;
            rect.x = (1f - scalewidth) / 2f;
        }
        camera.rect = rect;
    }

    void Update()
    {
        // Check if the user clicks the mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera to the clicked point
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            print("Click");
            // Check if the ray hits an object with a collider
            if (Physics.Raycast(ray, out hit))
            {
                // Draw a debug line from the camera to the hit point
                Debug.DrawLine(ray.origin, hit.point, Color.red, 2.0f);

                // Check if the object has a specific component
                MessageBall_Embeded component = hit.collider.GetComponent<MessageBall_Embeded>();
                if (component != null)
                {   
                    // Call the specific function on the object
                    component.DestroySelf();
                }
            }
            else
            {
                // Log a message if the raycast misses
                Debug.Log("Raycast miss!");
            }
        }
    }

}
