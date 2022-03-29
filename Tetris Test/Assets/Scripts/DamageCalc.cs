using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalc : ScoreCounterScr
{
    float Damage;
    public override void ScoreCount()
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
                case 1f: Damage = ScoreCalculator(1); break;
                case 0.7f: Damage = ScoreCalculator(2); break;
                case 0.5f: Damage = ScoreCalculator(3); break;
                case 0.3f: Damage = ScoreCalculator(4); break;
                case 0.2f: Damage = ScoreCalculator(5); break;
                case 0.1f: Damage = ScoreCalculator(6); break;
                default: Damage = ScoreCalculator(6); break;
            }
            ScoreToAdd = 0;
            FindObjectOfType<EnemyMechanic>().EnemyDamaged(Damage);
            Damage = 0;
        }
    }
    float ScoreCalculator(float Level)
    {
        switch (ScoreToAdd)
        {
            case 1: return 1.2f * (Level + 0.5f);
            case 2: return 1.5f * (Level + 0.7f);
            case 3: return 2 * (Level + 0.9f);
            case 4: return 2.5f * (Level + 1.5f);
            default: return 2.5f * (Level + 1.5f);
        }
    }
}
