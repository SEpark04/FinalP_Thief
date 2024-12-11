using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCtrl : MonoBehaviour
{
    public void PressRestart()
    {
        GameManager.instance.Restart();
    }

    public void PressExit()
    {
        Application.Quit();
    }
}
