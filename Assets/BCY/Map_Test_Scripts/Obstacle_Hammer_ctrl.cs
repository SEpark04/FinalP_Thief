using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Hammer_ctrl : MonoBehaviour
{
    // 회전 속도
    public float rotationSpeed = 30f;

    // 회전 범위 (최대 각도)
    public float maxRotationAngle = 45f;

    // 현재 회전 각도 (실제 적용할 값)
    private float currentRotationAngle = 0f;

    // 목표 회전 각도
    private float targetRotationAngle = 0f;

    // 회전 방향 (1은 시계방향, -1은 반시계방향)
    private int rotationDirection = 1;

    void Update()
    {
        // 목표 각도 계산
        targetRotationAngle += rotationSpeed * Time.deltaTime * rotationDirection;

        // 목표 각도가 최대 또는 최소 값을 초과하면 방향을 반전
        if (targetRotationAngle >= maxRotationAngle || targetRotationAngle <= -maxRotationAngle)
        {
            rotationDirection *= -1; // 회전 방향을 반전
            targetRotationAngle = Mathf.Clamp(targetRotationAngle, -maxRotationAngle, maxRotationAngle);
        }

        // 현재 회전 각도를 부드럽게 목표 각도로 보간
        currentRotationAngle = Mathf.Lerp(currentRotationAngle, targetRotationAngle, Time.deltaTime * 2f);

        // Z축을 기준으로 회전
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, currentRotationAngle);
    }

}
