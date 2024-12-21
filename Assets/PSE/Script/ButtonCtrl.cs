using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCtrl : MonoBehaviour
{
    [SerializeField] private GameObject option;

    void Update()
    {
        // 옵션 창이 활성화되어 있고, 마우스 왼쪽 버튼이 클릭되었을 때
        if (option.activeSelf && Input.GetMouseButtonDown(0))
        {
            // 클릭한 위치가 옵션 창 외부인지 확인
            if (!IsClickOnOption())
            {
                option.SetActive(false); // 옵션 창 숨기기
            }
        }
    }

    public void PressRestart()  // 게임 재시작 버튼
    {
        GameManager.instance.Restart();
    }

    public void PressExit()  // 게임 나가기
    {
        Application.Quit();
    }

    public void PressOption()  // 메인화면 옵션
    {
        option.SetActive(!option.activeSelf);
    }

    private bool IsClickOnOption()
    {
        // 클릭한 위치가 옵션 창 내부인지 확인하기 위한 Raycast 처리
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider != null && hit.collider.gameObject == option)
            {
                return true; // 옵션 창 내부 클릭
            }
        }
        return false; // 옵션 창 외부 클릭
    }
}
