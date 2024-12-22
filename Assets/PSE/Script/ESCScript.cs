using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCScript : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private MonoBehaviour playerCtrl;

    void Update()
    {
        // esc�� ������ ����
        if (Input.GetKeyDown(KeyCode.Escape) && !panel.activeSelf)
        {
            panel.SetActive(true);
            MouseCursorCtrl.Instance.SetCursorVisible(true, CursorLockMode.None);
            Time.timeScale = 0;
            playerCtrl.enabled = false;
        }
        // �� �� �� ������ ����
        else if (Input.GetKeyDown(KeyCode.Escape) && panel.activeSelf)
        {
            panel.SetActive(false);
            MouseCursorCtrl.Instance.SetCursorVisible(false, CursorLockMode.Locked);
            Time.timeScale = 1;
            playerCtrl.enabled = true;
        }
    }
}
