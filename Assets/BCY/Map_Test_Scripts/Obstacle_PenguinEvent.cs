using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_PenguinEvent : MonoBehaviour
{
    public GameObject gameObjectPrefab; // 복제할 오브젝트의 프리팹
    public float fallSpeed = 5f; // 떨어지는 속도

    void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 "Player" 태그를 가지고 있을 경우
        if (other.CompareTag("Player"))
        {
            // 플레이어 위치 가져오기
            Vector3 playerPosition = other.transform.position;

            // 플레이어의 y축 원하는 수치만큼 위에 오브젝트 생성
            Vector3 spawnPosition = playerPosition + new Vector3(0, 5, 0);
            GameObject spawnedObject = Instantiate(gameObjectPrefab, spawnPosition, Quaternion.identity);

            // 생성된 오브젝트가 플레이어를 향해 떨어지도록 처리
            StartCoroutine(FallTowardsPlayer(spawnedObject, playerPosition));
        }
    }

    IEnumerator FallTowardsPlayer(GameObject fallingObject, Vector3 targetPosition)
    {
        // 오브젝트가 타겟 위치로 떨어질 때까지 반복
        while (fallingObject != null && fallingObject.transform.position.y > targetPosition.y)
        {
            // y축 방향으로 일정 속도로 이동
            Vector3 currentPosition = fallingObject.transform.position;
            fallingObject.transform.position = Vector3.MoveTowards(currentPosition, targetPosition, fallSpeed * Time.deltaTime);

            // 다음 프레임까지 대기
            yield return null;
        }

        // 오브젝트가 플레이어 위치에 도달하면 Destroy 처리 가능 (옵션)
        if (fallingObject != null)
        {
            Destroy(fallingObject); // 필요시 제거
        }
    }
}
