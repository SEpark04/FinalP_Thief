using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{

    public float distance = 4.0f;  //거리
    public float height = 2.0f;  //높이
    public float dampingTrace = 15;  //댐핑 정도

    public Transform targetTr;

    void LateUpdate()  
    {
        // 카메라 댐핑
        transform.position = Vector3.Lerp(transform.position,
            targetTr.position - targetTr.forward * distance + Vector3.up * height,
            Time.deltaTime * dampingTrace);

        transform.LookAt(targetTr.position + Vector3.up * 3.0f);
    }

}
