using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{

    public float distance = 4.0f;  //�Ÿ�
    public float height = 2.0f;  //����
    public float dampingTrace = 15;  //���� ����

    public Transform targetTr;

    void LateUpdate()  
    {
        // ī�޶� ����
        transform.position = Vector3.Lerp(transform.position,
            targetTr.position - targetTr.forward * distance + Vector3.up * height,
            Time.deltaTime * dampingTrace);

        transform.LookAt(targetTr.position + Vector3.up * 3.0f);
    }

}
