using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCtrl : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gotoGame();
        }
    }

    void gotoGame()
    {
        LoadingCtrl.LoadScene("Map");
    }
}
