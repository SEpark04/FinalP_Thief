using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLine_ctrl : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 "Player" 태그를 가지고 있을 경우
        if (other.CompareTag("Player"))
        {
            if (gameManager != null)
            {
                gameManager.gotoGoodEnding();
            }
        }
    }


}
