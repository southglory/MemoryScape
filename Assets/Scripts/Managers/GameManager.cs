using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float targetFps = 60f;
    // Start is called before the first frame update
    void Start()
    {
        // Set the target frame rate
        Application.targetFrameRate = Mathf.RoundToInt(targetFps);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
