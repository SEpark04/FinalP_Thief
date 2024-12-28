using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_turn_2_Ctrl : MonoBehaviour
{
    // 장애물 움직임과 회전에 대한 변수
    public float rotationSpeed = -10f;
    public float moveSpeed = 5f;

    // 탐지 범위와 태그 설정
    public float detectionRange = 10f; // 탐지 반경
    private string playerTag = "Player";

    // 플레이어를 발견했는지 여부를 추적하는 변수
    private bool isPlayerDetected = false;

    // 이동 거리 추적 변수
    private Vector3 initialPosition;
    public float moveDistanceLimit = 20f; // 최대 이동 거리

    //플레이어 충돌 관련 변수
    private Collider colliders;
    public float dmg = 30f;

    void Start()
    {
        colliders = GetComponent<Collider>();
    }

    void Update()
    {
        // 구형 탐지 수행
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRange);

        foreach (Collider hitCollider in hitColliders)
        {
            // 플레이어가 탐지되었는지 확인
            if (hitCollider.CompareTag(playerTag))
            {
                isPlayerDetected = true;
                initialPosition = transform.position; // 초기 위치 저장
                break; // 탐지되었으면 더 이상 탐색할 필요 없음
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

        // 이동한 거리를 계산
        float movedDistance = Vector3.Distance(initialPosition, transform.position);

        // 일정 거리 이상 이동하면 비활성화
        if (movedDistance >= moveDistanceLimit)
        {
            gameObject.SetActive(false);
        }
    }

    // 디버그용: Scene 뷰에서 탐지 범위를 시각화
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange); // 구형 탐지 범위를 시각화
    }


    // 플레이어 충돌 코드
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colliders.enabled = false;
            HpCtrl.instance.Hp_down(dmg);
            //HitEffectScript.instance.HitEffect();
            //Destroy(this.gameObject);
        }
    }
}