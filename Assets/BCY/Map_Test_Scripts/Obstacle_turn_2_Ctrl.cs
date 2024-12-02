using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_turn_2_Ctrl : MonoBehaviour
{
    // ��ֹ� �����Ӱ� ȸ���� ���� ����
    public float rotationSpeed = -10f;
    public float moveSpeed = 5f;

    // ����ĳ��Ʈ�� ����
    public float detectionRange = 10f;

    // ����ĳ��Ʈ�� ������ ��� (�÷��̾� �±׸� ����)
    public string playerTag = "Player";

    // �÷��̾ �߰��ߴ��� ���θ� �����ϴ� ����
    private bool isPlayerDetected = false;

    // Update���� ����ĳ��Ʈ ����
    void Update()
    {
        // ����ĳ��Ʈ �߻�
        RaycastHit hit;
        Vector3 rayDirection = transform.right; // Z�� �������� Ray�� �߻��ϱ� ���� ���� ����

        if (Physics.Raycast(transform.position, rayDirection, out hit, detectionRange))
        {
            // �浹�� ������Ʈ�� �±װ� �÷��̾����� Ȯ��
            if (hit.collider.CompareTag(playerTag))
            {
                isPlayerDetected = true;
            }
        }

        // �÷��̾ �߰��ߴٸ� ��� ������
        if (isPlayerDetected)
        {
            MoveObstacle();
        }
    }

    // ��ֹ��� ��� �����̰� �ϴ� �޼���
    void MoveObstacle()
    {
        // ȸ��
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime, Space.Self);
        // �̵�
        transform.position -= new Vector3(0, 0, moveSpeed * Time.deltaTime);
    }

    // ����׿�: Scene �信�� ����ĳ��Ʈ�� �ð�ȭ
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 rayDirection = transform.right; // Z�� �������� �ð�ȭ
        Gizmos.DrawLine(transform.position, transform.position + rayDirection * detectionRange);
    }
}