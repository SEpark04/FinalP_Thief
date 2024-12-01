using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_turn_Ctrl : MonoBehaviour
{
    public float rotationSpeed = 10f;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
