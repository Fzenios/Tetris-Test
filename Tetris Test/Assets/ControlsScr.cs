using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsScr : MonoBehaviour
{
    public static TetrisBlockScr tetrisBlockScr;
    public static bool DropBool;
    public void RotateClick()
    {
        tetrisBlockScr.RotateBtn();
    }
    public void DropDown()
    {
        DropBool = true;
    }
    public void DropUp()
    {
        DropBool = false;
    }
    public void RightClick()
    {
        tetrisBlockScr.GoRight();
    }
    public void LeftClick()
    {
        tetrisBlockScr.GoLeft();
    }
}
