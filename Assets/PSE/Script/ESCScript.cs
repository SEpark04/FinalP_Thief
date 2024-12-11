using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCScript : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private MonoBehaviour playerCtrl;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !panel.activeSelf)
        {
            panel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            playerCtrl.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && panel.activeSelf)
        {
            panel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            playerCtrl.enabled = true;
        }
    }
}
