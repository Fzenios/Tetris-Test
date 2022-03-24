using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreCounterScr : MonoBehaviour
{
    [SerializeField] float Score;
    [SerializeField] TMP_Text ScoreTxt;
    protected float ScoreToAdd;
    protected bool IsCalculating;
    void Start()
    {
        Score = 0;
        ScoreToAdd = 0;
        ScoreTxt.text = "0";
    }
    public virtual void ScoreCount()
    {
        ScoreToAdd++;
        StartCoroutine(FinishTheFrame());
    }
    IEnumerator FinishTheFrame()
    {
        IsCalculating = false;
        yield return new WaitForEndOfFrame();
        if (!IsCalculating)
        {
            IsCalculating = true;
            switch (DifficultyScr.FallTimeSlow)
            {
                case 1f: Score += ScoreCalculator(0); break;
                case 0.7f: Score += ScoreCalculator(1); break;
                case 0.5f: Score += ScoreCalculator(2); break;
                case 0.3f: Score += ScoreCalculator(3); break;
                case 0.2f: Score += ScoreCalculator(4); break;
                case 0.1f: Score += ScoreCalculator(5); break;
                default: Score += ScoreCalculator(5); break;
            }
            ScoreTxt.text = Score.ToString();
            ScoreToAdd = 0;
        }
    }
    float ScoreCalculator(int Level)
    {
        switch (ScoreToAdd)
        {
            case 1: return 40 * (Level + 1);
            case 2: return 100 * (Level + 1);
            case 3: return 300 * (Level + 1);
            case 4: return 1200 * (Level + 1);
            default: return 1200 * (Level + 1);
        }
    }

}
