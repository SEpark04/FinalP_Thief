using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static float globalSpeed;

    public TextMeshProUGUI timerText; // �ð� ǥ�ÿ� UI Text ����
    private float startTime;  //���� ���� �ð� ����

    [SerializeField] private GameObject gameoverG;  //���� ���� ȭ��
    public bool isOver;  //���ӿ��� ���� Ȯ��

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        isOver = false;
        startTime = Time.time; // ���� ���� �ð��� ����
    }

    void Update()
    {
        if (!isOver)
        {
            float elapsedTime = Time.time - startTime; // ��� �ð� ���

            // �ð�:��:�� �������� ��ȯ
            int hours = Mathf.FloorToInt(elapsedTime / 3600);
            int minutes = Mathf.FloorToInt((elapsedTime % 3600) / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);

            timerText.text = $"{hours:00}:{minutes:00}:{seconds:00}";
        }
    }

    public void GameOver()  // �ǰ� �� ������ ������ ���� ����
    {
        isOver = true;
        gameoverG.SetActive(true);


        if (Input.GetKeyDown(KeyCode.R) && isOver == true)  // ���� ���� �� RŰ ������ ���� �����
        {
            Restart();
        }
    }



    public void Restart()  // ���� �����
    {
        string currentScene = SceneManager.GetActiveScene().name; // ���� ���� �̸��� ������
        LoadingCtrl.LoadScene(currentScene); // ���� �� �����
        startTime = Time.time; // ���� ���� �ð��� ����
        isOver = false;
    }


    // �����ϸ� HpCtrl ��ũ��Ʈ���� ����Ǵ� ���ӿ��� �̺�Ʈ
    public void DieJump()
    {
        gotoJumpDeath();
    }

    public void gotoJumpDeath() 
    {
        SceneManager.LoadScene("JumpDeath");
    }
}
