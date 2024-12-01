using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public static CameraChange instance;

    public GameObject player;  // �⺻ ī�޶�
    public GameObject backCamera;  // �Ĺ� ī�޶�

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        player.SetActive(true);  // �⺻ ī�޶� Ȱ��ȭ
        backCamera.SetActive(false);  // �Ĺ� ī�޶� ��Ȱ��ȭ
    }

    void Update()
    {
        if (Input.GetMouseButton(1))  // ��Ŭ���� ������ �ִ� ����
        {
            player.SetActive(false);  // �⺻ ī�޶� ��Ȱ��ȭ
            backCamera.SetActive(true);  // �Ĺ� ī�޶� Ȱ��ȭ
        }
        else  // ��Ŭ���� ����
        {
            player.SetActive(true);  // �⺻ ī�޶� Ȱ��ȭ
            backCamera.SetActive(false);  // �Ĺ� ī�޶� ��Ȱ��ȭ
        }
    }
}

