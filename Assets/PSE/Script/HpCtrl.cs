using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpCtrl : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _gameover;
    public static HpCtrl instance;
    private float hp = 10;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public void Hp_down(float damage)
    {
        _slider.value -= damage;
        StartCoroutine(hp_red_change());
    }

    IEnumerator hp_red_change()
    {
        _slider.image.color = Color.red;

        yield return new WaitForSeconds(0.08f);

        _slider.image.color = Color.white;

        yield return null;
    }

    void Update()
    {
        if (_slider.value < 0.001f)
        {
            GameManager.instance.GameOver();
        }
    }
}
