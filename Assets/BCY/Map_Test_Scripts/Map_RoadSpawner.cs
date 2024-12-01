using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map_RoadSpawner : MonoBehaviour
{
    public List<GameObject> roads;
    public float offset = 4f;

    void Start()
    {
        if (roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }

    }

    public void MoveRoad() 
    {
        GameObject movedRoad = roads[0];
        roads.Remove(movedRoad);
        float newZ = roads[roads.Count - 1].transform.position.z + offset;
        movedRoad.transform.position = new Vector3(0, 0, newZ);
        roads.Add(movedRoad);
    }
}
