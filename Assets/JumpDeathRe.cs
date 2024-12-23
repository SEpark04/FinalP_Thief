using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDeathRe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) )  // 게임 오버 시 R키 누르면 게임 재시작
        {
            GameManager.instance.Restart();
        }
    }
}
