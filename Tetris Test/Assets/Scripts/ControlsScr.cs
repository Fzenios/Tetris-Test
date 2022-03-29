using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsScr : MonoBehaviour
{
    public static TetrisBlockScr tetrisBlockScr;
    public static bool DropBool;
    [SerializeField] GameObject PCControls, MobileControls;
    void Start()
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        {
            PCControls.SetActive(true);
            MobileControls.SetActive(false);
        }
#elif UNITY_ANDROID || UNITY_IOS
{
            PCControls.SetActive(false);
            MobileControls.SetActive(true);
        }
#else
{
            PCControls.SetActive(true);
            MobileControls.SetActive(false);
        }

#endif

    }
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
