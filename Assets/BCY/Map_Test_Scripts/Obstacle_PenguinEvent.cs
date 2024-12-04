using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_PenguinEvent : MonoBehaviour
{
    public GameObject gameObjectPrefab; // ������ ������Ʈ�� ������
    public float fallSpeed = 5f; // �������� �ӵ�

    void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� "Player" �±׸� ������ ���� ���
        if (other.CompareTag("Player"))
        {
            // �÷��̾� ��ġ ��������
            Vector3 playerPosition = other.transform.position;

            // �÷��̾��� y�� ���ϴ� ��ġ��ŭ ���� ������Ʈ ����
            Vector3 spawnPosition = playerPosition + new Vector3(0, 5, 0);
            GameObject spawnedObject = Instantiate(gameObjectPrefab, spawnPosition, Quaternion.identity);

            // ������ ������Ʈ�� �÷��̾ ���� ���������� ó��
            StartCoroutine(FallTowardsPlayer(spawnedObject, playerPosition));
        }
    }

    IEnumerator FallTowardsPlayer(GameObject fallingObject, Vector3 targetPosition)
    {
        // ������Ʈ�� Ÿ�� ��ġ�� ������ ������ �ݺ�
        while (fallingObject != null && fallingObject.transform.position.y > targetPosition.y)
        {
            // y�� �������� ���� �ӵ��� �̵�
            Vector3 currentPosition = fallingObject.transform.position;
            fallingObject.transform.position = Vector3.MoveTowards(currentPosition, targetPosition, fallSpeed * Time.deltaTime);

            // ���� �����ӱ��� ���
            yield return null;
        }

        // ������Ʈ�� �÷��̾� ��ġ�� �����ϸ� Destroy ó�� ���� (�ɼ�)
        if (fallingObject != null)
        {
            Destroy(fallingObject); // �ʿ�� ����
        }
    }
}
