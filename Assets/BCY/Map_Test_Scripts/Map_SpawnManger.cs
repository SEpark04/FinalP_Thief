using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_SpawnManger : MonoBehaviour
{
    Map_RoadSpawner roadSpawner;

    void Start()
    {
        roadSpawner = GetComponent<Map_RoadSpawner>();
    }

    // Update is called once per frame
    public void SpawnTriggerEntered()
    {
        roadSpawner.MoveRoad();
    }
}
