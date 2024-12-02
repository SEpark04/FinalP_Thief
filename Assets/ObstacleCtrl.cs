using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleCtrl : MonoBehaviour
{
    public float turnSpeed = 5.0f;
    public Transform centerPos;
    public float maxRadius = 0.5f;

    void Start()
    {
        if (centerPos == null)
        {
            centerPos = transform;
        }

        Vector3 direction = (transform.position - centerPos.position).normalized;
        transform.position = centerPos.position + direction * maxRadius;
    }
    void Update()
    {
        transform.RotateAround(centerPos.position,Vector3.forward, turnSpeed * Time.deltaTime);

    }
}
