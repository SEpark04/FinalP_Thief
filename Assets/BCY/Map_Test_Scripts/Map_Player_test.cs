using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Player_test : MonoBehaviour
{
    public float speed = 5.0f;
    //public Map_SpawnManger spawnManger;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        float move_h = Input.GetAxis("Horizontal")* speed / 2;
        float move_v = Input.GetAxis("Vertical") * speed;

        transform.Translate (new Vector3(move_h, 0, move_v) * Time.deltaTime);
    }

    /* private void OnTriggerEnter(Collider other) 
    {
        spawnManger.SpawnTriggerEntered();
    }
    */
}
