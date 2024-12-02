using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Hammer_ctrl : MonoBehaviour
{
    // ȸ�� �ӵ�
    public float rotationSpeed = 30f;

    // ȸ�� ���� (�ִ� ����)
    public float maxRotationAngle = 45f;

    // ���� ȸ�� ����
    private float currentRotationAngle = 0f;

    // ȸ�� ���� (1�� �ð����, -1�� �ݽð����)
    private int rotationDirection = 1;

    void Update()
    {
        // ȸ�� ó��
        currentRotationAngle += rotationSpeed * Time.deltaTime * rotationDirection;

        // ȸ�� ������ �ִ� �Ǵ� �ּ� ���� �ʰ��ϸ� ������ ������Ŵ
        if (currentRotationAngle >= maxRotationAngle || currentRotationAngle <= -maxRotationAngle)
        {
            rotationDirection *= -1; // ȸ�� ������ ����
        }

        // X���� �������� ȸ��
        transform.rotation = Quaternion.Euler(currentRotationAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
