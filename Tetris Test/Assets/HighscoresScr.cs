using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoresScr : MonoBehaviour
{

    [SerializeField] TMP_Text ClassicHSTxt, HCasualHSTxt;
    [SerializeField] SaveManagerScr saveManagerScr;
    [SerializeField] HighScoresObject highScoresObject;
    void Awake()
    {
        saveManagerScr.Load();
    }
    void Start()
    {
        ClassicHSTxt.text = "Classic HightScore:" + "\n" + highScoresObject.dataForSaving.ClassicHS;
        HCasualHSTxt.text = "Hypercasual HightScore:" + "\n" + highScoresObject.dataForSaving.HyperHS;
    }
}
