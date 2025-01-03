using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_turn_Ctrl : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float dmg = 1.0f;
    private Collider colliders;

    void Start()
    {
        colliders = GetComponent<Collider>();
    }

    
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
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
