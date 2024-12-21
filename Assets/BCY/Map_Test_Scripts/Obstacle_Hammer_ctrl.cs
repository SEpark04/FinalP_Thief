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

    public float dmg = 1;
    private Collider colliders;

    private void Start()
    {
        colliders = GetComponent<Collider>();
    }
    void Update()
    {
        // ��ǥ ���� ���
        targetRotationAngle += rotationSpeed * Time.deltaTime * rotationDirection;

        // ��ǥ ������ �ִ� �Ǵ� �ּ� ���� �ʰ��ϸ� ������ ����
        if (targetRotationAngle >= maxRotationAngle || targetRotationAngle <= -maxRotationAngle)
        {
            rotationDirection *= -1; // ȸ�� ������ ����
            targetRotationAngle = Mathf.Clamp(targetRotationAngle, -maxRotationAngle, maxRotationAngle);
        }

        // ���� ȸ�� ������ �ε巴�� ��ǥ ������ ����
        currentRotationAngle = Mathf.Lerp(currentRotationAngle, targetRotationAngle, Time.deltaTime * 2f);

        // Z���� �������� ȸ��
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, currentRotationAngle);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colliders.enabled = false;
            HpCtrl.instance.Hp_down(dmg);
            HitEffectScript.instance.HitEffect();
            //Destroy(this.gameObject);
        }
    }

}
