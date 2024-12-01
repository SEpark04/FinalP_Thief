using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_turn_2_Ctrl : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float moveSpeed = 5f;


    
    void Update()
    {
        transform.Rotate(rotationSpeed, 0, 0);
        transform.position -= new Vector3(0, 0, moveSpeed * Time.deltaTime);
    }
}
