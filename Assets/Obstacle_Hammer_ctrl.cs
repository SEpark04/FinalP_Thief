using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Hammer_ctrl : MonoBehaviour
{
    // 회전 속도
    public float rotationSpeed = 30f;

    // 회전 범위 (최대 각도)
    public float maxRotationAngle = 45f;

    // 현재 회전 각도
    private float currentRotationAngle = 0f;

    // 회전 방향 (1은 시계방향, -1은 반시계방향)
    private int rotationDirection = 1;

    void Update()
    {
        // 회전 처리
        currentRotationAngle += rotationSpeed * Time.deltaTime * rotationDirection;

        // 회전 각도가 최대 또는 최소 값을 초과하면 방향을 반전시킴
        if (currentRotationAngle >= maxRotationAngle || currentRotationAngle <= -maxRotationAngle)
        {
            rotationDirection *= -1; // 회전 방향을 반전
        }

        // X축을 기준으로 회전
        transform.rotation = Quaternion.Euler(currentRotationAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
