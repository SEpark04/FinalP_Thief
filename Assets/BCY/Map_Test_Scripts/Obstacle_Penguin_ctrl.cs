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

    // �÷��̾� �浹 �ڵ�
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
