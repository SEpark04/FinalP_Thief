using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static float globalSpeed;

    public TextMeshProUGUI timerText; // 시간 표시용 UI Text 연결
    private float startTime;  //게임 시작 시간 저장

    [SerializeField] private GameObject gameoverG;  //게임 오버 화면
    public bool isOver;  //게임오버 여부 확인

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
        startTime = Time.time; // 게임 시작 시간을 저장
    }

    void Update()
    {
        if (!isOver)
        {
            float elapsedTime = Time.time - startTime; // 경과 시간 계산

            // 시간:분:초 형식으로 변환
            int hours = Mathf.FloorToInt(elapsedTime / 3600);
            int minutes = Mathf.FloorToInt((elapsedTime % 3600) / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);

            timerText.text = $"{hours:00}:{minutes:00}:{seconds:00}";
        }
    }

    public void GameOver()  // 피가 다 닳으면 나오는 게임 오버
    {
        isOver = true;
        gameoverG.SetActive(true);


        if (Input.GetKeyDown(KeyCode.R) && isOver == true)  // 게임 오버 시 R키 누르면 게임 재시작
        {
            Restart();
        }
    }



    public void Restart()  // 게임 재시작
    {
        string currentScene = SceneManager.GetActiveScene().name; // 현재 씬의 이름을 가져옴
        LoadingCtrl.LoadScene(currentScene); // 현재 씬 재시작
        startTime = Time.time; // 게임 시작 시간을 저장
        isOver = false;
    }


    // 점프하면 HpCtrl 스크립트에서 실행되는 게임오버 이벤트
    public void DieJump()
    {
        gotoJumpDeath();
    }

    public void gotoJumpDeath() 
    {
        SceneManager.LoadScene("JumpDeath");
    }
}
