using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public static CameraChange instance;

    public GameObject player;  // 기본 카메라
    public GameObject backCamera;  // 후방 카메라

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        player.SetActive(true);  // 기본 카메라 활성화
        backCamera.SetActive(false);  // 후방 카메라 비활성화
    }

    void Update()
    {
        if (Input.GetMouseButton(1))  // 우클릭을 누르고 있는 동안
        {
            player.SetActive(false);  // 기본 카메라 비활성화
            backCamera.SetActive(true);  // 후방 카메라 활성화
        }
        else  // 우클릭을 떼면
        {
            player.SetActive(true);  // 기본 카메라 활성화
            backCamera.SetActive(false);  // 후방 카메라 비활성화
        }
    }
}

