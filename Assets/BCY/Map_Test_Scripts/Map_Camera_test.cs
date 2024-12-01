using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Camera_test : MonoBehaviour
{
    private Transform player;
    public float camera_y = 3f;
    public float camera_z = -8f;

    public void Start()
    {
        player = GameObject.Find("Player_test").transform;
    }

    
    public void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + camera_y, player.position.z + camera_z);
    }
}
