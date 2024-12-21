using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Penguin_ctrl : MonoBehaviour
{

    private Collider colliders;
    public float dmg = 1.0f;

    void Start()
    {
        colliders = GetComponent<Collider>();
    }

    // 플레이어 충돌 코드
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colliders.enabled = false;
            HpCtrl.instance.Hp_down(dmg);
            HitEffectScript.instance.HitEffect();
            //Destroy(this.gameObject);
        }
    }
}
