using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionScr : MonoBehaviour
{
    EnemyMechanic enemyMechanic;
    void Start()
    {
        enemyMechanic = FindObjectOfType<EnemyMechanic>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        enemyMechanic.EnemyDamaged(3);
    }
}
