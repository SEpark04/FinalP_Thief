using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpCtrl : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _gameover;
    public static HpCtrl instance;
    private float hp = 100;

    // 점프 시 죽는 이벤트
    public bool jumpD;

    void Awake()
    {
        instance = this;  // 싱글턴
        jumpD = false;
    }


    // 장애물에서 호출하여 사용
    public void Hp_down(float damage)  
    {
        _slider.value -= damage;  // 체력바 줄어들게 만듦
        StartCoroutine(hp_red_change());  // 체력바 빨갛게
    }

    //데미지를 입었을 때 순간적으로 체력바를 붉게 만듦
    IEnumerator hp_red_change()
    {
        HitEffectScript.instance.HitEffect();
        _slider.image.color = Color.red;

        yield return new WaitForSeconds(0.08f);

        _slider.image.color = Color.white;

        yield return null;
    }

    void Update()
    {
        if (jumpD == true)
        {
            StartCoroutine(hp_red_change());
            GameManager.instance.DieJump();
        }
        //체력바가 다 닳으면 게임오버(GameManager에서 관리중)
        else if (_slider.value < 0.001f)
        {
            GameManager.instance.GameOver();
        }
    }
}
