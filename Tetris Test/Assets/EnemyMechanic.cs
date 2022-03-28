using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyMechanic : MonoBehaviour
{
    [SerializeField] Slider EnemySlider;
    [SerializeField] TMP_Text ScoreTxt;
    public int Score;
    [SerializeField] EnemySpownerScr enemySpownerScr;
    [SerializeField] DifficultyScr difficultyScr;
    float EnemyHealth;
    void Start()
    {
        ScoreTxt.text = "0";
    }

    public void SetUpEnemy(string Name)
    {
        switch (Name)
        {
            case "Wolf": EnemyHealth = 8 + EnemyHpCalc(); break;
            case "Skeleton": EnemyHealth = 12 + EnemyHpCalc(); break;
            case "Orc": EnemyHealth = 10 + EnemyHpCalc(); break;
            case "Dragon": EnemyHealth = 15 + EnemyHpCalc(); break;
            case "Scorpion": EnemyHealth = 6 + EnemyHpCalc(); break;
            case "Spider": EnemyHealth = 7 + EnemyHpCalc(); break;
        }
        EnemySlider.maxValue = EnemyHealth;
        EnemySlider.value = EnemyHealth;
    }

    public void EnemyDamaged(float Damage)
    {
        EnemyHealth -= Damage;
        EnemySlider.value = EnemyHealth;
        if (EnemyHealth <= 0)
        {
            Score++;
            ScoreTxt.text = Score.ToString();
            enemySpownerScr.EnemyDead();
        }
    }

    float EnemyHpCalc()
    {
        switch (DifficultyScr.FallTimeSlow)
        {
            case 1f: return 1;
            case 0.7f: return 2;
            case 0.5f: return 3;
            case 0.3f: return 4;
            case 0.2f: return 5;
            case 0.1f: return 6;
            default: return 6;
        }
    }
}
