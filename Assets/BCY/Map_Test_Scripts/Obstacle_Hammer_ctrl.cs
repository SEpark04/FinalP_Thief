using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Hammer_ctrl : MonoBehaviour
{
    // ȸ�� �ӵ�
    public float rotationSpeed = 30f;

    // ȸ�� ���� (�ִ� ����)
    public float maxRotationAngle = 45f;

    // ���� ȸ�� ���� (���� ������ ��)
    private float currentRotationAngle = 0f;

    // ��ǥ ȸ�� ����
    private float targetRotationAngle = 0f;

    // ȸ�� ���� (1�� �ð����, -1�� �ݽð����)
    private int rotationDirection = 1;

    void Update()
    {
        // ��ǥ ���� ���
        targetRotationAngle += rotationSpeed * Time.deltaTime * rotationDirection;

        // ��ǥ ������ �ִ� �Ǵ� �ּ� ���� �ʰ��ϸ� ������ ����
        if (targetRotationAngle >= maxRotationAngle || targetRotationAngle <= -maxRotationAngle)
        {
            rotationDirection *= -1; // ȸ�� ������ ����
        }

        // ���� ȸ�� ������ �ε巴�� ��ǥ ������ ����
        currentRotationAngle = Mathf.Lerp(currentRotationAngle, targetRotationAngle, Time.deltaTime * rotationSpeed);

        // X���� �������� ȸ��
        transform.rotation = Quaternion.Euler(currentRotationAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
