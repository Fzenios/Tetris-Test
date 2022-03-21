using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScr : MonoBehaviour
{
    public static float FallTimeSlow, FallTimeFast;
    [SerializeField] float Lvl1, Lvl2, Lvl3, lvl4, lvl5, lvl6;
    float Timer;
    void Start()
    {
        FallTimeSlow = Lvl1;
        FallTimeFast = 0.1f;
        Timer = 0;
    }

    void Update()
    {
        Timer += Time.deltaTime;
        Debug.Log(Timer);

        if (Timer > 705)
            return;

        if (Timer < 50)
            FallTimeSlow = Lvl1;
        else if (Timer > 50 && Timer < 100)
            FallTimeSlow = Lvl2;
        else if (Timer > 100 && Timer < 300)
            FallTimeSlow = Lvl3;
        else if (Timer > 300 && Timer < 500)
            FallTimeSlow = lvl4;
        else if (Timer > 500 && Timer < 700)
            FallTimeSlow = lvl5;
        else if (Timer > 700)
            FallTimeSlow = lvl6;
    }
}
