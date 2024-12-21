using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCtrl : MonoBehaviour
{

    void Update()
    {
        // 스페이스바를 누르면 게임 시작
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
