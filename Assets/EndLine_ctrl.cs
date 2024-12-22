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
        // �浹�� ������Ʈ�� "Player" �±׸� ������ ���� ���
        if (other.CompareTag("Player"))
        {
            if (gameManager != null)
            {
                gameManager.gotoGoodEnding();
            }
        }
    }


}
