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

    // ���� �� �״� �̺�Ʈ
    public bool jumpD;

    void Awake()
    {
        instance = this;  // �̱���
        jumpD = false;
    }


    // ��ֹ����� ȣ���Ͽ� ���
    public void Hp_down(float damage)  
    {
        _slider.value -= damage;  // ü�¹� �پ��� ����
        StartCoroutine(hp_red_change());  // ü�¹� ������
    }

    //�������� �Ծ��� �� ���������� ü�¹ٸ� �Ӱ� ����
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
        //ü�¹ٰ� �� ������ ���ӿ���(GameManager���� ������)
        else if (_slider.value < 0.001f)
        {
            GameManager.instance.GameOver();
        }
    }
}
