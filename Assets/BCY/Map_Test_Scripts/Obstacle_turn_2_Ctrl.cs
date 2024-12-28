using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_turn_2_Ctrl : MonoBehaviour
{
    // ��ֹ� �����Ӱ� ȸ���� ���� ����
    public float rotationSpeed = -10f;
    public float moveSpeed = 5f;

    // Ž�� ������ �±� ����
    public float detectionRange = 10f; // Ž�� �ݰ�
    private string playerTag = "Player";

    // �÷��̾ �߰��ߴ��� ���θ� �����ϴ� ����
    private bool isPlayerDetected = false;

    // �̵� �Ÿ� ���� ����
    private Vector3 initialPosition;
    public float moveDistanceLimit = 20f; // �ִ� �̵� �Ÿ�

    //�÷��̾� �浹 ���� ����
    private Collider colliders;
    public float dmg = 30f;

    void Start()
    {
        colliders = GetComponent<Collider>();
    }

    void Update()
    {
        // ���� Ž�� ����
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRange);

        foreach (Collider hitCollider in hitColliders)
        {
            // �÷��̾ Ž���Ǿ����� Ȯ��
            if (hitCollider.CompareTag(playerTag))
            {
                isPlayerDetected = true;
                initialPosition = transform.position; // �ʱ� ��ġ ����
                break; // Ž���Ǿ����� �� �̻� Ž���� �ʿ� ����
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

        // �̵��� �Ÿ��� ���
        float movedDistance = Vector3.Distance(initialPosition, transform.position);

        // ���� �Ÿ� �̻� �̵��ϸ� ��Ȱ��ȭ
        if (movedDistance >= moveDistanceLimit)
        {
            gameObject.SetActive(false);
        }
    }

    // ����׿�: Scene �信�� Ž�� ������ �ð�ȭ
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange); // ���� Ž�� ������ �ð�ȭ
    }


    // �÷��̾� �浹 �ڵ�
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