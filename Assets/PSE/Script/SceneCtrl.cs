using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCtrl : MonoBehaviour
{

    void Update()
    {
        // �����̽��ٸ� ������ ���� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gotoGame();
        }
    }

    void gotoGame()
    {
        LoadingCtrl.LoadScene("Map");
    }
}
