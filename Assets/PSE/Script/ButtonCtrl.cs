using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCtrl : MonoBehaviour
{
    [SerializeField] private GameObject option;

    void Update()
    {
        // �ɼ� â�� Ȱ��ȭ�Ǿ� �ְ�, ���콺 ���� ��ư�� Ŭ���Ǿ��� ��
        if (option.activeSelf && Input.GetMouseButtonDown(0))
        {
            // Ŭ���� ��ġ�� �ɼ� â �ܺ����� Ȯ��
            if (!IsClickOnOption())
            {
                option.SetActive(false); // �ɼ� â �����
            }
        }
    }

    public void PressRestart()  // ���� ����� ��ư
    {
        GameManager.instance.Restart();
    }

    public void PressExit()  // ���� ������
    {
        Application.Quit();
    }

    public void PressOption()  // ����ȭ�� �ɼ�
    {
        option.SetActive(!option.activeSelf);
    }

    private bool IsClickOnOption()
    {
        // Ŭ���� ��ġ�� �ɼ� â �������� Ȯ���ϱ� ���� Raycast ó��
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider != null && hit.collider.gameObject == option)
            {
                return true; // �ɼ� â ���� Ŭ��
            }
        }
        return false; // �ɼ� â �ܺ� Ŭ��
    }
}
