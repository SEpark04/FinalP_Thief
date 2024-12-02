using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_turn_2_Ctrl : MonoBehaviour
{
    public GameObject target;
    public float fieldOfViewAngle = 50f;
    public float viewDistance = 10f;
    private bool isLockedOn = false;

    //회전 변수
    public float rotationSpeed = 10f;
    public float moveSpeed = 5f;
   
   
    void Update()
    {
        CheckForTarget();


        if (isLockedOn)
        {
            transform.Rotate(rotationSpeed, 0, 0);
            transform.position -= new Vector3(0, 0, moveSpeed * Time.deltaTime);
        }
        else
        {
            enabled = false;
        }


    }

    void CheckForTarget()
    {
        Vector3 directionToTarget = target.transform.position - transform.position;
        float angleToTarget = Vector3.Angle(transform.forward, directionToTarget);

        if (angleToTarget <= fieldOfViewAngle / 2 && directionToTarget.magnitude <= viewDistance)
        {
            Ray ray = new Ray(transform.position, directionToTarget);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, viewDistance))
            {
                if (hit.transform == target.transform)
                {
                    isLockedOn = true; // 타겟이 시야 내에 있음
                    return;
                }
            }

        }

        isLockedOn = false;
    }
}
