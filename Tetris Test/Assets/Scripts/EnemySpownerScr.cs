using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpownerScr : MonoBehaviour
{
    [SerializeField] GameObject[] EnemyObj;
    [SerializeField] Transform EnemiesParent;
    [SerializeField] EnemyMechanic enemyMechanic;
    GameObject SpownedEnemy;

    void Start()
    {
        SpownEnemy();
    }

    public void EnemyDead()
    {
        Destroy(SpownedEnemy);
        SpownEnemy();
    }
    public void SpownEnemy()
    {
        int RandomX = Random.Range(1, 9);
        int RandomEnemy = Random.Range(0, EnemyObj.Length);
        SpownedEnemy = Instantiate(EnemyObj[RandomEnemy], new Vector2(RandomX, 18), Quaternion.identity, EnemiesParent);
        enemyMechanic.SetUpEnemy(EnemyObj[RandomEnemy].name);
    }
}
