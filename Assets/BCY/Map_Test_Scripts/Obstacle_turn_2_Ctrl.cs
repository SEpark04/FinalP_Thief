using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_turn_2_Ctrl : MonoBehaviour
{
    // 장애물 움직임과 회전에 대한 변수
    public float rotationSpeed = -10f;
    public float moveSpeed = 5f;

    // 레이캐스트의 범위
    public float detectionRange = 10f;

    // 레이캐스트가 감지할 대상 (플레이어 태그를 설정)
    public string playerTag = "Player";

    // 플레이어를 발견했는지 여부를 추적하는 변수
    private bool isPlayerDetected = false;

    // Update에서 레이캐스트 실행
    void Update()
    {
        // 레이캐스트 발사
        RaycastHit hit;
        Vector3 rayDirection = transform.right; // Z축 기준으로 Ray를 발사하기 위한 방향 설정

        if (Physics.Raycast(transform.position, rayDirection, out hit, detectionRange))
        {
            // 충돌한 오브젝트의 태그가 플레이어인지 확인
            if (hit.collider.CompareTag(playerTag))
            {
                isPlayerDetected = true;
            }
        }

        // 플레이어를 발견했다면 계속 움직임
        if (isPlayerDetected)
        {
            MoveObstacle();
        }
    }

    // 장애물을 계속 움직이게 하는 메서드
    void MoveObstacle()
    {
        // 회전
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime, Space.Self);
        // 이동
        transform.position -= new Vector3(0, 0, moveSpeed * Time.deltaTime);
    }

    // 디버그용: Scene 뷰에서 레이캐스트를 시각화
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 rayDirection = transform.right; // Z축 방향으로 시각화
        Gizmos.DrawLine(transform.position, transform.position + rayDirection * detectionRange);
    }
}